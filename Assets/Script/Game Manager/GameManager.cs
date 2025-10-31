using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : Subject
{
    public GameState CurrentGameState { get; private set; }
    [SerializeField] private Button startButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button backButton;
   

    void OnEnable()
    {
        startButton.onClick.AddListener(StartGame);
        nextButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(MenueGame);
        backButton.onClick.AddListener(RestartGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }
    void OnDisable()
    {
        startButton.onClick.RemoveListener(StartGame);
        nextButton.onClick.RemoveListener(RestartGame);
        menuButton.onClick.RemoveListener(MenueGame);
        backButton.onClick.RemoveListener(RestartGame);
        resumeButton.onClick.RemoveListener(ResumeGame);
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

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        CurrentGameState = GameState.Start;
        NotifyObservers(CurrentGameState);
        Debug.Log("Game State: " + CurrentGameState);

        CurrentGameState = GameState.Playing;
        NotifyObservers(CurrentGameState);
        Debug.Log("Game State: " + CurrentGameState);
    }

    private void MenueGame()
    {
        CurrentGameState = GameState.Paused;
        Time.timeScale = 0f;
        NotifyObservers(CurrentGameState);
        Debug.Log("Game State: " + CurrentGameState);
    }
    private void ResumeGame()
    {
        CurrentGameState = GameState.Playing;
        Time.timeScale = 1f;
        NotifyObservers(CurrentGameState);
        Debug.Log("Game State: " + CurrentGameState);
    }
    public void GameOver()
    {
        CurrentGameState = GameState.GameOver;
        NotifyObservers(CurrentGameState);
        Time.timeScale = 0f;
        Debug.Log("Game State: " + CurrentGameState);
    }
    

   
}
