using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField]
    private GameObject fishing;
    [SerializeField]
    private GameObject BrokenPanel;

    public TextMeshProUGUI text_shake;
    public Image space;

    public bool isFishing;
    public bool isSwimming;
    public float moveSpeed;
    public float boatSpeed;
    private float prevMoveSpeed;
    public float x;
    public float y;

    public Animator anim;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public GameObject destroyedObject;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isFishing = false;
        isSwimming = false;
        prevMoveSpeed = moveSpeed;

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isSwimming) 
        {
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            moveSpeed = 0;
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //moveSpeed = prevMoveSpeed;
        }

        Move();
    }

    public virtual void Move()
    {

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0).normalized * moveSpeed * Time.deltaTime;
        //rb.velocity = moveVelocity;
        //rb.MovePosition(transform.position + moveVelocity);
        transform.position += moveVelocity;

        //rb.MovePosition(transform.position + moveVelocity);

        if (x != 0)
        {
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
        }
        else if (y == -1)
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
        destroyedObject = collision.gameObject;

/*        if (!collision.gameObject.CompareTag("Boundary") && !collision.gameObject.CompareTag("Tree"))
        {
            moveSpeed = 0;
            //≥ø∫Òø° ¥Í¿∏∏È º”µµ 0µ«¥¬ πÆ¡¶
        }*/

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            Destroy(destroyedObject);
        }

        if (collision.gameObject.CompareTag("Fish"))
        {
            Boat.instance.boatSpeed = 0;
            isFishing = true;
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            fishing.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            Boat.instance.boatSpeed = 0;
            BrokenPanel.SetActive(true);
            RayDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary") && isSwimming)
        {
            moveSpeed = prevMoveSpeed;
            Boat.instance.isBroading = false;
            isSwimming = false;
            this.transform.position += new Vector3(5 * x, 5 * y, 0);
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            destroyedObject = collision.gameObject;
            destroyedObject.GetComponent<PickItem>().isPicked = true;
            Destroy(destroyedObject);
        }

        if (collision.gameObject.CompareTag("Mush"))
        {
            Debug.Log("æ∆¿Ã≈€ »πµÊ");
            destroyedObject = collision.gameObject;
            destroyedObject.GetComponent<PickItem>().isPicked = true;
            RayDestroy();
        }

        if (collision.gameObject.CompareTag("Tree"))
        {
            space.gameObject.SetActive(true);
            collision.gameObject.transform.GetChild(0).GetComponent<TreeShake>().isTreeArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            space.gameObject.SetActive(false);
            collision.gameObject.transform.GetChild(0).GetComponent<TreeShake>().isTreeArea = false;
        }
    }

    public void RayDestroy()
    {
        destroyedObject.gameObject.SetActive(false);
    }
}
