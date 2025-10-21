using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private BallPool ballPool;
    [SerializeField] private float SpawnDistance = 1.5f;
    [SerializeField] private float ShootForce = 10f;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }
    
    private void ShootBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 spowPoint = Camera.main.transform.position + Camera.main.transform.forward * SpawnDistance;
        
        GameObject ball = ballPool.GetObj();
        ball.transform.position = spowPoint;

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(ray.direction * ShootForce,ForceMode.VelocityChange);
    }
}
