using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroids : MonoBehaviour
{
    public PoolManager poolManagerBigAsteroid;
    public PoolManager poolManagerSmallAsteroid;
    public float posValue;
    public float angleValue;
  

    public void InitSizePools(int countWave){
        poolManagerBigAsteroid.poolSize = countWave;
        poolManagerSmallAsteroid.poolSize = countWave*2;
    }

    public void SpawnBigAsteroid(){
        var spawnPosition = new Vector3(Random.Range(-posValue,posValue),Random.Range(-posValue,posValue),0f);
        var spawnRotate = Quaternion.Euler(0,0,Random.Range(-angleValue,angleValue));
        GameObject prefab = poolManagerBigAsteroid.GetObjFromPool(spawnPosition,spawnRotate);
        prefab.GetComponent<Asteroid>().StartMove();
    }


    public void SpawnSmallAsteroid(Vector3 spawnPosition){
        var spawnRotate = Quaternion.Euler(0,0,Random.Range(-angleValue,angleValue));
        GameObject prefab = poolManagerSmallAsteroid.GetObjFromPool(spawnPosition,spawnRotate);
        prefab.GetComponent<Asteroid>().StartMove();
    }



    public void RemoveBigAsteroid(GameObject bigAsteroids){
        poolManagerBigAsteroid.ReturnObjToPool(bigAsteroids);
    }

    public void RemoveSmallAsteroid(GameObject smallAsteroids){
        poolManagerSmallAsteroid.ReturnObjToPool(smallAsteroids);
    }


}
