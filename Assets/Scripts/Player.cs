using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField]
    private GameObject fishing;

    public bool isFishing;
    public float moveSpeed;
    private float prevMoveSpeed;

    Animator anim;
    SpriteRenderer spriteRenderer;

    private GameObject destroyedObject;
    

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isFishing = false;
        prevMoveSpeed = moveSpeed;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

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
            Debug.Log("����Ű ����");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            destroyedObject = collision.gameObject;
            isFishing = true;
            moveSpeed = 0;
            Debug.Log("������ ȹ��");
            fishing.SetActive(true);
            
            //Destroy(collision.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea")&& !isFishing)
        {
            Debug.Log("������");
            moveSpeed = 6;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            Debug.Log("������");
            moveSpeed = prevMoveSpeed;
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void RayDestroy()
    {
        Destroy(destroyedObject);
    }
}
