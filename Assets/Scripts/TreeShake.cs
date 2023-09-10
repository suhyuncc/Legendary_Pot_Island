using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TreeShake : MonoBehaviour
{
    public static TreeShake instance;
    public GameObject[] leaf = new GameObject[3];
    public GameObject[] fruit = new GameObject[3];

    private Vector3[] originPos = new Vector3[3];
    private GameObject playerObject;

    [SerializeField] 
    private GameObject honey;
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audio;

    public bool isShaked = false;
    public bool isTreeArea;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        instance = this;
        isTreeArea = false;
        playerObject = GameObject.FindWithTag("Player");
        for (int i = 0; i < 3; i++)
        {
            fruit[i].GetComponent<CircleCollider2D>().enabled = false;
        }

        int ran = Random.Range(0, 9);

        if(ran < 3) 
        {
            honey.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isShaked && isTreeArea)
        {
            audio.clip= clips[0];
            audio.Play();
            StartCoroutine(Shake());
            isShaked = true;
            Player.Instance.space.gameObject.SetActive(false);
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TreeBound"))
        {
            Debug.Log(name);
            float xPos = Random.Range(75, 96);
            float yPos = Random.Range(26, 43);
            this.gameObject.SetActive(true);
            this.gameObject.transform.position = new Vector3(xPos, yPos, 0);
        }
    }
    */

    private void OnCollisionStay2D(Collision2D collision)
    {
        //playerObject.GetComponent<Player>().space.gameObject.SetActive(true);
/*        if(collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !isShaked)
        {
            
            StartCoroutine(Shake());
            isShaked = true;
        }*/
    }



    public IEnumerator Shake()
    {
        float time = 2f;
        float shakePower = 0.5f;

        for (int i = 0; i < 3; i++)
        {
            originPos[i] = leaf[i].transform.position;
        }
        while (time > 0f)
        {
            time -= 0.1f;
            for (int i = 0; i < 3; i++)
                leaf[i].transform.position = originPos[i] + (Vector3)Random.insideUnitCircle * shakePower * time;
            yield return null;
        }

        for (int i = 0; i < 3; i++)
            leaf[i].transform.position = originPos[i];
        StartCoroutine(Dropfruit());
    }

    IEnumerator Dropfruit()
    {
        float time = 2f;
        while (time > 0f)
        {
            time -= 0.1f;
            for (int i = 0; i < 3; i++)
            {
                if(i == 0)
                {
                    fruit[i].transform.position = new Vector3(fruit[i].transform.position.x, fruit[i].transform.position.y - 0.35f, 0);
                }
                else
                {
                    fruit[i].transform.position = new Vector3(fruit[i].transform.position.x, fruit[i].transform.position.y - 0.2f, 0);
                }
                
                
            }
            
            yield return null;
        }
        for (int i = 0; i < 3; i++)
        {
            fruit[i].GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}

