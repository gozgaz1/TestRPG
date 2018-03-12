using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : AvailableState, GameState, GameHP{
	//private int ActivePlayer = 2; // the amount will represent the number of unit on front line, later on

	private bool Availability = false;
	// for testing purposes
	public float timeTilDone = 5;

	// special stuff
	public int threshold = 0;

	public void OnUpdate () {
        /*
		if(IsActivePlayer())
			timeTilDone -= Time.deltaTime;
		if(Availability && timeTilDone <= 0)
			Availability = false;
			*/
        //if(Availability && !IsActivePlayer())
        //	Availability = false;
        
        Availability = (!Attacking.AttackAble) ? false : true;
	}

	public int getStateID{get{return 1;}}

	public int getTotalHP{get{return 100;}} // will change to reflect team's hp

	public override void ResetTime(){
		timeTilDone = 5;
		
	}
	//
	// Avail Override
	//

	public override bool GetAvail(){
		return Availability;
	}
	public override void SetAvail(bool stateBool){
		this.Availability = stateBool;
	}	

	//
	// Manipulating ActivePlayer
	//
    /*
	public void ResetActivePlayer(){
		ActivePlayer = 2;
		
	}

	public int GetActivePlayer(){
		return ActivePlayer;
	}

	public void DecreaseActivePlayer(){
		ActivePlayer -= 1;
	}

	public bool IsActivePlayer(){
		// check if there's still active player(s)
		return ActivePlayer > 0;
		//this is for testing:
		//return timeTilDone > 0;
	}
    */
}
