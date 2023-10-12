using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [SerializeField] protected int maxHp;
    protected int hp;
    private void Start()
    {
        hp = maxHp;
    }

    public void HPDamage(int damage)
    {
        hp -= damage;
    }
}
