using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeStats : MonoBehaviour
{
    public TMP_Text pumpkinText;
   
    //change starting money
    public void startingGold(string gold) //take in text input from stat controller
    {
        int.TryParse(gold, out int Gold); //convert string to int
        MoneyManager.instance.currentMoney = Gold; //sets current gold to new gold value
        UIController.instance.goldText.text = Gold.ToString(); //changes text on gold panel
    }

    //change pumpkin tower cost
    public void pumpkinCost(string cost) //take in text input from stat controller
    {
        int.TryParse(cost, out int Cost); //convert string to int
        GetComponentInParent<SetStats>().projectileTower.GetComponent<Tower>().cost = Cost; //sets current cost of tower to new cost
        pumpkinText.text = "Canon" + "\n" + "Tower" + "\n" + "(" + Cost + "G)"; //sets button text
    }
}
