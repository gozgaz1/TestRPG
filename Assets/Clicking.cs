using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Clicking : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
    private Vector3 moving = new Vector3(7, 3);

    //test stuff
    public int HitCounter = 0;
    public int FinalStrike;
    private Vector3 startingPos;
    public GameObject InfoCanvas;
    public Sprite theSprite;
    public bool PowerOn = false;
    public bool StatusOn = true;
    private RuntimeAnimatorController thePower;


    void Start() {
        FinalStrike = 0;
        startingPos = this.GetComponent<RectTransform>().anchoredPosition;
        InfoCanvas = GameObject.Find("Card Image");
        // to get the sprite, need to go through the grandchildren
        theSprite = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite;
        thePower = (RuntimeAnimatorController)Resources.Load("Animation/PowerUp");

    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Getting Object at " + startingPos);
        if (StatusOn)
            FinalStrike += 1;
        //Debug.Log("Expected: " + (startingPos + moving));
        //Debug.Log("Info canvas is " + InfoCanvas.name);
        //Debug.Log("Image is " + theSprite);
        if (PowerOn && StatusOn) {
            PowerOn = false;
            FinalStrike = 1;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animation/NormalMode");
        }
        
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("Button down");
        // since i'm spawning cards in the panels, i use anchoredPosition
        if (StatusOn)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(startingPos.x + moving.x, startingPos.y + moving.y, startingPos.z);
            startingPos = this.GetComponent<RectTransform>().anchoredPosition;
            InfoCanvas.GetComponent<Image>().sprite = theSprite;
            InfoCanvas.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (StatusOn)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(startingPos.x - moving.x, startingPos.y - moving.y, startingPos.z);
            startingPos = this.GetComponent<RectTransform>().anchoredPosition;
            HitCounter++;
        }
    }

    void Update() {
        if (FinalStrike >= 10) {
            PowerOn = true;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = thePower;
        }
        if (HitCounter >= 15) {
            StatusOn = false;
            this.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(137, 61, 61, 255);
        }
   
    }
  
}
