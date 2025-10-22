using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Action<Ball> returnToPool;

    public void Init(Action<Ball> onReturn)
    {
        returnToPool = onReturn;
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Debug.Log("add ball");
            //Destroy(collision.gameObject);
        }
        
        StartCoroutine(Desable());
    }

    IEnumerator Desable()
    {
        yield return new WaitForSecondsRealtime(2f);

        transform.rotation = Quaternion.identity;
        returnToPool?.Invoke(this);
    }
    
}
