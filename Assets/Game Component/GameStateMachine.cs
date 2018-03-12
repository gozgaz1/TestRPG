using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// not used
/// </summary>

public class GameStateMachine : MonoBehaviour {
    /*
	public static StartTurn starting;
	public static PlayerTurn playerturn;
	public static EnemyTurn enemyturn;
	public static EndTurn ending ;

	private GameObject[] playerObjects;
    private GameObject[] enemyObjects;
    private GameObject[] totalObjects;

	[SerializeField] public GameObject theCanvas;

	// Use this for initialization
	void Start () {

		playerObjects = GameObject.FindGameObjectsWithTag("Player"); // this is find, let it slide
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        
        totalObjects = playerObjects.Concat(enemyObjects).ToArray();

		starting = new StartTurn();
		playerturn = new PlayerTurn();
		enemyturn = new EnemyTurn();
		ending = new EndTurn();

		starting.SetAvail(true);
		starting.turnCounter++;

		enemyturn.EnemyLeft = enemyObjects.Length / 2; 
	}
	
	// Update is called once per frame
	void Update () {
		FreezeIfNotPlayer();
		if(!starting.GetAvail() && !ending.GetAvail() && !enemyturn.GetAvail()){
			playerturn.SetAvail(true);// feel kinda inefficient because the function is being called numerous times
			playerturn.OnUpdate();
		}
		if(!starting.GetAvail() && !playerturn.GetAvail() && !ending.GetAvail()){
			enemyturn.SetAvail(true);
			enemyturn.OnUpdate();
		}
		if(!starting.GetAvail() && !enemyturn.GetAvail() && !playerturn.GetAvail()){
			ending.SetAvail(true);
			ending.OnUpdate();
		}
		if(!ending.GetAvail() && !enemyturn.GetAvail() && !playerturn.GetAvail() && !starting.GetAvail()){
			starting.ResetTime();
			playerturn.ResetActivePlayer();
			enemyturn.ResetTime();
			ending.ResetTime();
			starting.SetAvail(true);
			starting.turnCounter++;
		}
		if(starting.GetAvail()) // pretty much force starting to go first
			starting.OnUpdate();

		
	}

	public void OnGUI()
    {
        
        GUI.Label(new Rect(100, 100, 300, 100), "Game Starts In: " + (int)starting.timing);
		
		GUI.Label(new Rect(300, 300, 100, 200), "PlayerTurn ActivePlayer: " + (int)playerturn.GetActivePlayer());
		
		GUI.Label(new Rect(100, 300, 100, 100), "EnemyTurn Ends In: " + (int)enemyturn.timeTilEnd);
		
		GUI.Label(new Rect(300, 100, 100, 100), "Ending Ends In: " + (int)ending.endingIn);

		GUI.Label(new Rect(100, 50, 100, 100), "Turn Number: " + starting.turnCounter);

		GUI.Label(new Rect(300, 50, 100, 100), "Enemy Left: " + enemyturn.EnemyLeft);

    }


	public void FreezeIfNotPlayer(){

		if(!playerturn.GetAvail())
		{
			foreach(GameObject g in totalObjects)
				if (g.GetComponent<Clicking>() != null)
					g.GetComponent<Clicking>().enabled = false;
		}
		else{
			foreach(GameObject g in totalObjects)
				if (g.GetComponent<Clicking>() != null)
					g.GetComponent<Clicking>().enabled = true;
		}
		
	}
    */
}
