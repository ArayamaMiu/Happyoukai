using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
    public GameObject deathEffectPrefab;
    public int hp = 5;
    public void OnDamege()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
   
