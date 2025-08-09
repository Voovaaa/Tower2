using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void showed()
    {
        playerInteraction.crosshairAttack.SetActive(true);
    }
    public void hided()
    {
        playerInteraction.crosshairAttack.SetActive(false);
    }
    public void gotDamage(float damage);

}
