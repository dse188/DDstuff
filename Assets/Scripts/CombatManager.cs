using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    [SerializeField] List<GameObject> players;
    [SerializeField] List<GameObject> enemies;
    private float playerEnemyDistance;
    private bool isInRange;
    private int enemyIndex = 0;
    private int playerIndex = 0;
    private WeaponStats playerWeapon;

    [SerializeField]private TurnManager turnManager;

    //Combat calculation
    public int enemyCurrentHealth;
    private int playerWeaponDamage;


    private void Start()
    {
        enemyCurrentHealth = enemies[enemyIndex].GetComponent<PlayerStatus>().getHealth();

        playerWeaponDamage = players[playerIndex].GetComponent<PlayerStatus>().getWeaponDamage();
        playerWeapon = players[playerIndex].GetComponent<PlayerStatus>().weapon;

    }
    private void Update()
    {
        playerIndex = turnManager.currentPlayerIndex;
        playerWeaponDamage = players[playerIndex].GetComponent<PlayerStatus>().getWeaponDamage();
        playerWeapon = players[playerIndex].GetComponent<PlayerStatus>().weapon;

        CheckRange();
    }

    void CheckRange() //Checks whether the enemy is whithin range of weapon.
    {
        foreach(GameObject enemy in enemies)
        {
            playerEnemyDistance = Vector3.Distance(players[playerIndex].transform.position, enemy.transform.position);

            if (playerWeapon.weaponRange >= playerEnemyDistance)
            {
                isInRange = true;
            }
            else
            {
                isInRange = false;
            }
        }
    }

    public void Attack()
    {
        if(turnManager.PlayerTurnActive(players[playerIndex]) && isInRange)
        {
            enemyCurrentHealth -= playerWeaponDamage;
            Debug.Log("Enemy attacked! Enemy current health is: " + enemyCurrentHealth);

            if(enemyCurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        //enemies[enemyIndex].gameObject.SetActive = false;
    }
}
