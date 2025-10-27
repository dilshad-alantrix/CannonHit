using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GameCamera"))
        {
            animator.enabled = true;
        }
    }
}
