using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private bool reachedDestination;
    private float targetHealth;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(targetHealth);

        reachedDestination = GetComponent<EnemyController>().reachedEnd;
        targetHealth = GetComponent<EnemyController>().theCastle.currentHealth;

        if (reachedDestination)
        {
            anim.SetBool("atTarget", true);
        }
        if(targetHealth <= 0)
        {
            anim.SetBool("targetDead", true);
        }
        


    }
}
