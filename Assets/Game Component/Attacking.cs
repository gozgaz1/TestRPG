using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : MonoBehaviour {
    [SerializeField]
    private Button AttackButton;
    public static bool AttackAble = false;

    [SerializeField]
    private GameObject frontPlayer;
    [SerializeField]
    private GameObject backPlayer;
    [SerializeField]
    private GameObject frontEnemy;
    [SerializeField]
    private GameObject backEnemy;

	// Use this for initialization
	void Start () {
        Button btn = AttackButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (AttackAble && TurnIndicator.playerturn.GetAvail())
            AttackButton.interactable = true;
        else
            AttackButton.interactable = false;
    }

    void TaskOnClick() {
        
        if (AttackAble) {
            for (int i = 0; i < frontPlayer.transform.childCount; i++) {
                // get the proper positioning
                int targetPosition = ApplyFormation(frontPlayer.transform.GetChild(i).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject, i);
                // then check if first skill is proc-able for player
                if (frontPlayer.transform.GetChild(i).GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP > 0 && 
                    frontPlayer.transform.GetChild(i).GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<ApplyAbility>().AbilityList[0].IsAction &&
                    frontEnemy.transform.GetChild(targetPosition).GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP > 0) {
                    
                    BattleEngage(frontPlayer.transform.GetChild(i).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject, 
                        frontEnemy.transform.GetChild(targetPosition).GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject);
                    //Debug.Log("Player at position " + i + " attacks enemy at position " + targetPosition + " using " + frontPlayer.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<ApplyAbility>().AbilityList[0].SkillName);
                }
            }
            AttackAble = false; 
            // for simplicity, we just let the fron rows attacking each other, no AOE or any multiplier included
        }
        /*Debug.Log("Unit 1 HP = " + frontPlayer.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP +
            "; Unit 2 HP = " + frontPlayer.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP +
            "; Unit 3 HP = " + frontPlayer.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<MonitorHP>().temptHP);
        */
        //AttackAble = (!AttackAble) ? true : false;
    }

 /*   public void OnGUI()
    {
        if (AttackAble)
            GUI.Label(new Rect(10, 300, 300, 100), "Attacking = true");
        else
            GUI.Label(new Rect(10, 300, 300, 100), "Attacking = false");
    }
*/
    public void ApplyDamageAndHeal(GameObject obj, GameObject tar, int multiRetaliate)
    {
        // solely apply proper damages
        tar.transform.GetComponent<MonitorHP>().temptHP -= 
            (obj.transform.GetComponent<ApplyAbility>().AbilityList[0].Damage * obj.transform.GetComponent<ApplyAbility>().AbilityList[0].AmountOfHits) * multiRetaliate;
        tar.transform.GetComponent<MonitorHP>().temptHP += 
            (obj.transform.GetComponent<ApplyAbility>().AbilityList[0].Heal * obj.transform.GetComponent<ApplyAbility>().AbilityList[0].AmountOfHits) * multiRetaliate;
        ApplyBattleEffect(tar);
        tar.transform.GetComponent<HealthBar>().SetHealth(tar.transform.GetComponent<MonitorHP>().temptHP, tar.transform.GetComponent<ApplyCharacter>().theChar.HP);
    }

    public int ApplyFormation(GameObject obj, int objLocation) {
        // solely apply formation for positionings
        int enemyLocation = 0;
        int expectedLocation = obj.transform.GetComponent<ApplyAbility>().AbilityList[0].Formation + objLocation;
        enemyLocation = (expectedLocation < 3) ? expectedLocation : expectedLocation - 3;
        return enemyLocation;
    }

    public void ApplyRange(GameObject obj) {
        // TODO
    }

    public void BattleEngage(GameObject firstSelect, GameObject secondSelect) {
        // apply damage from player
        ApplyDamageAndHeal(firstSelect, secondSelect, 1);
        // apply damage from enemy (retaliate)
        ApplyDamageAndHeal(secondSelect, firstSelect, firstSelect.transform.GetComponent<ApplyAbility>().AbilityList[0].AmountOfHits);
    }

    public void ApplyBattleEffect(GameObject obj) {
        GameObject attacked = Instantiate(Resources.Load("Damage") as GameObject);
        attacked.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - obj.transform.GetComponent<RectTransform>().anchoredPosition.y + 5, obj.transform.position.z);
        Destroy(attacked, .35f);
    }
}
