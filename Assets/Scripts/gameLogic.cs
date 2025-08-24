using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    public static dataToSave data;
    public static PlayerData playerData;
    public static GameObject player;
    public static gameLogic instance;
    private void Awake()
    {
        instance = this;
        saveLogic.initialize();
        playerData = data.playerData;
        player = GameObject.Find("player");
        playerData.currentWeapon.onInteract();
        player.GetComponent<playerInteraction>().initialize();
    }
    private void Start()
    {
        playerData.currentWeapon.onInteract();
    }
    public void setPlayerValues()
    {
        player.GetComponent<playerBattleLogic>().setBattleValues();
        player.GetComponent<playerMovement>().setMoveSpeed();
    }
}
