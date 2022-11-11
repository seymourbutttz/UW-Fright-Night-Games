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
#if UNITY_EDITOR
    //path of asset to re-create
    private string spellPath = "Assets/Prefabs/Spells/MeteorShower.prefab";
    private string meteorPath = "Assets/Prefabs/Projectiles/Meteor.prefab";
#endif
    //modifies the cost of a spell
    public void meteorCost(string spellCost)
    {
        int.TryParse(spellCost, out int Cost); //convert string to int
        GetComponentInParent<SetStats>().spell1.GetComponent<Spells>().cost = Cost; //sets current cost of tower to new cost
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject spell = PrefabUtility.LoadPrefabContents(spellPath);
        // Modify Prefab contents.
        spell.GetComponent<Spells>().cost = Cost;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(spell, spellPath, out bool success);
        PrefabUtility.UnloadPrefabContents(spell);
#endif
        meteorText.text = "Meteor" + "\n" + "Shower" + "\n" + "(" + Cost + "G)"; //sets button text
    }

    //modifies how fast meteors spawn
    public void spawnRate(string spawntime)
    {
        float.TryParse(spawntime, out float spawnT); //converts string to float
        GetComponentInParent<SetStats>().spell1.GetComponent<MeteorShower>().timeBetweenMeteors = spawnT; //sets spawn rate of meteors to prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject spell = PrefabUtility.LoadPrefabContents(spellPath);
        // Modify Prefab contents.
        spell.GetComponent<MeteorShower>().timeBetweenMeteors = spawnT;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(spell, spellPath, out bool success);
        PrefabUtility.UnloadPrefabContents(spell);
#endif
    }

    //modifies meteor damage
    public void meteorDamage(string metDam)
    {
        float.TryParse(metDam, out float damage);
        meteor.GetComponent<Meteors>().damageAmount = damage;
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject Meteor = PrefabUtility.LoadPrefabContents(meteorPath);
        // Modify Prefab contents.
        Meteor.GetComponent<Meteors>().damageAmount = damage;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(Meteor, meteorPath, out bool success);
        PrefabUtility.UnloadPrefabContents(Meteor);
#endif
    }

    //modifies meteor blast radius
    public void meteorBlast(string blast)
    {
        float.TryParse(blast, out float Blast); //converts string to float
        meteor.GetComponent<Meteors>().blastRadius = Blast; //sets prefabs new blast radius
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject Meteor = PrefabUtility.LoadPrefabContents(meteorPath);
        // Modify Prefab contents.
        Meteor.GetComponent<Meteors>().blastRadius = Blast;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(Meteor, meteorPath, out bool success);
        PrefabUtility.UnloadPrefabContents(Meteor);
#endif
    }

    //modifies spawn quantity
    public void spawnQuantity(string quantity)
    {
        int.TryParse(quantity, out int quant); //converts string to integer
        GetComponentInParent<SetStats>().spell1.GetComponent<MeteorShower>().amountToSpawn = quant; //sets spawn quantity for amount of meteors to spawn
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject spell = PrefabUtility.LoadPrefabContents(spellPath);
        // Modify Prefab contents.
        spell.GetComponent<MeteorShower>().amountToSpawn = quant;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(spell, spellPath, out bool success);
        PrefabUtility.UnloadPrefabContents(spell);
#endif
    }

    //changes drop speed of meteors
    public void dropSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to integer
        meteor.GetComponent<Meteors>().dropSpeed = Speed; //changes meteor prefab to have new drop speed.
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject Meteor = PrefabUtility.LoadPrefabContents(meteorPath);
        // Modify Prefab contents.
        Meteor.GetComponent<Meteors>().dropSpeed = Speed;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(Meteor, meteorPath, out bool success);
        PrefabUtility.UnloadPrefabContents(Meteor);
#endif
    }
}
