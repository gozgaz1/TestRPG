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
    public int Heal = 0;
    public int Damage = 0;
    public bool IsAction= true; // check if the move is proc-able, only use for player/attack turn
                                // if not, it will be automatically call during end turn or start turn
    public int Range = 1;       // if range == 0, unit can't attack
                                // if range == 1, unit can only attack front row; 
                                // if range == 2, unit can only attack back row;

    public bool Pierce = false; // a type of aoe 
                                // if true, unit can hit the front and the back (on the same column)

    public int Formation = 0;   // a variable for auto-target-selection
                                // if formation == 0, unit can only attack [index + 0] target (in front)
                                // if formation == 1, unit can only attack [index + 1] target (right)
                                // if formation == 2, unit can only attack [index + 2] target (left)
                                // calculation will be corrected, just the overall information now

    public int AOEMultiplier = 0;   // don't touch for now
    public string ADescription = "";
    public int AmountOfHits = 1;

    //public int Cost = 0;
    //public bool Passive = false;
    //public Selective;
    //public int[] PlayerChoose;
    //public int[] EnemyChoose;
    //public ArrayList ExtraEffect = new ArrayList();

    public abstract void Initialize(GameObject obj);
}
