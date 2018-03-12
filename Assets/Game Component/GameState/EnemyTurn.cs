using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn :  AvailableState, GameState, GameHP{
	public int EnemyLeft = 0;
	public float timeTilEnd = 5;
	private bool Availability  = false;
	private int EnemyAction = 2;
	
	public void OnUpdate(){
		if(timeTilEnd > 0)
			timeTilEnd -= Time.deltaTime;
		if(Availability && timeTilEnd <= 0)
			Availability = false;
	}


	public int getStateID{get{return 2;}}

	public int getTotalHP{get{return 100;}} // will change to reflect team's hp

	public override void ResetTime(){
		timeTilEnd = 5;
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
