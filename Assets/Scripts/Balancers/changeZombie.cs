using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class changeZombie : MonoBehaviour
{
    //script to change stats of the regular sized alien

    public GameObject zombiePrefab; //alien prefab to edit

    //path of asset to re-create
    private string zombiePath = "Assets/Prefabs/Enemies/Zombie.prefab";

    //changes base movement speed of enemy
    public void movementSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to float
        //zombiePrefab.GetComponent<EnemyController>().moveSpeed = Speed; //changes speed in the prefab

        // Load the contents of the Prefab Asset.
        GameObject zombie = PrefabUtility.LoadPrefabContents(zombiePath);
        // Modify Prefab contents.
        zombie.GetComponent<EnemyController>().moveSpeed = Speed;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(zombie, zombiePath, out bool success);
        PrefabUtility.UnloadPrefabContents(zombie);
    }

    //changes time between attacks for tall alien
    public void attackTime(string attacks)
    {
        float.TryParse(attacks, out float attackTime); //converts string to float
        //zombiePrefab.GetComponent<EnemyController>().timeBetweenAttacks = attackTime; //changes time between attacks in the prefab

        // Load the contents of the Prefab Asset.
        GameObject zombie = PrefabUtility.LoadPrefabContents(zombiePath);
        // Modify Prefab contents.
        zombie.GetComponent<EnemyController>().timeBetweenAttacks = attackTime;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(zombie, zombiePath, out bool success);
        PrefabUtility.UnloadPrefabContents(zombie);
    }

    //changes damage done by tall alien
    public void attackDamage(string damage)
    {
        float.TryParse(damage, out float attackDamage); //changes prefab damage amount
        //zombiePrefab.GetComponent<EnemyController>().damagePerAttack = attackDamage; //sets attack damage within prefab

        // Load the contents of the Prefab Asset.
        GameObject zombie = PrefabUtility.LoadPrefabContents(zombiePath);
        // Modify Prefab contents.
        zombie.GetComponent<EnemyController>().damagePerAttack = attackDamage;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(zombie, zombiePath, out bool success);
        PrefabUtility.UnloadPrefabContents(zombie);
    }

    //changes total health of tall alien
    public void health(string healthAmount)
    {
        int.TryParse(healthAmount, out int Health); //converts string to int
        //zombiePrefab.GetComponent<EnemyHealthController>().totalHealth = Health; //changes health of prefab

        // Load the contents of the Prefab Asset.
        GameObject zombie = PrefabUtility.LoadPrefabContents(zombiePath);
        // Modify Prefab contents.
        zombie.GetComponent<EnemyHealthController>().totalHealth = Health;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(zombie, zombiePath, out bool success);
        PrefabUtility.UnloadPrefabContents(zombie);
    }

    //changes gold value of tall alien upon death
    public void goldValue(string gold)
    {
        int.TryParse(gold, out int Gold); //converts string to int
        //zombiePrefab.GetComponent<EnemyHealthController>().moneyOnDeath = Gold; //changes gold upon dealth in prefab

        // Load the contents of the Prefab Asset.
        GameObject zombie = PrefabUtility.LoadPrefabContents(zombiePath);
        // Modify Prefab contents.
        zombie.GetComponent<EnemyHealthController>().moneyOnDeath = Gold;
        // Save contents back to Prefab Asset and unload contents.
        PrefabUtility.SaveAsPrefabAsset(zombie, zombiePath, out bool success);
        PrefabUtility.UnloadPrefabContents(zombie);
    }

}
