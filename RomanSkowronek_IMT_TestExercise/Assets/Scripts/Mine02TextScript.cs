using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine02TextScript : MonoBehaviour {

    public float minedMoney02;                  //Money from itself
    public GameControllerScript GameCtrl;       //Preference to the GameController
    public Text textFieldMine02;                //Preference to the TexField of Mine02
    
    void Start()
    {
        StartCoroutine(WaitingTime());
    }
    //-----------------------------------------------------------------------Waiting Time for Mine02----------------------------------------------------------
    IEnumerator WaitingTime()
    {
        //execute only if the 2nd mine is already bought
        if (GameCtrl.mine02Buyed == true)
        {
            yield return new WaitForSeconds(3);
            minedMoney02 += GameCtrl.levelMine01 * 10;                                      //set the money equals the Level of Mine01 times 10
            textFieldMine02.text = "Money mined: " + Mathf.Round(minedMoney02) + "$";       
            GameCtrl.minedMoneyMine02 = minedMoney02;                                       //commit the calculated mined money to the GameController variable
            yield return WaitingTime();
        }
        //else try again in 1 second
        else
        {
            yield return new WaitForSeconds(1);
            yield return WaitingTime();
        }
    }
}
