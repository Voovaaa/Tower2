using System;
using UnityEngine;


[Serializable]
public class weapon : MonoBehaviour, IInteractable
{

    public string weaponName;
    public float damage;
    public float attackSpeed;
    public float attackRange;

    private playerBattleLogic battleLogic;
    private weapon previuosWeapon;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        transform.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        transform.GetComponent<BoxCollider>().enabled = true;
        transform.GetComponent<Animator>().enabled = false;
    }
    public void onInteract()
    {
        battleLogic = gameLogic.player.GetComponent<playerBattleLogic>();
        previuosWeapon = gameLogic.playerData.currentWeapon;
        previuosWeapon.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        previuosWeapon.transform.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        previuosWeapon.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
        previuosWeapon.transform.GetComponent<Collider>().enabled = true;
        previuosWeapon.transform.GetComponent<Animator>().enabled = false;
        previuosWeapon.transform.SetParent(null);
        gameLogic.playerData.currentWeapon = this;
        battleLogic.setBattleValues();
        transform.SetParent(battleLogic.transform.Find("camera").Find("weapon"));
        transform.position = transform.parent.position;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
        transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<Animator>().enabled = true;
    }
    public void showed()
    {
        playerInteraction.crosshairInteract.SetActive(true);
    }
    public void hided()
    {
        playerInteraction.crosshairInteract.SetActive(false);
    }
}
