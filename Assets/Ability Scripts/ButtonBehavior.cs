using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour{
    public BaseAbility mappedAbility;
    private bool targetSelected = false;
    //public int tempHP = Clicking.currentHP;
    private GameObject currentPlayer;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	}

    

    public void UponClick() {
        // once the button or skill is selected, find a target for it
        currentPlayer = Clicking.currentlySelectedTarget;
        Debug.Log(currentPlayer);
        if (!targetSelected) {
            Debug.Log("Please select a target");
            if (mappedAbility.EnemyChoose)
                StartCoroutine(WaitInput("Enemy"));
            else if (mappedAbility.PlayerChoose)
                StartCoroutine(WaitInput("Player"));
                       
        }
        targetSelected = false;
    }


    public IEnumerator WaitInput(string tagging)
    {
        while (!targetSelected)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                pointerData.position = Input.mousePosition;
                List<RaycastResult> theResult = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, theResult);

                if(theResult.Count > 0 && theResult[0].gameObject.tag.Equals(tagging,System.StringComparison.OrdinalIgnoreCase))
                {
                    //Debug.Log("TargetFound " + theResult[0].gameObject.tag);
                    //foreach (var go in theResult)
                    //{
                    //    Debug.Log(go.gameObject.name, go.gameObject);
                    //}
                    ApplyDamageAndHeal(theResult[0].gameObject);
                    ApplySPReduction(currentPlayer);
                    targetSelected = true;
                }
                else
                    Debug.Log("Empty Target");
                //Debug.Log("Done Getting");
            }
            yield return null;
        }
    }

    public void ApplyDamageAndHeal(GameObject obj) {
        obj.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptHP -= (mappedAbility.Damage * mappedAbility.AmountOfHits);
        obj.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptHP += (mappedAbility.Heal * mappedAbility.AmountOfHits);
    }

    public void ApplySPReduction(GameObject obj) {
        obj.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptSP -= mappedAbility.Cost;
    }
}

// use EventSystem
// right now: the event system only check for anything that's either an object or something with enabled raycast
// you can try: if (EventSystem.current.IsPointerOverGameObject()) 
// seems like you can also use PointerEventData to set the current RayCastAll
//
//foreach (var go in theResult)
//{
//    Debug.Log(go.gameObject.name, go.gameObject);
//}
// for C#, compare string by using string.Equal(string2, StringComparison.OrdinalIgnoreCase)
// for ignoring case, should be System.StringComparison.OrdinalIgnoreCase


// for this, theResult, as a List<RaycastResult>, takes in the lowest child to the highest, so list[0] is the lowest child gameObject
