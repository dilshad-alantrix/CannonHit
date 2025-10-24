using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakble : MonoBehaviour
{
    [SerializeField] private GameObject orgObject;
    [SerializeField] private GameObject brokObject;

    private BoxCollider collider;

    void Awake()
    {
        orgObject.SetActive(true);
        brokObject.SetActive(false);
        collider = GetComponent<BoxCollider>();
    }



    public void Break()
    {
        orgObject.SetActive(false);
        brokObject.SetActive(true);
         Invoke("onDesableColider", 0.5f);
        //Invoke("destroy", 4f);
    }

    private void onDesableColider()
    {
        collider.enabled = false;
    }

    private void destroy()
    {
        Destroy(gameObject);
    }



}
