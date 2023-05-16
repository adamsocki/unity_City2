using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateInstance : MonoBehaviour
{
    public GameState CurrentState { get; private set; }
    public static GameStateInstance Instance { get; private set; }
    public TimeManager timeManager;


    public ExecutionManager executionManager;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        OnStateChanged();
    }


    private void OnStateChanged()
    {
        // Handle state changes, e.g., enable/disable UI elements, pause/unpause the game, etc.
        switch (CurrentState)
        {
            case GameState.MainMenu:
                // Show main menu UI and pause the game
                break;
            case GameState.Playing:
                // Hide all menus and resume the game
                executionManager.UpdateExecutionManager();
                break;
            case GameState.Paused:
                // Show pause menu and pause the game
                executionManager.UpdateExecutionManager();
                break;
            case GameState.GameOver:
                // Show game over screen and pause the game
                break;
                // Handle other states as needed
        }

    }


    public void TogglePauseGame()
    {
        if (Instance.CurrentState == GameState.Playing)
        {
            Instance.CurrentState = GameState.Paused;
            Time.timeScale = 0;
            // Show pause menu or perform other pause-related actions
        }
        else if (Instance.CurrentState == GameState.Paused)
        {
            Instance.CurrentState = GameState.Playing;
            Time.timeScale = 1;
            // Hide pause menu or perform other resume-related actions
        }
    }

}
