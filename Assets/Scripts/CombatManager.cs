using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> enemies;
    private float playerEnemyDistance;
    private bool isInRange;
    private int enemyIndex = 0;
    private WeaponStats playerWeapon;

    [SerializeField]private TurnManager turnManager;

    //Combat calculation
    public int enemyCurrentHealth;
    private int playerWeaponDamage;


    private void Start()
    {
        //player = GetComponent<GameObject>();
        enemyCurrentHealth = enemies[enemyIndex].GetComponent<PlayerStatus>().getHealth();
        playerWeaponDamage = player.GetComponent<PlayerStatus>().getWeaponDamage();
        playerWeapon = player.GetComponent<PlayerStatus>().weapon;
    }
    private void Update()
    {
        CheckRange();
    }

    void CheckRange() //Checks whether the enemy is whithin range of weapon.
    {
        foreach(GameObject enemy in enemies)
        {
            playerEnemyDistance = Vector3.Distance(player.transform.position, enemy.transform.position);

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
        if(turnManager.PlayerTurnActive(player) && isInRange)
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
