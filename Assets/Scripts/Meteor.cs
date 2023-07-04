using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Meteor : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Offset", Random.Range(0f, 2f));
    }

    
}
