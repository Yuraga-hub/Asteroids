using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Gameplay gameplay;
    public SpawnerBullet spawnerBullet;
    public AudioManager audioManager;
    public float rotationSpeed = 100.0f;
    public float thrustForce = 3f;
    Rigidbody2D rigidShip;
 
 
    void Start(){
        rigidShip = GetComponent<Rigidbody2D>();
    }
 
    void FixedUpdate () {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        rigidShip.AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));
        gameplay.CheckPosition(transform);
 
    }
    private void Update() {
         if (Input.GetMouseButtonDown (0))
            ShootBullet ();
    }
 
    void OnTriggerEnter2D(Collider2D c){
        if (c.gameObject.tag != "Bullet") {
            gameplay.audioManager.DeathPlayAudio();
            gameplay.fxManager.OnSmallEffect(transform.position);
            gameplay.LoseLive();
            transform.position = new Vector3 (0, 0, 0); 
            GetComponent<Rigidbody2D>().velocity = new Vector3 (0, 0, 0);
        }
    }
    
    
    void ShootBullet(){
        spawnerBullet.SpawnBullet();
        audioManager.ShootPlayAudio();
    }


     
}
