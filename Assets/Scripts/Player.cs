using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private bool isSwimming;
    private float prevMoveSpeed;
    public class ItemList
    {

    }
    void Start()
    {
        prevMoveSpeed = moveSpeed;
        

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
