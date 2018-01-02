using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float HealthAmount = 1f;
    private GameObject theHBar;
	// Use this for initialization
	void Start ()
    {
        theHBar = GameObject.Find("HP");
        theHBar.transform.GetChild(0).GetChild(0).localScale = new Vector3(Mathf.Clamp(HealthAmount, 0f, 1f),
                                               theHBar.transform.GetChild(0).GetChild(0).localScale.y,
                                               theHBar.transform.GetChild(0).GetChild(0).localScale.z);
        SetHealth(1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        // HealthCalculation();
    }


    public void SetHealth(int currentHP, int totalHP)
    {
        // perform update on health mostly, the actual calculation
        HealthAmount = 1;
        HealthAmount = (float)currentHP / totalHP;
        //Debug.Log("Character HP Percentage: " + HealthAmount);

        HealthCalculation();
    }

    public void HealthCalculation() {
        // the representation of the health bar
        theHBar.transform.GetChild(0).GetChild(0).localScale = new Vector3(HealthAmount,
            theHBar.transform.GetChild(0).GetChild(0).localScale.y,
            theHBar.transform.GetChild(0).GetChild(0).localScale.z);
    }

    public float HealthReturn() {
        return HealthAmount;
    }

   // public void TakingDamage(int damage, int currentHP, int totalHP) {
   //    currentHP -= damage;
   //     SetHealth(currentHP, totalHP);
    //}
}
