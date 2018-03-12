using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTurn : AvailableState, GameState, GameHP {
    private bool Availability = false;

    public float timeUp = 3;
	
	// Update is called once per frame
	public void OnUpdate () {
        Attacking.AttackAble = true;
        Availability = (!Switching.switchAble) ? false : true;
	}

    public int getStateID { get { return 5; } }

    public int getTotalHP { get { return 100; } }

    public override void ResetTime()
    {
        
    }

    //
    // Avail Override
    //

    public override bool GetAvail()
    {
        return Availability;
    }
    public override void SetAvail(bool stateBool)
    {
        this.Availability = stateBool;
    }

}
