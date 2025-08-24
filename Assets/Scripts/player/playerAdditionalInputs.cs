using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAdditionalInputs : MonoBehaviour
{
    public string openLvlMenuKey = "c";

    GameObject skillsMenu;

    private void Start()
    {
        skillsMenu = GameObject.Find("UI").transform.Find("skills menu").gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(openLvlMenuKey))
        {
            openOrCloseLvlMenu();
        }
    }

    public void openOrCloseLvlMenu()
    {
        if (skillsMenu.activeInHierarchy)
        {
            skillsMenu.SetActive(false);
            return;
        }
        skillsMenu.SetActive(true);
    }
}
