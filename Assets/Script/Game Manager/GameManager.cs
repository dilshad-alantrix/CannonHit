using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : Subject
{
    public static GameManager Instance;
    public GameState CurrentGameState { get; private set; }
    [SerializeField] private Button startButton;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
       startButton.onClick.AddListener(StartGame);
    }
    void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
    }
    private void Start()
    {
        CurrentGameState = GameState.Home;
        NotifyObservers(CurrentGameState);
        Debug.Log("Game State: " + CurrentGameState);
    }
    private void StartGame()
    {
        CurrentGameState = GameState.Start;
        NotifyObservers(CurrentGameState);
        Debug.Log("Game State: " + CurrentGameState);
         
        CurrentGameState = GameState.Playing;
        NotifyObservers(CurrentGameState);
         Debug.Log("Game State: " + CurrentGameState);
    }
   
}
