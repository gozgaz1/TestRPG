using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPBehavior : MonoBehaviour {
    private float SPAmount = 1f;
    private GameObject theSPBar;

    // Use this for initialization
    void Start () {
        theSPBar = GameObject.Find("SP");
        theSPBar.transform.GetChild(0).GetChild(0).localScale = new Vector3(Mathf.Clamp(SPAmount, 0f, 1f),
                                               theSPBar.transform.GetChild(0).GetChild(0).localScale.y,
                                               theSPBar.transform.GetChild(0).GetChild(0).localScale.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSP(int currentSP, int totalSP)
    {
        // perform update on SP mostly, the actual calculation
        SPAmount = (float)currentSP / totalSP;
        SPCalculation();
    }

    public void SPCalculation() {
        theSPBar.transform.GetChild(0).GetChild(0).localScale = new Vector3(SPAmount,
            theSPBar.transform.GetChild(0).GetChild(0).localScale.y,
            theSPBar.transform.GetChild(0).GetChild(0).localScale.z);
    }
}
