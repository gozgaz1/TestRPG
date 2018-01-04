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
   // private Sprite theSprite;
    private bool PowerOn = false;
    private int currentHP;
    private int totalHP;
    public bool StatusOn = true;
    private RuntimeAnimatorController thePower;


    void Start() {
        FinalStrike = 0;
        startingPos = this.GetComponent<RectTransform>().anchoredPosition;
        //InfoCanvas = GameObject.Find("Illustration Image");
        // to get the sprite, need to go through the grandchildren
        //theSprite = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite;
        thePower = (RuntimeAnimatorController)Resources.Load("Animation/PowerUp");
        currentHP = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.HP;
        totalHP = this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.HP;
    }

    public void OnPointerClick(PointerEventData eventData) {
        //Debug.Log("Getting Object at " + startingPos);
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
        //Debug.Log("Clicking Object");
        //Debug.Log("Charater HP: " + this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.currentHP);
        Debug.Log("From Clicking: " + this.tag);
        this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<HealthBar>().SetHealth(currentHP, totalHP);
        this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ActionSetDisplay>().AccessSkills();
        
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
        //Debug.Log("Done Clicking");
        //HitCounter++;
        //this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ApplyCharacter>().theChar.TakingDamage(10);
        //if (currentHP > 0)
        //    currentHP -= 10;
        //else if (currentHP <= 0)
        //    currentHP = 0;
    }

    void Update() {
        if (FinalStrike >= 10) {
            PowerOn = true;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = thePower;
        }
        if (currentHP <= 0) {
            StatusOn = false;
            //this.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            // tip to self: can't disable <Animator> component because Unity will free all resources from that component and thus
            // literally destroy the component out of existence. Needs to find a new <Animator> or animation state to change to
            this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(137, 61, 61, 255);
        }
   
    }
  
}
