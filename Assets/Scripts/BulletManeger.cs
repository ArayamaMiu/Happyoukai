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
        //ìGÇ…ìñÇΩÇ¡ÇΩÇÁ
        if(collision.tag == "Enemy")
        {
            //É_ÉÅÅ[ÉWÇó^Ç¶ÇÈ
            EnemyManeger enemy = collision.GetComponent<EnemyManeger>();
            enemy.OnDamege();
            Instantiate(impactPrefab, transform.position, transform.rotation);

        }
        //îjâÛ
        Destroy(gameObject);
    }
}

  