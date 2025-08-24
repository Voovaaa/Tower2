using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    Image bar;
    void Start()
    {
        bar = GetComponent<Image>();
    }
    void Update()
    {
        bar.fillAmount = gameLogic.playerData.currentHp / gameLogic.playerData.maxHp;
    }
}
