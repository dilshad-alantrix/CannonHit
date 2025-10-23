using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private float spawnDistance = 1.5f;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private int startingAmmo = 10;
    public TMP_Text text;
    private int currentAmmo;

    private Pool<Ball> ballPool = new Pool<Ball>();
    void Start()
    {
        ballPool.Obj = ballPrefab;
        currentAmmo = startingAmmo;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            currentAmmo--;
            ShootBall();
        }

        text.text = currentAmmo.ToString();
    }

    private void ShootBall()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 spowPoint = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;

        Ball ball = ballPool.GetObj();
        ball.transform.position = spowPoint;
        ball.Init((b) => ballPool.SetObj(b),BarralHit);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(ray.direction * shootForce, ForceMode.VelocityChange);
    }
    
    public void BarralHit(Ball ball)
    {
        currentAmmo += 3;
    }
}
