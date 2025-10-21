using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float MoveSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 move = new Vector3(0, 0, 1);
        transform.position += move * MoveSpeed * Time.deltaTime;
    }
}
