using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDeath;
    SpawnerBullet spawnerBullet;
    float timer;

    void Start () {
        spawnerBullet = FindObjectOfType<SpawnerBullet>();
    }
    public void StartMove(){
        timer = timeDeath;
        GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
    }

    private void Update() {
        timer-= Time.deltaTime;
        if(timer <= 0){
            timer = timeDeath;
            spawnerBullet.RemoveBullet(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("BigAsteroid")){
            spawnerBullet.RemoveBullet(gameObject);
            other.GetComponent<Asteroid>().BreakAsteroid();
        }
        if(other.tag.Equals("SmallAsteroid")){
            spawnerBullet.RemoveBullet(gameObject);
            other.GetComponent<Asteroid>().BreakAsteroid();
        }
    }
 

}
