using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine01TextScript : MonoBehaviour {

    public float minedMoney01;                  //Money from itself
    public GameControllerScript GameCtrl;       //Reference to the GameController
    public Text textFieldMine01;                //Reference to the TextField from Mine01

    void Start()
    {
        StartCoroutine(WaitingTime());
    }
    //-----------------------------------------------------------------------Waiting Time for Mine01----------------------------------------------------------
    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(3);
        minedMoney01 += GameCtrl.levelMine01 * 10;
        textFieldMine01.text = "Money mined: " + Mathf.Round(minedMoney01) + "$";
        GameCtrl.minedMoneyMine01 = minedMoney01;
        yield return WaitingTime();
    }
}
