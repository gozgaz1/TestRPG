using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private float HealthAmount = 1f;
    [SerializeField]
    private Slider theHBar;
	// Use this for initialization
	void Start ()
    {

        SetHealth(1, 1);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

   
    public void SetHealth(int currentHP, int totalHP)
    {
        // perform update on health mostly, the actual calculation
        HealthAmount = (float)currentHP / totalHP;
        //Debug.Log("Character HP Percentage: " + HealthAmount);
        theHBar.value = HealthAmount;
    }

    public float HealthReturn() {
        return HealthAmount;
    }
    
   // public void TakingDamage(int damage, int currentHP, int totalHP) {
   //    currentHP -= damage;
   //     SetHealth(currentHP, totalHP);
    //}
    
}
