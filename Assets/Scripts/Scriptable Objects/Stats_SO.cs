using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerClass
{
    //[Header("Class Type")]
    Warrior,
    Mage,
    Archer
}

[CreateAssetMenu(fileName = "Stats", menuName = "PlayerStats")]
public class Stats_SO : ScriptableObject
{
    public string playerName;
    public PlayerClass playerClass;

    [Header("Base stats")]
    public int health;
    public int mana;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int defense;
    public int speed;
}