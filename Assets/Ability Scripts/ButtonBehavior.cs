using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {
    public BaseAbility mappedAbility;
    private bool targetSelected = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        UponClick();
	}

    public void UponClick() {
        // once the button or skill is selected, find a target for it
        if (!targetSelected && Input.GetMouseButtonUp(0)) {
            Debug.Log("Please select a target");
            if (mappedAbility.EnemyChoose)
                StartCoroutine(WaitInput(this.transform.gameObject, "Enemy"));
            else if (mappedAbility.PlayerChoose)
                StartCoroutine(WaitInput(this.transform.gameObject, "Player"));
            
        }
    }

    // will delete targetLock or replace it
    public void targetLock(GameObject theTarget, string tagging) {
        // check if the target object is a valid selection for the skill and change the targetSelected to true
        Debug.Log("Acquiring target");
        if (Input.GetMouseButtonDown(0))
        {
          
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 1000))
                if (theTarget != null && theTarget.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>() != null &&
                    theTarget.transform.GetChild(0).GetChild(0).GetChild(0).tag == tagging)

                    targetSelected = true;
                else
                    Debug.Log("Not a valid target");
            Debug.Log("Target Selected: " + theTarget.transform.GetChild(0).GetChild(0).GetChild(0).tag);
        }
    }

    public IEnumerator WaitInput(GameObject theTarget, string tagging) {
        if (!targetSelected) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Acquiring target");
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000))
                    if (theTarget != null && theTarget.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>() != null &&
                        theTarget.transform.GetChild(0).GetChild(0).GetChild(0).tag == tagging)

                        targetSelected = true;
                    else
                        Debug.Log("Not a valid target");
                Debug.Log("Target Selected: " + theTarget.transform.GetChild(0).GetChild(0).GetChild(0).tag);
            }
            yield break;
        }
    }
}
