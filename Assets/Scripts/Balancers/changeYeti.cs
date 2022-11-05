using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class changeYeti : MonoBehaviour
{
    //script to change stats of the regular sized alien

    public GameObject yetiPrefab; //alien prefab to edit
#if UNITY_EDITOR
    //path of asset to re-create
    private string yetiPath = "Assets/Prefabs/Enemies/Enemy (Big Yeti).prefab";
#endif
    //changes base movement speed of enemy
    public void movementSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to float
        yetiPrefab.GetComponent<EnemyController>().moveSpeed = Speed; //changes speed in the prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject yeti = PrefabUtility.LoadPrefabContents(yetiPath);
        // Modify Prefab contents.
        yeti.GetComponent<EnemyController>().moveSpeed = Speed;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(yeti, yetiPath, out bool success);
        PrefabUtility.UnloadPrefabContents(yeti);
#endif
    }

    //changes time between attacks for tall alien
    public void attackTime(string attacks)
    {
        float.TryParse(attacks, out float attackTime); //converts string to float
        yetiPrefab.GetComponent<EnemyController>().timeBetweenAttacks = attackTime; //changes time between attacks in the prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject yeti = PrefabUtility.LoadPrefabContents(yetiPath);
        // Modify Prefab contents.
        yeti.GetComponent<EnemyController>().timeBetweenAttacks = attackTime;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(yeti, yetiPath, out bool success);
        PrefabUtility.UnloadPrefabContents(yeti);
#endif
    }

    //changes damage done by tall alien
    public void attackDamage(string damage)
    {
        float.TryParse(damage, out float attackDamage); //changes prefab damage amount
        yetiPrefab.GetComponent<EnemyController>().damagePerAttack = attackDamage; //sets attack damage within prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject yeti = PrefabUtility.LoadPrefabContents(yetiPath);
        // Modify Prefab contents.
        yeti.GetComponent<EnemyController>().damagePerAttack = attackDamage;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(yeti, yetiPath, out bool success);
        PrefabUtility.UnloadPrefabContents(yeti);
#endif
    }

    //changes total health of tall alien
    public void health(string healthAmount)
    {
        int.TryParse(healthAmount, out int Health); //converts string to int
        yetiPrefab.GetComponent<EnemyHealthController>().totalHealth = Health; //changes health of prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject yeti = PrefabUtility.LoadPrefabContents(yetiPath);
        // Modify Prefab contents.
        yeti.GetComponent<EnemyHealthController>().totalHealth = Health;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(yeti, yetiPath, out bool success);
        PrefabUtility.UnloadPrefabContents(yeti);
#endif
    }

    //changes gold value of tall alien upon death
    public void goldValue(string gold)
    {
        int.TryParse(gold, out int Gold); //converts string to int
        yetiPrefab.GetComponent<EnemyHealthController>().moneyOnDeath = Gold; //changes gold upon dealth in prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject yeti = PrefabUtility.LoadPrefabContents(yetiPath);
        // Modify Prefab contents.
        yeti.GetComponent<EnemyHealthController>().moneyOnDeath = Gold;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(yeti, yetiPath, out bool success);
        PrefabUtility.UnloadPrefabContents(yeti);
#endif
    }

}
