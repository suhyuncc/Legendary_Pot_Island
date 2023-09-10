using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3[] vector3s;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어의 x좌표가 카메라 최대범위 x좌표보다 크고, z좌표는 클 때
        if (target.position.x > vector3s[0].x && target.position.y > vector3s[0].y)
        {
            transform.position = new Vector3(vector3s[0].x, vector3s[0].y, target.position.z) + offset;
        }
        //플레이어의 x좌표가 카메라 최대범위 x좌표보다 크고, z좌표는 작을 때
        else if (target.position.x > vector3s[0].x && target.position.y < vector3s[1].y)
        {
            transform.position = new Vector3(vector3s[0].x, vector3s[1].y, target.position.z) + offset;
        }
        //플레이어의 x좌표가 카메라 최대범위 x좌표보다 작고, z좌표는 클 때
        else if (target.position.x < vector3s[1].x && target.position.y > vector3s[0].y)
        {
            transform.position = new Vector3(vector3s[1].x, vector3s[0].y, target.position.z) + offset;
        }
        //플레이어의 x좌표가 카메라 최대범위 x좌표보다 작고, z좌표는 작을 때
        else if (target.position.x < vector3s[1].x && target.position.y < vector3s[1].y)
        {
            transform.position = new Vector3(vector3s[1].x, vector3s[1].y, target.position.z) + offset;
        }
        //플레이어의 x좌표가 카메라 최대범위 x좌표보다 클 때
        else if (target.position.x > vector3s[0].x)
        {
            transform.position = new Vector3(vector3s[0].x, target.position.y, target.position.z) + offset;
        }
        //플레이어의 x좌표가 카메라 최대범위 x좌표보다 작을 때
        else if (target.position.x < vector3s[1].x)
        {
            transform.position = new Vector3(vector3s[1].x, target.position.y, target.position.z) + offset;
        }
        //플레이어의 z좌표가 카메라 최대범위 z좌표보다 클 때
        else if (target.position.y > vector3s[0].y)
        {
            transform.position = new Vector3(target.position.x, vector3s[0].y, target.position.z) + offset;
        }
        //플레이어의 z좌표가 카메라 최대범위 z좌표보다 작을 때
        else if (target.position.y < vector3s[1].y)
        {
            transform.position = new Vector3(target.position.x, vector3s[1].y, target.position.z) + offset;
        }
        else
        {
            transform.position = target.position + offset;
        }
    }
}
