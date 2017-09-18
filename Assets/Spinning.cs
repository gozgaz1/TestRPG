using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinning : MonoBehaviour {

    private RectTransform rectComponent;
    private float rotateSpeed = 200f;
    public static bool IsSpinning;

    private void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        IsSpinning = true;
    }

    private void Update()
    {
        if(IsSpinning)
            rectComponent.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
