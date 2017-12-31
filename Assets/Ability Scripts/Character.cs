using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterClass : ScriptableObject{

    public string AName = "";
    public int ALevel = 1;
    public int AAscension = 0;
    public int HP = 1;
    public int SP = 1;
    public int AClass = 0;  //0 = A, 1 = P, 2 = B, 3 = S, 4 = E
    public string ADescription = "";
    public int Might = 1;
    public int Defense = 1;
    public int Defiance = 1;
    public int Stamina = 1;
    public int Fortification = 20;
    public enum SkillSets { };

    public abstract void Initialize(GameObject obj);
}
