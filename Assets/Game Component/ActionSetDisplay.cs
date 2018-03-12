using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// not used
/// </summary>
/// 
public class ActionSetDisplay : MonoBehaviour {
    private GameObject thePanel;
    // Use this for initialization
    void Start() {
        // set up the Action Set panel
        thePanel = GameObject.Find("Action Set");
        for (int i = 0; i < thePanel.transform.childCount; i++)
        {
            thePanel.transform.GetChild(i).GetComponentInChildren<Text>().text = "NONE";
            thePanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {

        //Debug.Log(thePanel.transform.GetChild(0).GetComponentInChildren<Text>().text);
    }
}
/*
    public void AccessSkills()
    {
        //Debug.Log("ActionSet: Enter AccessSkills");
       
        for (int i = 0; i < thePanel.transform.childCount; i++)
        {
            if (this.GetComponent<ApplyAbility>().AbilityList[i] != null && this.GetComponent<ApplyAbility>().AbilityList.Length > 0)
            {
                // once target is found, set the skill button to its respective skill on the character, then map the script to the button
                thePanel.transform.GetChild(i).GetComponentInChildren<Text>().text = this.GetComponent<ApplyAbility>().AbilityList[i].AName;
                thePanel.transform.GetChild(i).gameObject.SetActive(true);
                thePanel.transform.GetChild(i).GetComponent<Button>().interactable = true;
                thePanel.transform.GetChild(i).GetComponent<ButtonBehavior>().mappedAbility = this.GetComponent<ApplyAbility>().AbilityList[i];
            }

            if ((this.GetComponent<ApplyAbility>().AbilityList[i] != null && this.GetComponent<ApplyAbility>().AbilityList[i].Cost > this.GetComponent<MonitorHPAndSP>().temptSP) ||
                thePanel.transform.GetChild(i).GetComponentInChildren<Text>().text == "NONE" ||
                this.GetComponent<ApplyAbility>() == null)
                thePanel.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
        
    }

    public void ResetActionDisplay() {
        for (int i = 0; i < thePanel.transform.childCount; i++)
        {
            thePanel.transform.GetChild(i).GetComponentInChildren<Text>().text = "NONE";
            thePanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
*/



