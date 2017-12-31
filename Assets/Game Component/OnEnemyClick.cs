using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D Rhit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (Rhit)
            {
                Rhit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("getting object " + Rhit.collider.gameObject.name);
            }
        }
        else {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            return;
        }
    }

}
