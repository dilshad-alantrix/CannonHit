using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collition : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
          StartCoroutine(GameOverDelay());
        }
    }
    
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1f);
        gameManager.GameOver();
    }
}
