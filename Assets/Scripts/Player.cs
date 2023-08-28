using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private bool isSwimming;
    private float prevMoveSpeed;

    Animator anim;
    SpriteRenderer spriteRenderer;

    public class ItemList
    {

    }
    void Start()
    {
        prevMoveSpeed = moveSpeed;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isSwimming)
        {
            moveSpeed = 6;
        }
        else
        {
            moveSpeed = prevMoveSpeed;
        }

        Move();
    }

    void Move()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;
        transform.position += moveVelocity;
      

        if (x != 0)
        {
            Debug.Log("방향키 누름");
            anim.SetBool("lookFront", false);
            anim.SetBool("lookBack", false);
            anim.SetBool("isWalking", true);

            spriteRenderer.flipX = x == 1;
        }

        if (y == 1)
        {
            anim.SetBool("lookFront", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("lookBack", true);
        }else if (y == -1)
        {
            anim.SetBool("lookBack", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("lookFront", true);
        }

        if (x == 0 && y == 0)
        {
            anim.speed = 0.0f;
        }
        else
        {
            anim.speed = 1.0f;
        }



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            Debug.Log("수영중");
            isSwimming = true;
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("아이템 획득");
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            Debug.Log("수영끝");
            isSwimming = false;
        }
    }

    

}
