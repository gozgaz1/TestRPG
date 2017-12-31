using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHit : MonoBehaviour {
    public static bool beingHit = false;
    public Image myImage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (beingHit) {
            myImage.GetComponent<Image>().color = Color.red;
        }
	}


}
