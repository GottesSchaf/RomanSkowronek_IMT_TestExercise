using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextScript : MonoBehaviour {

    public static float minedMoney;                 //Money of itself
    public GameControllerScript GameCtrl;           //Reference to the GameController
    public LiftTextScript Lift;                     //Reference to the Lift script
    public Text textFieldMoney, textFieldLift;      //Reference to the money and lift textField

    void Start()
    {
        StartCoroutine(WaitingTime());
    }
    //-----------------------------------------------------------------------Waiting Time for the warehouse--------------------------------------------------------
    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(GameCtrl.warehouseWaitingTime);
        minedMoney = GameCtrl.liftMoney;                                                        //collect the money from the lift
        GameCtrl.money += Mathf.Round(minedMoney);                                              //commit the collected money to the GameController
        GameCtrl.liftMoney = 0;                                                                 //set the money from GameController's lift to 0
        Lift.liftMoney = 0;                                                                     //set the money from the lift script to 0
        textFieldMoney.text = "Money: " + Mathf.Round(GameCtrl.money) + "$";
        textFieldLift.text = "Money lifted: " + Mathf.Round(GameCtrl.liftMoney) + "$";
        yield return WaitingTime();
    }
}
