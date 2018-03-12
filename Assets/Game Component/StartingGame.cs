using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingGame : MonoBehaviour {
    private RuntimeAnimatorController blinker;
    private float startTime = 0;
    
	// Use this for initialization
	void Start () {

        blinker = (RuntimeAnimatorController)Resources.Load("Animation/EnemyOnSight");
        startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.realtimeSinceStartup >= startTime + 1) {
            this.transform.GetComponent<Animator>().runtimeAnimatorController = blinker;
        }
	}
}
