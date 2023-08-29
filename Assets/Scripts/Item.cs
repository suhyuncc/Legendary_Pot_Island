using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;         //아이템 이름
    public Sprite image;        //아이템 이미지
    public int count;          //아이템의 개수
    public int health;
    public string description; //아이템 설명
}
