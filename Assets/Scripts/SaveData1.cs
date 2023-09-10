using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData1
{
    public int savePhase;
    public int saveDays;
    public int saveHungry;
    public bool saveisSaved;


    public List<int> itemCounts = new List<int>();
}
