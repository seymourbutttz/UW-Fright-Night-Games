using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellStatController : MonoBehaviour
{
    // Controller for balancing the stats of the available spells

    public TMP_Text meteorText;
    public GameObject meteor; //meteor prefab


    //modifies the cost of a spell
    public void meteorCost(string spellCost)
    {
        int.TryParse(spellCost, out int Cost); //convert string to int
        GetComponentInParent<SetStats>().spell1.GetComponent<Spells>().cost = Cost; //sets current cost of tower to new cost
        meteorText.text = "Pumpkin" + "\n" + "Tower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //modifies how fast meteors spawn
    public void spawnRate(string spawntime)
    {
        float.TryParse(spawntime, out float spawnT); //converts string to float
        GetComponentInParent<SetStats>().spell1.GetComponent<MeteorShower>().timeBetweenMeteors = spawnT; //sets spawn rate of meteors to prefab
    }

    //modifies meteor damage
    public void meteorDamage(string metDam)
    {
        float.TryParse(metDam, out float damage);
        meteor.GetComponent<Meteors>().damageAmount = damage;
    }

    //modifies meteor blast radius
    public void meteorBlast(string blast)
    {
        float.TryParse(blast, out float Blast); //converts string to float
        meteor.GetComponent<Meteors>().blastRadius = Blast; //sets prefabs new blast radius
    }

    //modifies spawn quantity
    public void spawnQuantity(string quantity)
    {
        int.TryParse(quantity, out int quant); //converts string to integer
        GetComponentInParent<SetStats>().spell1.GetComponent<MeteorShower>().amountToSpawn = quant; //sets spawn quantity for amount of meteors to spawn
    }

    //changes drop speed of meteors
    public void dropSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to integer
        meteor.GetComponent<Meteors>().dropSpeed = Speed; //changes meteor prefab to have new drop speed.
    }
}
