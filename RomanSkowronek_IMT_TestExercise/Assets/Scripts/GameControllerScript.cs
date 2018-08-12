using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    public float money, minedMoneyMine01, minedMoneyMine02, liftMoney;              //money we currently got, money which was mined by mine 01, money which was mined by mine 02, money in the lift
    public int levelMine01 = 1, levelMine02, levelLift = 1, levelWarehouse = 1;     //current level of the 1st mine, 2nd mine, lift and Warehouse
    int waitingTime;                                                                //time to wait while the workers are working
    int waitingType;                                                                //what type of worker is waiting
    public bool mine02Buyed = false;                                                //if the 2nd mine is already buyed or not
    float mine01Cost = 15, mine02Cost = 25, mine02BuyCost = 100, liftCost = 25, warehouseCost = 25;   //The costs of all upgrades and the new mine shaft
    public Text[] textField;                                                        //Array of all text Fields in the scene
    public GameObject[] buttons;                                                    //Array of all Buttons in the scene
    public float liftWaitingTime = 3, warehouseWaitingTime = 4;                     //to level up the waiting time from the lift and warehouse

    //-----------------------------------------------------------------------Mine 01 Level up Button------------------------------------------------------------------------
    public void Mine01LevelUpBtnPressed()
    {
        //only if it's affordable
        if (money >= mine01Cost)
        {
            levelMine01++;
            money -= mine01Cost;
            mine01Cost *= 1.25f;                                                    //make the next Level up more expensive
            textField[4].text = "Level up " + Mathf.Round(mine01Cost) + "$";
            textField[3].text = "Money: " + Mathf.Round(money) + "$";
        }
    }
    //-----------------------------------------------------------------------Mine 02 Level up Button------------------------------------------------------------------------
    public void Mine02LevelUpBtnPressed()
    {
        //only if it's affordable
        if (money >= mine02Cost)
        {
            levelMine02++;
            money -= mine02Cost;
            mine02Cost *= 1.25f;                                                    //make the next Level up more expensive
            textField[5].text = "Level up " + Mathf.Round(mine02Cost) + "$";
            textField[3].text = "Money: " + Mathf.Round(money) + "$";
        }
    }
    //-----------------------------------------------------------------------Lift Level up Button---------------------------------------------------------------------------
    public void LiftLevelUpBtnPressed()
    {
        //only if it's affordable
        if (money >= liftCost)
        {
            levelLift++;
            money -= liftCost;
            liftCost *= 1.25f;                                                      //make the next Level up more expensive
            textField[6].text = "Level up Lift " + Mathf.Round(liftCost) + "$";
            textField[3].text = "Money: " + Mathf.Round(money) + "$";
            liftWaitingTime /= 1.05f;                                               //if leveled up, make the lift collect faster
        }
    }
    //-----------------------------------------------------------------------Warehouse Level up Button----------------------------------------------------------------------
    public void WarehouseLevelUpBtnPressed()
    {
        //only if it's affordable
        if (money >= warehouseCost)
        {
            levelWarehouse++;
            money -= warehouseCost;
            warehouseCost *= 1.25f;                                                 //make the next Level up more expensive
            textField[7].text = "Level up Lagerhaus " + Mathf.Round(warehouseCost) + "$";
            textField[3].text = "Money: " + Mathf.Round(money) + "$";
            warehouseWaitingTime /= 1.05f;                                          //if leveld up, make the warehouse collect faster
        }
    }
    //-----------------------------------------------------------------------Buy 2nd Mine Button----------------------------------------------------------------------------
    public void BuyMine02BtnPressed()
    {
        //only if it's affordable
        if (money >= mine02BuyCost)
        {
            money -= mine02BuyCost;
            mine02Buyed = true;
            buttons[0].SetActive(false);
            buttons[1].SetActive(true);
            buttons[2].SetActive(true);
            textField[3].text = "Money: " + Mathf.Round(money) + "$";
        }
    }
}
