using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAlien : MonoBehaviour
{
    //script to change stats of the regular sized alien

    public GameObject alienPrefab; //alien prefab to edit

    //changes base movement speed of enemy
    public void movementSpeed(string speed)
    {
        float.TryParse(speed, out float Speed); //converts string to float
        alienPrefab.GetComponent<EnemyController>().moveSpeed = Speed; //changes speed in the prefab
    }

    //changes time between attacks for tall alien
    public void attackTime(string attacks)
    {
        float.TryParse(attacks, out float attackTime); //converts string to float
        alienPrefab.GetComponent<EnemyController>().timeBetweenAttacks = attackTime; //changes time between attacks in the prefab
    }

    //changes damage done by tall alien
    public void attackDamage(string damage)
    {
        float.TryParse(damage, out float attackDamage); //changes prefab damage amount
        alienPrefab.GetComponent<EnemyController>().damagePerAttack = attackDamage; //sets attack damage within prefab
    }

    //changes total health of tall alien
    public void health(string healthAmount)
    {
        int.TryParse(healthAmount, out int Health); //converts string to int
        alienPrefab.GetComponent<EnemyHealthController>().totalHealth = Health; //changes health of prefab
    }

    //changes gold value of tall alien upon death
    public void goldValue(string gold)
    {
        int.TryParse(gold, out int Gold); //converts string to int
        alienPrefab.GetComponent<EnemyHealthController>().moneyOnDeath = Gold; //changes gold upon dealth in prefab
    }

}
