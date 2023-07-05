using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] GameManager gm;

    [SerializeField] ParticleSystem greenParticles;
    [SerializeField] ParticleSystem redParticles;
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
            if (gm.StarsAmount == gm.StarsInLevel)
                greenParticles.Play();
            else
                redParticles.Play();
        }
    }


}
