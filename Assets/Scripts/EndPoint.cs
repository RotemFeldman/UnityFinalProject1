using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public UIManager UI;

    public ParticleSystem greenParticles;
    public ParticleSystem redParticles;
    // Start is called before the first frame update
    void Start()
    {       
        greenParticles.Stop();
        redParticles.Stop();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (UI.coinsAmount == UI.coinsInLevel)
                greenParticles.Play();
            else
                redParticles.Play();
        }
    }


}
