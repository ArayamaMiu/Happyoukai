using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManeger : MonoBehaviour
{
    public GameObject impactPrefab;
    float speed = 20f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵に当たったら
        if(collision.tag == "Enemy")
        {
            //ダメージを与える
            EnemyManeger enemy = collision.GetComponent<EnemyManeger>();
            enemy.OnDamege();
            Instantiate(impactPrefab, transform.position, transform.rotation);

        }
        //破壊
        Destroy(gameObject);
    }
}

  