using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UiManager : MonoBehaviour,Iobserver
{
    //public static UiManager Instance;
    [SerializeField] private GameObject homeUI;
    [SerializeField] private GameObject playUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameManager gameManager;

    // void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    void OnEnable()
    {
        gameManager.AddObserver(this);
    }
    void OnDisable()
    {
        gameManager.RemoveObserver(this);
    }   
    public void OnNotify(GameState state)
    {
        if (state == GameState.Home)
        {
            homeUI.SetActive(true);
            playUI.SetActive(false);
            gameOverUI.SetActive(false);
            menuUI.SetActive(false);
        }
        else if (state == GameState.Playing)
        {
            homeUI.SetActive(false);
            playUI.SetActive(true);
            gameOverUI.SetActive(false);
            menuUI.SetActive(false);
        }
        else if (state == GameState.GameOver)
        {
            gameOverUI.SetActive(true);
            playUI.SetActive(false);
            homeUI.SetActive(false);
            menuUI.SetActive(false);
        }
        else if (state == GameState.Paused)
        {
            menuUI.SetActive(true);
            playUI.SetActive(false);
            homeUI.SetActive(false);
            gameOverUI.SetActive(false);
        }
    }
    
}
