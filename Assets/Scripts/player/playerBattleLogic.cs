using System.Collections.Generic;
using UnityEngine;

public class playerBattleLogic : MonoBehaviour
{
    public GameObject currentWeapon;
    public KeyCode attackKey = KeyCode.Mouse0;


    float attackPointOffset;
    float attackRadius;
    float damage;
    float attackAnimationTime = 1f;
    float attackAnimaionTimeLeft;
    List<GameObject> attackableObjects = new List<GameObject>();
    Animator weaponAnimator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        setBattleValues();
    }
    private void Update()
    {
        attackableObjects = getAttackableObjects();
        attackAnimaionTimeLeft -= Time.deltaTime;
        if (Input.GetKeyDown(attackKey) && attackAnimaionTimeLeft <= 0)
        {
            attackAnimaionTimeLeft = attackAnimationTime;
            weaponAnimator.SetTrigger("attack");
            if (attackableObjects != null)
            {
                attack(attackableObjects);
            }
        }

    }
    public void setBattleValues()
    {
        currentWeapon = gameLogic.playerData.currentWeapon.gameObject;
        weaponAnimator = currentWeapon.GetComponent<Animator>();
        setAttackAnimationTime();
        setAttackDamage();
        setAttackRange();
    }
    private void setAttackAnimationTime()
    {
        foreach (AnimationClip animationClip in weaponAnimator.runtimeAnimatorController.animationClips)
        {
            if (animationClip.name == "attack")
            {
                attackAnimationTime = animationClip.averageDuration * gameLogic.playerData.currentWeapon.attackSpeed;
                break;
            }
        }
    }
    private void setAttackDamage()
    {
        damage = gameLogic.playerData.baseDamage + gameLogic.playerData.currentWeapon.damage;
    }
    private void setAttackRange() // 0.5f - width of player collider
    {
        attackPointOffset = gameLogic.playerData.currentWeapon.attackRange + 0.5f;
        attackRadius = attackPointOffset - 0.5f;
    }
    

    private void attack(List<GameObject> objectsToAttack)
    {
        foreach(GameObject objectToAttack in objectsToAttack)
        {
            objectToAttack.GetComponent<IAttackable>().gotDamage(damage);
        }
    }
    private List<GameObject> getAttackableObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * attackPointOffset, attackRadius);
        List<GameObject> objectsToReturn = new List<GameObject>();
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<IAttackable>() != null)
            {
                objectsToReturn.Add(collider.gameObject);
            }
        }
        if (objectsToReturn.Count > 0)
        {
            playerInteraction.crosshairAttack.SetActive(true);
            return objectsToReturn;
        }
        else
        {
            playerInteraction.crosshairAttack.SetActive(false);
            return null;
        }

    }
}