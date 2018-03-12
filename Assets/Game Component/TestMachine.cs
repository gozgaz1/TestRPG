using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestMachine : MonoBehaviour {
    private float timing = 8;
    public GameObject[] playerObjects;
    public GameObject[] enemyObjects;
    public GameObject[] totalObjects;
	// Use this for initialization
	void Start () {
        //timing = 7;
        playerObjects = GameObject.FindGameObjectsWithTag("Player"); // this is find, let it slide
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        
        totalObjects = playerObjects.Concat(enemyObjects).ToArray();

    }
	
	// Update is called once per frame
	void Update () {
        timing -= Time.deltaTime;
        PrintingInfo();
	}

    public void OnGUI()
    {
        if (timing > 0)
            GUI.Label(new Rect(100, 100, 200, 100), "Game Starts In: " + (int)timing);
        else
            GUI.Label(new Rect(100, 100, 200, 100), "FINISH");
    }

    public void PrintingInfo() {
        foreach (GameObject a in totalObjects)
            if (a.GetComponent<ApplyCharacter>() != null)
                Debug.Log(a.GetComponent<ApplyCharacter>().theChar.AName);
    }

}
