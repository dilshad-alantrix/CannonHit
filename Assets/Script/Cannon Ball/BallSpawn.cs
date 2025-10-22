using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private float spawnDistance = 1.5f;
    [SerializeField] private float shootForce = 10f;
    private Pool<Ball> ballPool = new Pool<Ball>();
    void Start()
    {
        ballPool.Obj = ballPrefab;
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
        Vector3 spowPoint = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;
        
        Ball ball = ballPool.GetObj();
        ball.transform.position = spowPoint;
        ball.Init((b) => ballPool.SetObj(b));

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(ray.direction * shootForce,ForceMode.VelocityChange);
    }
}
