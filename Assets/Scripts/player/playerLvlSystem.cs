using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class playerLvlSystem
{
    public List<float> expNeededToLvlUp;
    public float newLvlCoefficient = 1.1f;
    public int mainLvl;
    public float mainExperience;
    public int strengthLvl;
    public float strengthExperience;
    public int agilityLvl;
    public float agilityExperience;
    public int enduranceLvl;
    public float enduranceExperience;

    public void getMainExperience(float experience)
    {
        mainExperience += experience;
        while (mainExperience > expNeededToLvlUp[mainLvl])
        {
            mainExperience -= expNeededToLvlUp[mainLvl];
            mainLvl += 1;
            // mainlvlupped buffs, можно сделать то же самое и с силой, и с ловкостью, вместо этой строки там наебашить +урон\+аттак—пид
        }
    }
    public void getStrengthExperience(float exp)
    {
        strengthExperience += exp;
        while (strengthExperience > expNeededToLvlUp[strengthLvl])
        {
            strengthExperience -= expNeededToLvlUp[strengthLvl];
            strengthLvl += 1;
        }
        getMainExperience(exp / 3);
    }
    public void getAgilityExperience(float exp)
    {
        agilityExperience += exp;
        while (agilityExperience > expNeededToLvlUp[agilityLvl])
        {
            agilityExperience -= expNeededToLvlUp[agilityLvl];
            agilityLvl += 1;
        }
        getMainExperience(exp / 3);
    }
    public void getEnduranceExperience(float exp)
    {
        enduranceExperience += exp;
        while (enduranceExperience > expNeededToLvlUp[enduranceLvl])
        {
            enduranceExperience -= expNeededToLvlUp[enduranceLvl];
            enduranceLvl += 1;
        }
        getMainExperience(exp / 3);
    }
    public void initialize()
    {
        expNeededToLvlUp = new List<float>();
        expNeededToLvlUp.Add(0);
        for (int i = 1; i < 1000; i++)
        {
            expNeededToLvlUp.Add(newLvlCoefficient * (expNeededToLvlUp[i-1] + i * 10));
        }
    }
}
