using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerManeger : MonoBehaviour
{


    // Start is called before the first frame update
    private Rigidbody2D rb;

    private Animator anim;
    public Transform muzzle;
    public GameObject bulletPrefab;
    Animator animator;

    public float speed = 7;
    public float jumpForce = 400;
    float coolTime = 0.3f;
    float leftCoolTime;
    public LayerMask groundLayer;

    private bool isGround;
    bool isRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        isRight = true;
        leftCoolTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //���s
        float x = Input.GetAxisRaw("Horizontal");
        //���s�A�j���[�V�����ɐ؂�ւ�
        anim.SetFloat("Speed", Mathf.Abs(x * speed));
        rb.AddForce(Vector2.right * x * speed);


        //�W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            //�W�����v���[�V�����ɐ؂�ւ�
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetBool("isJump", true);
            StartCoroutine(JumpEnd());
        }


        


        Direction(x);
        Shot();
    }
    IEnumerator JumpEnd()
    {
        yield return new WaitForSeconds(0.7f);
        anim.SetBool("isJump", false);
    }
    void Direction(float inputX)
    {
        //�E�����ō����͂Ȃ�180�x��]
        if (isRight && inputX < 0)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = false;
        }
        //�������ŉE���͂Ȃ�180�x��]
        if (!isRight && inputX > 0)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = true;
        }
    }
    void Shot()
    {
        leftCoolTime -= Time.deltaTime;
        if (leftCoolTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //�ˌ����[�V�����ɐ؂�ւ�
                animator.SetTrigger("Shot");
                //�e�̐���
                Instantiate(bulletPrefab, muzzle.position, transform.rotation);
                leftCoolTime = coolTime;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGround = false;
        }
    }
}
