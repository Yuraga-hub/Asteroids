using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] objPrefabs;
    public int poolSize;
    private Queue<GameObject> objPool;
    void Start()
    {
        objPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject objPrefab = objPrefabs[Random.Range(0,objPrefabs.Length)];
            GameObject newObj = Instantiate(objPrefab);
            objPool.Enqueue(newObj);
            newObj.SetActive(false);
        }
    }

    public GameObject GetObjFromPool(Vector3 newPosition, Quaternion newRotation)
    {
        GameObject newObj = objPool.Dequeue();
        newObj.SetActive(true);
        newObj.transform.SetPositionAndRotation(newPosition,newRotation);

        return newObj;
    }

    public void ReturnObjToPool(GameObject obj)
    {
        obj.SetActive(false);
        objPool.Enqueue(obj);
    }
    
    public void ReturnAll(){
        foreach (var item in objPool)
        {
            ReturnObjToPool(item);
        }
    }

    
    
}
