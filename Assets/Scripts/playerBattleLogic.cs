using System.Collections.Generic;
using UnityEngine;

public class playerBattleLogic : MonoBehaviour
{
    public GameObject currentWeapon;
    public KeyCode attackKey = KeyCode.Mouse0;
    public float attackPointOffset;
    public float attackRadius;


    float attackAnimationTime = 1f;
    float attackAnimaionTimeLeft;
    List<GameObject> attackableObjects = new List<GameObject>();
    Animator weaponAnimator;

    private void Start()
    {
        weaponAnimator = currentWeapon.GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        setAttackAnimationTime();        
    }
    private void setAttackAnimationTime()
    {
        foreach (AnimationClip animationClip in weaponAnimator.runtimeAnimatorController.animationClips)
        {
            if (animationClip.name == "sword attack")
            {
                attackAnimationTime = animationClip.averageDuration;
                break;
            }
        }
    }
    private void Update()
    {
        attackableObjects = getAttackableObjects();
        attackAnimaionTimeLeft -= Time.deltaTime;
        if (Input.GetKeyDown(attackKey) && attackAnimaionTimeLeft <= 0 && attackableObjects != null)
        {
            attack(attackableObjects);
        }
    }

    private void attack(List<GameObject> objectsToAttack)
    {
        attackAnimaionTimeLeft = attackAnimationTime;
        weaponAnimator.SetTrigger("attack");
        foreach(GameObject objectToAttack in objectsToAttack)
        {
            objectToAttack.GetComponent<IAttackable>().gotDamage(1f);
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