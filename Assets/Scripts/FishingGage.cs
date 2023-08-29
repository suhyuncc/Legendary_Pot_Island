using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGage : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Area"))
        {
            //Debug.Log("게임 성공");
            Player.Instance.destroyedObject.GetComponent<Fish>().isCatched = true;
        }
        else
        {
            //Debug.Log("게임 실패");
            Player.Instance.destroyedObject.GetComponent<Fish>().isCatched = false;
        }
    }
}
