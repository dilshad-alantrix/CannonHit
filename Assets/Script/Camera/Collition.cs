using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Collide");
        }
         
    }
}
