using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Area"))
        {
            //Debug.Log("게임 성공");
            Boat.instance.destroyedObject.GetComponent<Fish>().isCatched = true;
        }
        else
        {
            //Debug.Log("게임 실패");
            Boat.instance.destroyedObject.GetComponent<Fish>().isCatched = false;
        }
    }
}
