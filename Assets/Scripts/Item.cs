using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;         //������ �̸�
    public Sprite image;        //������ �̹���
    public int count;          //�������� ����
    public int health;
    public string description; //������ ����
}
