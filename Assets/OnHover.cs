using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log("getting input");
		
	}
	
	// Update is called once per frame


    void OnMouseEnter() {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        Debug.Log("getting " + gameObject.name);
    }

    void OnMouseOver() { 
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        
    }

    void OnMouseExit() {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("exit " + gameObject.name);
    }

    void Update(){

    }
}
