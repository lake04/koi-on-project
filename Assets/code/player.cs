using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float defaultSpeed = 10f;//´Þ¸®±â
    int jumpCount = 1;
    public float jumpPower = 10f;

    private float curTime;
    public Transform pos;
    public Vector2 boxSize;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spriteRenderer;
 


    
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed =moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        attack();


    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("iswalking", true);
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 dir = new Vector3(h, 0f, 0f).normalized;
            transform.Translate(dir * defaultSpeed * Time.deltaTime);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
            
        
        else
        {
            anim.SetBool("iswalking", false);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            defaultSpeed = 8;
            anim.speed = 4.2f;
        }
       else
        {
            defaultSpeed = moveSpeed;
            anim.speed = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (jumpCount > 0) jumpCount = 1; 
            jumpCount = 1;
        }
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount <=1 && jumpCount > 0 )
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            jumpCount--;
       
        }
    }


    private void attack()
    {

        if (Input.GetMouseButtonDown(0) && curTime <=0)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            foreach(Collider2D collider in collider2Ds)
            {
                if(collider.tag == "Enemy")
                {
                    collider.GetComponent<enemy>().TakeDamage(1);
                }
            }
            Debug.Log("1");
            curTime = 1.5f;
        }

        if(curTime >=0)
        {
            curTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
       
}

