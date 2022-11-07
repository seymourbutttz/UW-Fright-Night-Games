using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteors : MonoBehaviour
{
    public Rigidbody rigidBody; //body of meteor
    public float dropSpeed; //speed of the meteors

    public GameObject impact; //impact effect of meteors

    public float damageAmount; //damage of meteor

    public float blastRadius; //radius of meteor blast damage

    //private bool hasDamaged;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.forward * dropSpeed; //assigns movement to meteor

        //AudioManager.instance.PlaySFX(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, blastRadius); //looks for all colliders in range of the meteor
        
        foreach (Collider col in collidersInRange) //looks at all colliders within range
        {
            //Debug.Log(col.tag);
            if (col.tag == "Enemy" || col.tag == "Boss") //if collider is an enemy the enemy takes damage
            {
                col.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
                //Debug.Log(col.GetComponent<EnemyHealthController>().healthBar.value);
            }
        }

        Instantiate(impact, transform.position, Quaternion.identity); //generates impact effect

        AudioManager.instance.PlaySFX(6); //generates explosion audio
        Debug.Log("play audio");
        Destroy(gameObject); //destroys meteor
    }
}
