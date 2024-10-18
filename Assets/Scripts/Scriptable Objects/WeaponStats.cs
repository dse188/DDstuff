using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    HeavySword,
    Dagger,
    Axe,
    Mace,
    Bow,
    Staff,
    Wand
}


[CreateAssetMenu(fileName = "Weapons", menuName = "CreateWeapon")]
public class WeaponStats : ScriptableObject
{
    [Header("Weapon stats")]
    public WeaponType weaponType;
    public string weaponName;
    public float weaponRange;
    public int weaponDamage;
}
