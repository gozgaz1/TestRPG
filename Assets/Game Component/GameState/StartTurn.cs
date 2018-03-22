using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartTurn : AvailableState, GameState{
	private bool Availability = false;
	// Use this for initialization
	public float timing = (float)0.2;
	// Update is called once per frame

	public int turnCounter = 0;

    // EnemyBoard is used to indicate how gameobjects are switched around, enemy
    public Dictionary<GameObject, KeyValuePair<GameObject, int>> EnemyBoard = new Dictionary<GameObject, KeyValuePair<GameObject, int>>();

    //public static Dictionary<GameObject, KeyValuePair<GameObject, int>> UserBoard; // for later usage


    public void OnUpdate () {
        Switching.switchAble = true;
        EnemyBoardUpdate();
		if(timing > 0)
			timing -= Time.deltaTime;
		if(Availability && timing <= 0)
			Availability = false;
	}

	public int getStateID{get{return 0;}}

	public override void ResetTime(){
		timing = (float)0.2;
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


    public void EnemyBoardInitiate(GameObject enemyFront, GameObject enemyBack) {
        Debug.Log("inside EnemyBoardInitiate");
        // initiate the SwitchPlan
        // all KeyValuePair should be (Parent, position), indicating their current position on the board
        //Debug.Log("Enemy is: " + enemyFront.transform.GetChild(0).gameObject);
        
        for (int i = 0; i < enemyFront.transform.childCount; i++) {
            if (!EnemyBoard.ContainsKey(enemyFront.transform.GetChild(i).gameObject)) {
                EnemyBoard.Add(enemyFront.transform.GetChild(i).gameObject, new KeyValuePair<GameObject, int> (enemyFront, i));
            }
        }
        
        for (int i = 0; i < enemyBack.transform.childCount; i++)
        {
            if (!EnemyBoard.ContainsKey(enemyBack.transform.GetChild(i).gameObject))
            {
                EnemyBoard.Add(enemyBack.transform.GetChild(i).gameObject, new KeyValuePair<GameObject, int>(enemyBack, i));
            }
        }
    }

    public void EnemyBoardUpdate() {
        foreach (GameObject enemyUnit in EnemyBoard.Keys) {
            enemyUnit.transform.SetParent(EnemyBoard[enemyUnit].Key.transform);
            enemyUnit.transform.SetSiblingIndex(EnemyBoard[enemyUnit].Value);
            //Debug.Log(enemyUnit + " at "+ EnemyBoard[enemyUnit]);
        }
    }


    public void EnemyAISwitch(GameObject enemyFront, GameObject enemyBack) {
        // back a front row and a back row of the enemy side
        // from front to back, make switch if possible

        // startturn is where the enemies switch stuff

        // enemy will only switch if one of the following fits:

        // ** switching happens from front row first, then backrow (if necessary)
        // if all front row make a switch, don't need to check backrow


        // 
        
        Dictionary<GameObject, KeyValuePair<GameObject, int>> temptEnemyBoard = new Dictionary<GameObject, KeyValuePair<GameObject, int>> (EnemyBoard); // use this to create a 'changed' board, copy constructor
        foreach(GameObject currentEnemy in temptEnemyBoard.Keys) {
            if (temptEnemyBoard[currentEnemy].Key == enemyFront)
            {   // 1 - if the enemy unit has HP < 50% and belongs to frontrow
                if (((double)currentEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP / currentEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<ApplyCharacter>().theChar.HP) < 0.65)
                {
                   
                    foreach (GameObject neighborEnemy in temptEnemyBoard.Keys)
                    {
                        if (neighborEnemy != currentEnemy &&
                            EnemyBoard[neighborEnemy].Key == enemyBack &&
                            EnemyBoard[neighborEnemy].Value != temptEnemyBoard[currentEnemy].Value &&
                            neighborEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP > currentEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP)
                        {   // if the neighbor enemy belongs to backrow and has higher temptHP than current enemy
                            // apply changes to the main EnemyBoard
                            
                            EnemyBoard[currentEnemy] = temptEnemyBoard[neighborEnemy];
                            EnemyBoard[neighborEnemy] = temptEnemyBoard[currentEnemy];
                            //Debug.Log("Front to back: " + currentEnemy + " switch with " + neighborEnemy);
                            break;
                        }
                    }
                }
                //Debug.Log("Selected Unit was: " + currentEnemy);
            }

            else if (temptEnemyBoard[currentEnemy].Key == enemyBack) {
                // 2 - if the enemy unit belongs to backrow and first skill can heal range == 1
                if (currentEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<ApplyAbility>().AbilityList[0].Heal != 0)
                {
                    GameObject lowestHPEnemy = null;
                    foreach (GameObject neighborEnemy in temptEnemyBoard.Keys) {
                        if (lowestHPEnemy == null && temptEnemyBoard[neighborEnemy].Key == enemyFront)
                        {
                            lowestHPEnemy = neighborEnemy;
                        }

                        if (neighborEnemy != currentEnemy &&
                            EnemyBoard[neighborEnemy].Key == enemyFront &&
                            lowestHPEnemy != null &&
                            neighborEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP < lowestHPEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP &&
                            ((double)neighborEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP / neighborEnemy.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<ApplyCharacter>().theChar.HP) < .5)
                        {   // if the neighbor enemy belongs to frontrow and has the lowest amount of HP
                            lowestHPEnemy = neighborEnemy;
                            EnemyBoard[currentEnemy] = temptEnemyBoard[lowestHPEnemy];
                            EnemyBoard[lowestHPEnemy] = temptEnemyBoard[currentEnemy];
                            //Debug.Log("Back to front: " + currentEnemy + " switch with " + neighborEnemy);
                            break; 
                        }

                    }
                }
            }
           
        }
        
    // will be updated in the future
    // need: check if the unit is being targeted by more than 1 units for attack, switch to the least targeted one

    }
}