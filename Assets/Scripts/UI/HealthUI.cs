using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Stats_SO healthStat;
    [SerializeField] CombatManager combatManager;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = healthStat.health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = combatManager.enemyCurrentHealth;
        //healthBar.value = healthStat.health;
    }
}
