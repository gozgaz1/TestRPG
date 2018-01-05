using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Clicking : MonoBehaviour, IPointerEnterHandler,IPointerClickHandler, IPointerDownHandler, IPointerExitHandler,IPointerUpHandler {
    private Vector3 moving = new Vector3(7, 3);

    //test stuff
    public int HitCounter = 0;
    public int FinalStrike;
    private Vector3 startingPos;
    //public GameObject InfoCanvas;
    //private Sprite theSprite;
    private bool PowerOn = false;
    public bool StatusOn = true;
    private RuntimeAnimatorController thePower;
    public static GameObject currentlySelectedTarget;


    void Start() {
        FinalStrike = 0;
        startingPos = this.GetComponent<RectTransform>().anchoredPosition;
        //InfoCanvas = GameObject.Find("Illustration Image");
        // to get the sprite, need to go through the grandchildren
        //theSprite = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite;
        thePower = (RuntimeAnimatorController)Resources.Load("Animation/PowerUp");
    }

    public void OnPointerClick(PointerEventData eventData) {
        //Debug.Log("Getting Object at " + startingPos);
        if (StatusOn)
            FinalStrike += 1;
        //Debug.Log("Expected: " + (startingPos + moving));
        //Debug.Log("Info canvas is " + InfoCanvas.name);
        //Debug.Log("Image is " + theSprite);
        if (PowerOn && StatusOn && this.transform.GetChild(0).GetChild(0).GetChild(0).tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase)) {
            PowerOn = false;
            FinalStrike = 1;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animation/NormalMode");
        }
        
    }

    public void OnPointerDown(PointerEventData eventData) {
        currentlySelectedTarget = this.gameObject;
        this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<HealthBar>().SetHealth(this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptHP, this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.HP);
        if (this.transform.GetChild(0).GetChild(0).GetChild(0).tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase))
        {
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SPBehavior>().SetSP(this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptSP, this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.SP);
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ActionSetDisplay>().AccessSkills();
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("Hover Over");
        // since i'm spawning cards in the panels, i use anchoredPosition
        if (StatusOn)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(startingPos.x + moving.x, startingPos.y + moving.y, startingPos.z);
            startingPos = this.GetComponent<RectTransform>().anchoredPosition;
            //InfoCanvas.GetComponent<Image>().sprite = theSprite;
            //InfoCanvas.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (StatusOn)
        {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector3(startingPos.x - moving.x, startingPos.y - moving.y, startingPos.z);
            startingPos = this.GetComponent<RectTransform>().anchoredPosition;
            
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<HealthBar>().SetHealth(this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptHP, this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.HP);
        if (this.transform.GetChild(0).GetChild(0).GetChild(0).tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase))
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SPBehavior>().SetSP(this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptSP, this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.SP);
        //Debug.Log(this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptHP);
    }

    void Update() {
        if (FinalStrike >= 10 && this.transform.GetChild(0).GetChild(0).GetChild(0).tag.Equals("PLayer", System.StringComparison.OrdinalIgnoreCase)) {
            PowerOn = true;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = thePower;
        }
        if (this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>() != null && this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MonitorHPAndSP>().temptHP <= 0) {
            StatusOn = false;
            if (this.transform.GetChild(0).GetChild(0).GetChild(0).tag.Equals("Enemy", System.StringComparison.OrdinalIgnoreCase))
                this.transform.GetComponentInChildren<Spinning>().SetSpinningToFalse();
        }
    }

}


// tip to self: can't disable <Animator> component because Unity will free all resources from that component and thus
// literally destroy the component out of existence. Needs to find a new <Animator> or animation state to change to
//    this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(137, 61, 61, 255);