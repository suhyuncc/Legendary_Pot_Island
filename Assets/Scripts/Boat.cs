using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boat : Player 
{
    public static Boat instance;

    [SerializeField]
    private Sprite[] Sprites;
    [SerializeField]
    private GameObject[] boundarys;

    private GameObject playerObject;
    public bool isBroading = false;

    void Start()
    {
        instance = this;
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame

    void FixedUpdate() //원래는 그냥 Update
    { 
        if(!isBroading)
        {
            float distance = Vector3.Distance(transform.position, playerObject.transform.position);

            if (distance < 5)
            {
                if (!isBroading)
                {
                    space.gameObject.gameObject.SetActive(true);
                    //text_shake.gameObject.SetActive(true);
                }

                if (!isBroading && Input.GetKeyDown(KeyCode.Space))
                {
                    isBroading = true;
                    playerObject.transform.position = transform.position;
                    Player.Instance.isSwimming = true;
                    space.gameObject.gameObject.SetActive(false);
                    //text_shake.gameObject.SetActive(false);
                    Invoke("Retrigger", 0.8f);
                }
            }
            else
            {
                space.gameObject.gameObject.SetActive(false);
                //text_shake.gameObject.SetActive(false);
            }
        }
        else
        {
            Move();
        }
        
    }

    void Retrigger()
    {
        for (int i = 0; i < boundarys.Length; i++)
        {
            boundarys[i].gameObject.gameObject.GetComponent<EdgeCollider2D>().isTrigger = true;
        }
    }

    public override void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = new Vector3(x, y, 0) * boatSpeed * Time.fixedDeltaTime;

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
