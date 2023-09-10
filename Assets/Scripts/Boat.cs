using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
    public static Boat instance;

    [SerializeField]
    private GameObject fishing;
    [SerializeField]
    private Sprite[] Sprites;
    [SerializeField]
    private GameObject[] boundarys;
    [SerializeField]
    private AudioClip[] clips;

    private Rigidbody2D rb;
    private GameObject playerObject;
    public bool isBroading = false;

    public Image space;
    public float boatSpeed;
    public float x;
    public float y;
    public bool isFishing;
    public GameObject destroyedObject;
    public AudioSource audio;

    private void Awake()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Start()
    {
        instance = this;
        isFishing = false;
        playerObject = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isBroading)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            float distance = Vector3.Distance(transform.position, playerObject.transform.position);

            if (distance < 6)
            {
                if (!isBroading)
                {
                    space.gameObject.gameObject.SetActive(true);
                    //text_shake.gameObject.SetActive(true);
                }

                if (!isBroading && Input.GetKeyDown(KeyCode.Space))
                {
                    isBroading = true;
                    if (transform.position.y < -8.5f && -22f< transform.position.x && transform.position.x < 22f)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, 0);
                    }

                    playerObject.transform.position = transform.position;
                    Player.Instance.isSwimming = true;
                    space.gameObject.gameObject.SetActive(false);
                    //text_shake.gameObject.SetActive(false);


                    boatSpeed = 1f;

                    Invoke("Retrigger", 0.8f);
                    StartCoroutine(BoatSpeedReset());
                }
            }
            else
            {
                space.gameObject.gameObject.SetActive(false);
            }
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Move();
        }
    }

    IEnumerator  BoatSpeedReset()
    {
        yield return new WaitForSeconds(0.5f);
        boatSpeed = 2;
        yield return new WaitForSeconds(0.5f);
        boatSpeed = 4;
        yield return new WaitForSeconds(0.5f);
        boatSpeed = 6;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        destroyedObject = collision.gameObject;

        if (collision.gameObject.CompareTag("Fish"))
        {
            boatSpeed = 0;
            isFishing = true;
            fishing.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary") && isBroading)
        {
            Player.Instance.moveSpeed = 10;
            isBroading = false;
            Player.Instance.isSwimming = false;
            this.transform.position += new Vector3(-1f * x, -1f * y, 0);
            Player.Instance.transform.position += new Vector3(5 * x, 5 * y, 0);
        }
    }

    public void RayDestroy()
    {
        destroyedObject.gameObject.SetActive(false);
        audio.clip = clips[0];
        audio.Play();
    }

    void Retrigger()
    {
        for (int i = 0; i < boundarys.Length; i++)
        {
            boundarys[i].gameObject.gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
        }

    }

    void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0).normalized * boatSpeed * Time.deltaTime;
        //rb.MovePosition(transform.position + moveVelocity);
        transform.position += moveVelocity;
        playerObject.transform.position = transform.position;
        //playerObject.GetComponent<Rigidbody2D>().MovePosition(transform.position);

        /*        GetComponent<Rigidbody2D>().MovePosition(transform.position+ moveVelocity);
                playerObject.transform.position = transform.position;*/

        if (x == 0 && y < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else if(x == 0 && y > 0) 
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[1];
        }
        else if (x < 0 && y == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[2];
        }
        else if (x > 0 && y == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[3];
        }
        else if (x > 0 && y < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[4];
        }
        else if (x < 0 && y < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[5];
        }
        else if (x < 0 && y > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[6];
        }
        else if (x > 0 && y > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[7];
        }
    }
}
