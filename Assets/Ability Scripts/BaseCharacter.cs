using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Characters/CharacterCreation")]
public class BaseCharacterClass : CharacterClass{
    // or you can just do 'public string CharacterName{get;set}

    public override void Initialize(GameObject obj)
    {
        
    }

    public string CharacterName {
        get { return AName; }
        set { AName = value; }
    }

    public int CharacterLevel {
        get { return ALevel; }
        set { ALevel = value; }
    }

    public int CharacterAscension {
        get { return AAscension; }
        set { AAscension = value; }
    }
    
    public int CharacterHP {
        get { return HP; }
        set { HP = value; }
    }

    public int CharacterSP {
        get { return SP; }
        set { SP = value; }
    }

    public int CharacterClass {
        get { return AClass; }
        set { AClass = value; }
    }

    public string CharacterDesc {
        get { return ADescription; }
        set { ADescription = value; }
    }
}
