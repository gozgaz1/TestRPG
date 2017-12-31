using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

    public Button yourButton;
    public GameObject ReSetPanel;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        ReSetPanel = GameObject.Find("Player Panel");
    }

    void TaskOnClick()
    {
        ReSetPanel.GetComponentInChildren<Clicking>().HitCounter = 0;
    }
    
}
