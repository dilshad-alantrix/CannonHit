using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Move : MonoBehaviour,Iobserver
{

    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private GameObject HomeCamera;
    [SerializeField] private GameManager gameManager;

     private bool isPlaying;

    public void OnNotify(GameState state)
    {
        if (state == GameState.Playing)
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }

        if(state == GameState.Start)
        {
            HomeCamera.SetActive(false);
        }
    }
    void OnEnable()
    {
        gameManager.AddObserver(this);
    }
    void OnDisable()
    {
        gameManager.RemoveObserver(this);
    }
    void Update()
    {
        if(isPlaying)
        {
            Vector3 move = new Vector3(0, 0, 1);
            transform.position += move * MoveSpeed * Time.deltaTime;
        }

    }

}
