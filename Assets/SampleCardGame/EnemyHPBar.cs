using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : HPSystem
{
    [SerializeField] private Slider enemyHPBar;

    private void FixedUpdate()
    {
        enemyHPBar.value = (float)hp / maxHp;
    }
}
