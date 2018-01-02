using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityClass : ScriptableObject
{
    public int ID = 0;
    public string AName = "Unknown";
    
    public int AThreshold = 1;
    public int ALevel = 1;
    public int AAscension = 0;
    public int Cost = 0;
    public int Heal = 0;
    public int Damage = 0;
    public bool Passive = false;
    public bool Selective = true;
    public bool PlayerChoose;
    public bool EnemyChoose;
    public string ADescription = "";
    public int AmountOfHits = 1;
    //public ArrayList ExtraEffect = new ArrayList();

    public abstract void Initialize(GameObject obj);
}
