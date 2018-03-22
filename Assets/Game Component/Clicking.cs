using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Might want to separate the hover functionalities to a different script...
// if a unit is dead, use color 6F2828FF

public class Clicking : MonoBehaviour, IPointerUpHandler,IPointerClickHandler, IPointerDownHandler {//, IPointerExitHandler,IPointerEnterHandle {
    private Vector3 moving = new Vector3(10, 5);
    public static GameObject firstChosen = null;
    public static GameObject secondChosen = null;
    public static Transform tempt = null;

    //test stuff
    public int HitCounter = 0;
    public int FinalStrike;
    //

    private Vector3 startingPos; // might be made to private
    //public GameObject InfoCanvas;
    //private Sprite theSprite;
    private bool PowerOn = false;
    private bool StatusOn = true;
    public bool beingSelected = false;
    public bool AttackTarget = false;
    
    private RuntimeAnimatorController thePower;
    public static GameObject currentlySelectedTarget;


    void Start() {
        FinalStrike = 0;
        startingPos = this.GetComponent<RectTransform>().anchoredPosition;
        thePower = (RuntimeAnimatorController)Resources.Load("Animation/PowerUp");
    }

    public void OnPointerClick(PointerEventData eventData) {
        //Debug.Log("Getting Object at " + startingPos);
        if (StatusOn)
            FinalStrike += 1;
        if (PowerOn && StatusOn && this.transform.tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase)) {
            PowerOn = false;
            FinalStrike = 1;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Animation/NormalMode");
        }

        // this should be a function******
        SwitchAction();
    }

    public void OnPointerDown(PointerEventData eventData) {
        //need to change the way currentlySelectedTarget is set
        currentlySelectedTarget = this.gameObject;

        if (StatusOn && !beingSelected)
        {
            ShiftToSelect(this.transform.gameObject);
        }
        else if (StatusOn && beingSelected)
        {
            ShiftToNormal(this.transform.gameObject);

        }
        

        this.beingSelected = (!this.beingSelected) ? true : false;

    }
/*
    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log("Hover Over");

    }

    public void OnPointerExit(PointerEventData eventData) {

    }
*/
    public void OnPointerUp(PointerEventData eventData)
    {   if (Switching.switchAble && firstChosen == null && secondChosen == null && this.transform.tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase))
        {
            firstChosen = this.gameObject.transform.parent.gameObject;
        }
        else if (Switching.switchAble && firstChosen != null && secondChosen == null && this.transform.tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase))
        {
            secondChosen = this.gameObject.transform.parent.gameObject;
        }

    }

    public void ShiftToSelect(GameObject obj) {
        obj.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(obj.transform.GetComponent<Clicking>().startingPos.x + moving.x, obj.transform.GetComponent<Clicking>().startingPos.y + moving.y, obj.transform.GetComponent<Clicking>().startingPos.z);
        obj.transform.GetComponent<Clicking>().startingPos = obj.transform.GetComponent<RectTransform>().anchoredPosition;
    }

    public void ShiftToNormal(GameObject obj) {
        obj.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(obj.transform.GetComponent<Clicking>().startingPos.x - moving.x, obj.transform.GetComponent<Clicking>().startingPos.y - moving.y, obj.transform.GetComponent<Clicking>().startingPos.z);
        obj.transform.GetComponent<Clicking>().startingPos = obj.transform.GetComponent<RectTransform>().anchoredPosition;
    }

    public void SwitchAction() {
        if (Switching.switchAble && firstChosen != null && secondChosen != null)
        {
            int one = firstChosen.transform.GetSiblingIndex();
            int two = secondChosen.transform.GetSiblingIndex();
            //Debug.Log("FirstChosen = " + firstChosen + ", place = " + firstChosen.transform.GetSiblingIndex() + " secondChosen = " + secondChosen + ", place = " + secondChosen.transform.GetSiblingIndex());
            //firstChosen.transform.parent.transform.GetChild(one) = secondChosen.transform;

            if (!(one == two && firstChosen.transform.parent == secondChosen.transform.parent))
            {
                ApplyEffect(firstChosen);
                ApplyEffect(secondChosen);
                tempt = firstChosen.transform.parent;
                firstChosen.transform.SetParent(secondChosen.transform.parent);
                firstChosen.transform.SetSiblingIndex(two);
                secondChosen.transform.SetParent(tempt);
                secondChosen.transform.SetSiblingIndex(one);
                //Debug.Log(firstChosen.transform.GetComponentInChildren<Clicking>().beingSelected);
                if (firstChosen.transform.GetComponentInChildren<Clicking>().beingSelected && secondChosen.transform.GetComponentInChildren<Clicking>().beingSelected)
                {
                    firstChosen.transform.GetComponentInChildren<Clicking>().beingSelected = false;
                    secondChosen.transform.GetComponentInChildren<Clicking>().beingSelected = false;
                    ShiftToNormal(firstChosen.transform.GetChild(0).transform.gameObject);
                    ShiftToNormal(secondChosen.transform.GetChild(0).transform.gameObject);

                    
                }

                //Debug.Log(firstChosen.transform.parent.transform.GetChild(firstChosen.transform.GetSiblingIndex()));

                firstChosen = null;
                secondChosen = null;
                tempt = null;
                Switching.switchAble = false;
            }
            else {
                firstChosen = null;
                secondChosen = null;
            }
        }

    }

    public void ApplyEffect(GameObject obj) {
        
        GameObject explosive = Instantiate(Resources.Load("Explosion") as GameObject);
        //explosive.transform.position = new Vector3(5, 5, 0);
        //Debug.Log("Normal pos: " + obj.transform.position.x + ", " + obj.transform.position.y);
        //Debug.Log("Anchored pos: " + obj.transform.GetComponent<RectTransform>().anchoredPosition.x + ", " + obj.transform.GetComponent<RectTransform>().anchoredPosition.y);
        explosive.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - obj.transform.GetComponent<RectTransform>().anchoredPosition.y - moving.x, obj.transform.position.z);
        //explosive.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        Destroy(explosive, .60f);
    }

    void Update() {
        if (FinalStrike >= 10 && this.transform.tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase)) {
            PowerOn = true;
            this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = thePower;
        }
        if (this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<MonitorHP>() != null && this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<MonitorHP>().temptHP <= 0) {
            StatusOn = false;
            //if (this.transform.GetChild(0).GetChild(0).GetChild(0).tag.Equals("Enemy", System.StringComparison.OrdinalIgnoreCase))
            //    this.transform.GetComponentInChildren<Spinning>().SetSpinningToFalse();
            Debug.Log("StatusOn : " + StatusOn);
            
        }
        
    }

}


// tip to self: can't disable <Animator> component because Unity will free all resources from that component and thus
// literally destroy the component out of existence. Needs to find a new <Animator> or animation state to change to
//    this.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(137, 61, 61, 255);

// REMEMBER: purge 'true prefab' sometimes