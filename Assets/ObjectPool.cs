using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        SpawnObjects(amountToPool);
    }


    public void SpawnObjects(int amount)
    {
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, gameObject.transform);
            tmp.transform.position = gameObject.transform.position;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public void SpawnObject()
    {
        GameObject tmp;
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeSelf)
            {
                pooledObjects[i].SetActive(true);
            }
        }
    }

    public void DestroyObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = gameObject.transform.position;
    }
}
