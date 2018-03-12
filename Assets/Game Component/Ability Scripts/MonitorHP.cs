using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorHP : MonoBehaviour {

    public int temptHP = 0;
    void Start() {
        temptHP = this.GetComponent<ApplyCharacter>().theChar.HP;
    }

    void Update() {
        if (temptHP <= 0)
            temptHP = 0;
        else if (temptHP >= this.GetComponent<ApplyCharacter>().theChar.HP)
            temptHP = this.GetComponent<ApplyCharacter>().theChar.HP;
    }

}
