using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TurnIndicator : MonoBehaviour {
    public Canvas theMainCanvas;
    [SerializeField]
    private Image TurnList;

    [SerializeField]
    private GameObject frontEnemyBoard;
    [SerializeField]
    private GameObject backEnemyBoard;
    [SerializeField]
    private Transform TurnCount;

    public static StartTurn starting;
    public static PlayerTurn playerturn;
    public static SwitchTurn switchturn;
    public static EndTurn endturn;

    private GameObject[] playerObjects;
    private GameObject[] enemyObjects;
    private GameObject[] totalObjects;

    // Use this for initialization
    void Start () {
        starting = new StartTurn();
        playerturn = new PlayerTurn();
        switchturn = new SwitchTurn();
        endturn = new EndTurn();

        starting.SetAvail(true);
        starting.turnCounter++;

        starting.EnemyBoardInitiate(frontEnemyBoard, backEnemyBoard);

        playerObjects = GameObject.FindGameObjectsWithTag("Player"); // this is find, let it slide
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        totalObjects = playerObjects.Concat(enemyObjects).ToArray();
    }
	
	// Update is called once per frame
	void Update () {
        // starting > switching > attacking (player) > ending
        FreezeIfNotSwitch();
        if (!starting.GetAvail() && !endturn.GetAvail() && !playerturn.GetAvail())
        {
            TurnList.transform.GetChild(1).GetComponent<Text>().color = new Color32(241, 251, 141, 255);
            switchturn.SetAvail(true);// feel kinda inefficient because the function is being called numerous times
            switchturn.OnUpdate();
            
        }
        if (!starting.GetAvail() && !switchturn.GetAvail() && !endturn.GetAvail())
        {
            TurnList.transform.GetChild(2).GetComponent<Text>().color = new Color32(241, 251, 141, 255);
            playerturn.SetAvail(true);
            playerturn.OnUpdate();
            
        }
        if (!starting.GetAvail() && !switchturn.GetAvail() && !playerturn.GetAvail())
        {
            TurnList.transform.GetChild(3).GetComponent<Text>().color = new Color32(241, 251, 141, 255);
            ResetSelectedState();
            endturn.SetAvail(true);
            endturn.OnUpdate();
            
        }
        if (!endturn.GetAvail() && !switchturn.GetAvail() && !playerturn.GetAvail() && !starting.GetAvail())
        {
            starting.ResetTime();
            //playerturn.ResetActivePlayer();
            
            endturn.ResetTime();
            starting.EnemyAISwitch(frontEnemyBoard, backEnemyBoard);
            starting.SetAvail(true);
            starting.turnCounter++;

            ResetTurns();
        }
        if (starting.GetAvail()) // pretty much force starting to go first
        {
            TurnList.transform.GetChild(0).GetComponent<Text>().color = new Color32(241, 251, 141, 255);
            TurnCount.GetComponent<Text>().text = starting.turnCounter.ToString();
            starting.OnUpdate();
        }

    }

    public void ResetTurns() {
        for(int i = 0; i < TurnList.transform.childCount; i++)
            TurnList.transform.GetChild(i).GetComponent<Text>().color = new Color32(255, 0, 0, 255);
    }

    public void FreezeIfNotSwitch()
    {
        // freeze if not switch or playerturn or die
        foreach (GameObject g in totalObjects) {
            if ((!switchturn.GetAvail() && !playerturn.GetAvail()) || g.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<MonitorHP>().temptHP <= 0)
            {
                g.transform.GetComponent<Clicking>().enabled = false;
            }
            else {
                g.transform.GetComponent<Clicking>().enabled = true;
            }
        }
    }

    public void ResetSelectedState() {
        foreach (GameObject g in totalObjects)
        {
            if (g.transform.GetComponent<Clicking>().beingSelected) {
                g.transform.GetComponent<Clicking>().ShiftToNormal(g);
                g.transform.GetComponent<Clicking>().beingSelected = false;
            }
        }
    }

}
