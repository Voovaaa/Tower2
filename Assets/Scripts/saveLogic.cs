using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveLogic : MonoBehaviour
{
    public static void saveData()
    {
        string json = JsonUtility.ToJson(gameLogic.data);
        File.WriteAllText(Application.persistentDataPath + "save.json", json);
    }
    public static dataToSave loadData()
    {
        string path = Application.persistentDataPath + "save.json";
        if (!File.Exists(path)) { return null; }
        string json = File.ReadAllText(path);
        dataToSave data = JsonUtility.FromJson<dataToSave>(json);
        return data;
    }
    public static void initialize()
    {
        gameLogic.data = loadData();
        if (gameLogic.data != null)
        { return; }
        gameLogic.data = new dataToSave();
        PlayerData playerData = new PlayerData();
        playerData.maxHp = 10;
        playerData.currentHp = 10;
        playerData.baseDamage = 1;
        playerData.baseArmor = 0;
        playerData.currentWeapon = GameObject.Find("player").transform.Find("camera").transform.Find("weapon").transform.Find("sword").GetComponent<weapon>();
        gameLogic.data.playerData = playerData;
        
    }
}
