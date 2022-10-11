using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleNavMeshPlayerController : MonoBehaviour
{

    public NavMeshAgent agent;
    private Transform point;
    // Update is called once per frame
    void Update()
    {
        point = GameObject.FindGameObjectWithTag("EndPoint").transform;
        //Ray ray = Camera.main.ScreenPointToRay(point.position);
        agent.SetDestination(point.position);

        if (transform.position == point.position)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ping!");
        if (other.tag == "EndPoint")
        {
            ObjectPool.SharedInstance.DestroyObject(gameObject);
            ObjectPool.SharedInstance.SpawnObject();
        }
    }
}
