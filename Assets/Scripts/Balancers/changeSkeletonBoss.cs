using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class changeSkeletonBoss : MonoBehaviour
{
    //script to change stats of the regular sized alien

    public GameObject skeletonPrefab; //alien prefab to edit
#if UNITY_EDITOR
    //path of asset to re-create
    private string skelBossPath = "Assets/Prefabs/Enemies/Skeleton Boss.prefab";
#endif
    //changes base movement speed of enemy
    public void movementSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to float
        skeletonPrefab.GetComponent<EnemyController>().moveSpeed = Speed; //changes speed in the prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject skelBoss = PrefabUtility.LoadPrefabContents(skelBossPath);
        // Modify Prefab contents.
        skelBoss.GetComponent<EnemyController>().moveSpeed = Speed;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(skelBoss, skelBossPath, out bool success);
        PrefabUtility.UnloadPrefabContents(skelBoss);
#endif
    }

    //changes time between attacks for tall alien
    public void attackTime(string attacks)
    {
        float.TryParse(attacks, out float attackTime); //converts string to float
        skeletonPrefab.GetComponent<EnemyController>().timeBetweenAttacks = attackTime; //changes time between attacks in the prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject skelBoss = PrefabUtility.LoadPrefabContents(skelBossPath);
        // Modify Prefab contents.
        skelBoss.GetComponent<EnemyController>().timeBetweenAttacks = attackTime;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(skelBoss, skelBossPath, out bool success);
        PrefabUtility.UnloadPrefabContents(skelBoss);
#endif
    }

    //changes damage done by tall alien
    public void attackDamage(string damage)
    {
        float.TryParse(damage, out float attackDamage); //changes prefab damage amount
        skeletonPrefab.GetComponent<EnemyController>().damagePerAttack = attackDamage; //sets attack damage within prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject skelBoss = PrefabUtility.LoadPrefabContents(skelBossPath);
        // Modify Prefab contents.
        skelBoss.GetComponent<EnemyController>().damagePerAttack = attackDamage;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(skelBoss, skelBossPath, out bool success);
        PrefabUtility.UnloadPrefabContents(skelBoss);
#endif
    }

    //changes total health of tall alien
    public void health(string healthAmount)
    {
        int.TryParse(healthAmount, out int Health); //converts string to int
        skeletonPrefab.GetComponent<EnemyHealthController>().totalHealth = Health; //changes health of prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject skelBoss = PrefabUtility.LoadPrefabContents(skelBossPath);
        // Modify Prefab contents.
        skelBoss.GetComponent<EnemyHealthController>().totalHealth = Health;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(skelBoss, skelBossPath, out bool success);
        PrefabUtility.UnloadPrefabContents(skelBoss);
#endif
    }

    //changes gold value of tall alien upon death
    public void goldValue(string gold)
    {
        int.TryParse(gold, out int Gold); //converts string to int
        skeletonPrefab.GetComponent<EnemyHealthController>().moneyOnDeath = Gold; //changes gold upon dealth in prefab
#if UNITY_EDITOR
        // Load the contents of the Prefab Asset.
        GameObject skelBoss = PrefabUtility.LoadPrefabContents(skelBossPath);
        // Modify Prefab contents.
        skelBoss.GetComponent<EnemyHealthController>().moneyOnDeath = Gold;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(skelBoss, skelBossPath, out bool success);
        PrefabUtility.UnloadPrefabContents(skelBoss);
#endif
    }

}
