using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleNavMeshPlayerController : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;
    public Transform point;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(point.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

            if (transform.position == point.position)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
