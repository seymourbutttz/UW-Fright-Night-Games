using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public Rigidbody rigidBody; //body of meteor
    public float dropSpeed; //speed of the meteors

    public GameObject impact; //impact effect of meteors

    public float damageAmount; //damage of meteor

    //private bool hasDamaged;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.forward * dropSpeed; //assigns movement to meteor

        //AudioManager.instance.PlaySFX(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")  //&& !hasDamaged
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            //hasDamaged = true;
        }

        Instantiate(impact, transform.position, Quaternion.identity);

        AudioManager.instance.PlaySFX(6);

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
