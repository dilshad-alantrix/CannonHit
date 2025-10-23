using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakble : MonoBehaviour
{
    [SerializeField] private GameObject orgObject;
    [SerializeField] private GameObject brokObject;

    void Awake()
    {
        orgObject.SetActive(true);
        brokObject.SetActive(false);
    }



    public void Break()
    {
        orgObject.SetActive(false);
        brokObject.SetActive(true);
        Invoke("destroy", 3f);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }



}
