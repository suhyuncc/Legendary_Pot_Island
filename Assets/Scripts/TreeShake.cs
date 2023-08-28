using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    SpawnManager Spawnmanager;


    void Start()
    {
        Spawnmanager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine(Shake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shake()
    {
        float time = 2f;
        float shakePower = 0.5f;
        Vector3 originPos = transform.position;

        while (time > 0f)
        {
            time -= 0.1f;
            transform.position = originPos + (Vector3)Random.insideUnitCircle * shakePower * time;
            yield return null;
        }

        transform.position = originPos;
        Spawnmanager.Dropfruit(transform.position.x,
                               transform.position.y);
        //Spawnmanager.StartCoroutine(Spawnmanager.Dropfruit(transform.position.x, transform.position.y));
    }
}
