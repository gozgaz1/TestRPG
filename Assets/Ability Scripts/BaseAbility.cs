using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/AbilityCreation")]
public class BaseAbility : AbilityClass {

    public override void Initialize(GameObject obj) {
    }

    public int SkillID {
        get { return ID; }
        set { ID = value; }
    }

    public string SkillName
    {
        get { return AName; }
        set { AName = value; }
    }

    public int SkillLevel
    {
        get { return ALevel; }
        set { ALevel = value; }
    }

    public int SkillAscension
    {
        get { return AAscension; }
        set { AAscension = value; }
    }

    public int SkillCost
    {
        get { return Cost; }
        set { Cost = value; }
    }

    public int SkillHeal
    {
        get { return Heal; }
        set { Heal = value; }
    }

    public int SkillDamage
    {
        get { return Damage; }
        set { Damage = value; }
    }

    public string SkillDesc
    {
        get { return ADescription; }
        set { ADescription = value; }
    }

    public int SkillThreshold {
        get { return AThreshold; }
        set { AThreshold = value; }
    }

    public bool isPassive
    {
        get { return Passive; }
        set { Passive = value; }
    }

    public bool isPlayer
    {
        get { return PlayerChoose; }
        set { PlayerChoose = value; }
    }

    public bool isEnemy
    {
        get { return EnemyChoose; }
        set { EnemyChoose = value; }
    }

    public bool isSelective {
        get { return Selective; }
        set { Selective = value; }
    }

    public int SkillAmountOfHit {
        get { return AmountOfHits; }
        set { AmountOfHits = value; }
    }

    // public object SkillEffect(int value) {
    //     return ExtraEffect[value];
    // }

}
