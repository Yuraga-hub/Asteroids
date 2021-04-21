using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource shootAudio;
    public AudioSource breakAsteroidAudio;
    public AudioSource deathAudio;
    
    public void ShootPlayAudio() => shootAudio.Play();
    public void DeathPlayAudio() => deathAudio.Play();
    public void BreakAsteroidPlayAudio() => breakAsteroidAudio.Play();
}
