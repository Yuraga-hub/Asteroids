using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public ParticleSystem bigEffect;
    public ParticleSystem smallEffect;


    
    public void OnBigEffect(Vector3 newPosition){
        bigEffect.transform.position = newPosition;
        bigEffect.Play();
    }

    public void OnSmallEffect(Vector3 newPosition){
        smallEffect.transform.position = newPosition;
        smallEffect.Play();
    }
}
