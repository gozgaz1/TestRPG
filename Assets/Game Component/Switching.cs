using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switching : MonoBehaviour {
    public Button SwitchButton;
    public static bool switchAble = false;
    // Use this for initialization

	void Start () {
        Button btn = SwitchButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (!switchAble)
            SwitchButton.interactable = false;
        else
            SwitchButton.interactable = true;
        */
        SwitchButton.gameObject.SetActive(false);    
        
	}

    void TaskOnClick() {
        switchAble = (!switchAble) ? true : false;
    }

/*    public void OnGUI()
    {
        if (switchAble)
            GUI.Label(new Rect(50, 150, 500, 100), "Switch = true");
        else
            GUI.Label(new Rect(50, 150, 500, 100), "Switch = false");
    }
    */
}
