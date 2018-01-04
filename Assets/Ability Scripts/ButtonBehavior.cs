using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonBehavior : MonoBehaviour{
    public BaseAbility mappedAbility;
    private bool targetSelected = false;
    //public int tempHP = Clicking.currentHP;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
	}

    

    public void UponClick() {
        // once the button or skill is selected, find a target for it
        if (!targetSelected) {
            Debug.Log("Please select a target");
            if (mappedAbility.EnemyChoose)
                StartCoroutine(WaitInput(this.transform.gameObject, "Enemy"));
            else if (mappedAbility.PlayerChoose)
                StartCoroutine(WaitInput(this.transform.gameObject, "Player"));
            
        }
        targetSelected = false;
    }


    public IEnumerator WaitInput(GameObject theTarget, string tagging)
    {
        while (!targetSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                pointerData.position = Input.mousePosition;
                //Debug.Log("Getting gameObject");
                //if (EventSystem.current.IsPointerOverGameObject()) 
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

                    targetSelected = true;
                }
                else
                    //Debug.Log("Empty Target");
                Debug.Log("Done Getting");
            }
            yield return null;
        }
    }

    public void ApplyDamageAndHeal(GameObject obj) {
        obj.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHP>().temptHP -= (mappedAbility.Damage * mappedAbility.AmountOfHits);
        obj.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHP>().temptHP += (mappedAbility.Heal * mappedAbility.AmountOfHits);
    }
}

// use EventSystem
// right now: the event system only check for anything that's either an object or something with enabled raycast
// seems like you can also use PointerEventData to set the current RayCastAll
//
//foreach (var go in theResult)
//{
//    Debug.Log(go.gameObject.name, go.gameObject);
//}
// for C#, compare string by using string.Equal(string2, StringComparison.OrdinalIgnoreCase)
// for ignoring case
