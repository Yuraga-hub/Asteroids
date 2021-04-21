using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : MonoBehaviour
{
    public PoolManager poolManager;
    public Transform gun;
     

    public void SpawnBullet(){
        
        GameObject prefab = poolManager.GetObjFromPool(gun.position,gun.rotation);
        prefab.GetComponent<Bullet>().StartMove();
    }

    public void RemoveBullet(GameObject asteroids){
        poolManager.ReturnObjToPool(asteroids);
    }


}
