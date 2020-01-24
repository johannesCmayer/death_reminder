using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAdjuster : MonoBehaviour
{
    public static ParticleAdjuster instance;
    public ParticleSystem psGood;
    public ParticleSystem psBad;

    bool goodActive = true;
    void Awake()
    {
        instance = this;
    }

    public void EnableParticles(bool good)
    {
        goodActive = good;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goodActive){
            psGood.Emit(1);
        }
        else{
            psBad.Emit(1);
        }
    }
}
