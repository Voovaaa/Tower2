using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class skillsMenu : MonoBehaviour
{
    GameObject strength;
    GameObject agility;
    GameObject endurance;
    GameObject mainLvl;

    private void Start()
    {
        strength = transform.Find("strength").gameObject;
        agility = transform.Find("agility").gameObject;
        endurance = transform.Find("endurance").gameObject;
        mainLvl = transform.Find("main lvl").gameObject;
    }

    private void Update()
    {
        strength.transform.Find("lvl").GetComponent<TMP_Text>().text = gameLogic.data.lvlSystem.strengthLvl.ToString();
        Debug.Log(gameLogic.data.lvlSystem.expNeededToLvlUp[gameLogic.data.lvlSystem.strengthLvl]);
        strength.transform.Find("bar").GetComponent<Image>().fillAmount = gameLogic.data.lvlSystem.strengthExperience / gameLogic.data.lvlSystem.expNeededToLvlUp[gameLogic.data.lvlSystem.strengthLvl];
        agility.transform.Find("lvl").GetComponent<TMP_Text>().text = gameLogic.data.lvlSystem.agilityLvl.ToString();
        agility.transform.Find("bar").GetComponent<Image>().fillAmount = gameLogic.data.lvlSystem.agilityExperience / gameLogic.data.lvlSystem.expNeededToLvlUp[gameLogic.data.lvlSystem.agilityLvl];
        endurance.transform.Find("lvl").GetComponent<TMP_Text>().text = gameLogic.data.lvlSystem.enduranceLvl.ToString();
        endurance.transform.Find("bar").GetComponent<Image>().fillAmount = gameLogic.data.lvlSystem.enduranceExperience / gameLogic.data.lvlSystem.expNeededToLvlUp[gameLogic.data.lvlSystem.enduranceLvl];
        mainLvl.transform.Find("lvl").GetComponent<TMP_Text>().text = gameLogic.data.lvlSystem.mainLvl.ToString();
        mainLvl.transform.Find("bar").GetComponent<Image>().fillAmount = gameLogic.data.lvlSystem.mainExperience / gameLogic.data.lvlSystem.expNeededToLvlUp[gameLogic.data.lvlSystem.mainLvl];

    }

}
