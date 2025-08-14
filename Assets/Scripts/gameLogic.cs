using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    public static dataToSave data;
    public static PlayerData playerData;
    public static GameObject player;
    private void Awake()
    {
        saveLogic.initialize();
        playerData = data.playerData;
        player = GameObject.Find("player");
        playerData.currentWeapon.onInteract();
    }
    private void Start()
    {
        playerData.currentWeapon.onInteract();
    }
}
