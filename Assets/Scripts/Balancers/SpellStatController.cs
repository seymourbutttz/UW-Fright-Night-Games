using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class SpellStatController : MonoBehaviour
{
    // Controller for balancing the stats of the available spells

    public TMP_Text meteorText;
    public GameObject meteor; //meteor prefab

    //path of asset to re-create
    private string spellPath = "Assets/Prefabs/Towers/MeteorShower.prefab";
    private string meteorPath = "Assets/Prefabs/Projectiles/Meteor.prefab";

    //modifies the cost of a spell
    public void meteorCost(string spellCost)
    {
        int.TryParse(spellCost, out int Cost); //convert string to int
        //GetComponentInParent<SetStats>().spell1.GetComponent<Spells>().cost = Cost; //sets current cost of tower to new cost

        // Load the contents of the Prefab Asset.
        GameObject spell = PrefabUtility.LoadPrefabContents(spellPath);
        // Modify Prefab contents.
        spell.GetComponent<Spells>().cost = Cost;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(spell, spellPath, out bool success);
        PrefabUtility.UnloadPrefabContents(spell);

        meteorText.text = "Meteor" + "\n" + "Shower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //modifies how fast meteors spawn
    public void spawnRate(string spawntime)
    {
        float.TryParse(spawntime, out float spawnT); //converts string to float
        //GetComponentInParent<SetStats>().spell1.GetComponent<MeteorShower>().timeBetweenMeteors = spawnT; //sets spawn rate of meteors to prefab

        // Load the contents of the Prefab Asset.
        GameObject spell = PrefabUtility.LoadPrefabContents(spellPath);
        // Modify Prefab contents.
        spell.GetComponent<MeteorShower>().timeBetweenMeteors = spawnT;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(spell, spellPath, out bool success);
        PrefabUtility.UnloadPrefabContents(spell);
    }

    //modifies meteor damage
    public void meteorDamage(string metDam)
    {
        float.TryParse(metDam, out float damage);
        //meteor.GetComponent<Meteors>().damageAmount = damage;

        // Load the contents of the Prefab Asset.
        GameObject meteor = PrefabUtility.LoadPrefabContents(meteorPath);
        // Modify Prefab contents.
        meteor.GetComponent<Meteors>().damageAmount = damage;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(meteor, meteorPath, out bool success);
        PrefabUtility.UnloadPrefabContents(meteor);
    }

    //modifies meteor blast radius
    public void meteorBlast(string blast)
    {
        float.TryParse(blast, out float Blast); //converts string to float
        //meteor.GetComponent<Meteors>().blastRadius = Blast; //sets prefabs new blast radius

        // Load the contents of the Prefab Asset.
        GameObject meteor = PrefabUtility.LoadPrefabContents(meteorPath);
        // Modify Prefab contents.
        meteor.GetComponent<Meteors>().blastRadius = Blast;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(meteor, meteorPath, out bool success);
        PrefabUtility.UnloadPrefabContents(meteor);
    }

    //modifies spawn quantity
    public void spawnQuantity(string quantity)
    {
        int.TryParse(quantity, out int quant); //converts string to integer
        //GetComponentInParent<SetStats>().spell1.GetComponent<MeteorShower>().amountToSpawn = quant; //sets spawn quantity for amount of meteors to spawn

        // Load the contents of the Prefab Asset.
        GameObject spell = PrefabUtility.LoadPrefabContents(spellPath);
        // Modify Prefab contents.
        spell.GetComponent<MeteorShower>().amountToSpawn = quant;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(spell, spellPath, out bool success);
        PrefabUtility.UnloadPrefabContents(spell);
    }

    //changes drop speed of meteors
    public void dropSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to integer
        //meteor.GetComponent<Meteors>().dropSpeed = Speed; //changes meteor prefab to have new drop speed.

        // Load the contents of the Prefab Asset.
        GameObject meteor = PrefabUtility.LoadPrefabContents(meteorPath);
        // Modify Prefab contents.
        meteor.GetComponent<Meteors>().dropSpeed = Speed;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(meteor, meteorPath, out bool success);
        PrefabUtility.UnloadPrefabContents(meteor);
    }
}
