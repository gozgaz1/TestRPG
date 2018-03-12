using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeadUnit : MonoBehaviour {
    // check if unit is dead, if so change its color
	
	// Update is called once per frame
	void Update () {
        if (this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<MonitorHP>().temptHP <= 0) {
            this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(111, 40, 40, 255);
        }
	}
}
