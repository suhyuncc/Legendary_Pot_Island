using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGage : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Area"))
        {
            Debug.Log("���� ����");
            FishingGame.instance.isSuccess = true;
        }
        else
        {
            Debug.Log("���� ����");
            FishingGame.instance.isSuccess = false;
        }
    }
}
