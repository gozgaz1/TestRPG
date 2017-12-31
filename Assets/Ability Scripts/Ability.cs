using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityClass : ScriptableObject
{

    public string AName = "Unknown";
    public int AThreshold = 1;
    public int ALevel = 1;
    public int AAscension = 0;
    public int Cost = 0;
    public int Heal = 0;
    public int Damage = 0;
    public bool Passive = false;
    public string ADescription = "";
    public int AmountOfHits = 1;
    public ArrayList ExtraEffect = new ArrayList();

    public abstract void Initialize(GameObject obj);
}
