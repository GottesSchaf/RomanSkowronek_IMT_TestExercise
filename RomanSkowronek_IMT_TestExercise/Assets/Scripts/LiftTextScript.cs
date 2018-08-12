using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftTextScript : MonoBehaviour {

    public float liftMoney;                                             //Money from itself
    public GameControllerScript GameCtrl;                               //Preference to the GameController
    public Mine01TextScript Mine01;                                     //Preference to the Mine01 text script
    public Mine02TextScript Mine02;                                     //Preference to the Mine02 text script
    public Text textFieldLift, textFieldMine01, textFieldMine02;        //Preferences to the text fields

    void Start()
    {
        StartCoroutine(WaitingTime());
    }
    //-----------------------------------------------------------------------Waiting Time for the lift--------------------------------------------------------
    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(GameCtrl.liftWaitingTime);
        liftMoney += (GameCtrl.minedMoneyMine01 + GameCtrl.minedMoneyMine02);                           //collect the money mined by Mine01 and Mine02
        textFieldLift.text = "Money lifted: " + Mathf.Round(liftMoney) + "$";
        GameCtrl.minedMoneyMine01 = 0;                                                                  //reset the money mined by Mine01 in the GameController
        GameCtrl.minedMoneyMine02 = 0;                                                                  //reset the money mined by Mine02 in the GameController
        GameCtrl.liftMoney = liftMoney;                                                                 //commit the liftMoney collected to the GameController
        Mine01.minedMoney01 = 0;                                                                        //reset the money in the Mine01 Script
        Mine02.minedMoney02 = 0;                                                                        //reset the money in the Mine02 Script
        textFieldMine01.text = "Money mined: " + Mathf.Round(GameCtrl.minedMoneyMine01) + "$";
        textFieldMine01.text = "Money mined: " + Mathf.Round(GameCtrl.minedMoneyMine02) + "$";
        //wait 3 seconds longer if Mine02 is bought
        if (GameCtrl.mine02Buyed)
        {
            yield return new WaitForSeconds(GameCtrl.liftWaitingTime);
        }
        yield return WaitingTime();
    }
}
