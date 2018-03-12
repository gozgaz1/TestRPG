using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : AvailableState, GameState{
	public float endingIn = 2;
	private bool Availability = false;

    // Update is called once per frame
    public void OnUpdate () {
		if(endingIn > 0)
			endingIn -= Time.deltaTime;
		if(Availability && endingIn <= 0)
			Availability = false;
	}

	public int getStateID{get{return 3;}}

	public override void ResetTime(){
		endingIn = 8;
	}

	//
	// Avail Override
	//
	public override bool GetAvail(){
		return this.Availability;
	}	
	public override void SetAvail(bool stateBool){
		this.Availability = stateBool;
	}	


}
