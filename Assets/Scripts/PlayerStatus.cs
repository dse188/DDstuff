using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] Stats_SO statsObject;
    [SerializeField] public WeaponStats weapon;

    private void Start()
    {
        
    }

    public int getHealth()
    {
        return statsObject.health;
    }

    public int getWeaponDamage()
    {
        return weapon.weaponDamage;
    }
}
