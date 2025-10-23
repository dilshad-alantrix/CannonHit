using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private float explosionForce = 10f;
    [SerializeField] ParticleSystem explosinEffect;
    private Action<Ball> returnToPool;
    private Action<Ball> onBarralHit;
    
    public void Init(Action<Ball> onReturn,Action<Ball> onBarralHit)
    {
        returnToPool = onReturn;
        this.onBarralHit = onBarralHit;
        
    }

    void OnCollisionEnter(Collision collision)
    {  

        explosion();
    }


    private void explosion()
    {
       
        Instantiate(explosinEffect, transform.position, quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var obj in colliders)
        {
            Breakble breakble = obj.GetComponent<Breakble>();
            if (breakble != null)
            {
                breakble.Break();
            }
            
            if(obj.CompareTag("Barrel"))
            {
                onBarralHit?.Invoke(this);
            }

            Rigidbody _rb = obj.GetComponent<Rigidbody>();
            if (_rb != null)
            {
                _rb.AddExplosionForce(explosionForce, transform.position, radius);
                Debug.Log("work");
            }
        }

        transform.rotation = Quaternion.identity;
        returnToPool?.Invoke(this);
    }

}
