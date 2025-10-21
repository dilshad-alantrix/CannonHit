using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Desable());
    }

    IEnumerator Desable()
    {
        yield return new WaitForSecondsRealtime(2f);
        gameObject.SetActive(false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    // SendBackToPool(this);
}
