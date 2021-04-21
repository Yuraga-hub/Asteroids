using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float maxAngSpeed;
    public float maxMoveSpeed;
    
    Gameplay gameplay;
    Rigidbody2D rigidAsteroid;
    


    void Start()
    {
        gameplay = FindObjectOfType<Gameplay>();
    }

    public void StartMove()
    {
        rigidAsteroid = GetComponent<Rigidbody2D>();
        rigidAsteroid.angularVelocity = Random.Range(0, maxAngSpeed);
        rigidAsteroid.AddForce(transform.up * Random.Range(-maxMoveSpeed, maxMoveSpeed));
    }
    

   

    public void BreakAsteroid()
    {
        gameplay.audioManager.BreakAsteroidPlayAudio();
        if(tag.Equals("BigAsteroid")){
            gameplay.fxManager.OnBigEffect(transform.position);
            gameplay.spawnerAsteroids.RemoveBigAsteroid(gameObject);
            gameplay.spawnerAsteroids.SpawnSmallAsteroid(transform.position + Vector3.up);
            gameplay.spawnerAsteroids.SpawnSmallAsteroid(transform.position - Vector3.up);
            gameplay.IncrementAsteroid();
            gameplay.IncrementScore();
        }
        else
        {
            gameplay.fxManager.OnSmallEffect(transform.position);
            gameplay.spawnerAsteroids.RemoveSmallAsteroid(gameObject);
            gameplay.DecrementAsteroids();
            gameplay.IncrementScore();
        }
    }

    private void FixedUpdate() {
        gameplay.CheckPosition(transform);
    }


}
