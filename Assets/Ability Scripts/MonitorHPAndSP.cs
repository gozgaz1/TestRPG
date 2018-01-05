using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorHPAndSP : MonoBehaviour {

    public int temptHP;
    public int temptSP;
    void Start() {
        temptHP = this.GetComponent<ApplyCharacter>().theChar.HP;
        temptSP = this.GetComponent<ApplyCharacter>().theChar.SP;
    }

    void Update() {
        if (temptHP <= 0)
            temptHP = 0;
        else if (temptHP > this.GetComponent<ApplyCharacter>().theChar.HP)
            temptHP = this.GetComponent<ApplyCharacter>().theChar.HP;
        if (temptSP <= 0)
            temptSP = 0;
        else if (temptSP > this.GetComponent<ApplyCharacter>().theChar.SP)
            temptSP = this.GetComponent<ApplyCharacter>().theChar.SP;
    }

}
