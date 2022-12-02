using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public enum GameStates
    {
        GamePlaying,
        GameWon,
        GameLost
    };
    private GameView gameView;
    private GameStates gameState;
    private int maxFlagCount;
    public SimpleTimer simpleTimer;

    private void Start()
    {
        simpleTimer = GetComponent<SimpleTimer>();
        gameView = GetComponentInChildren<GameView>();
        gameState = GameStates.GamePlaying;
        maxFlagCount = GameObject.FindGameObjectsWithTag("Flag").Length;
    }
    
    private void OnGameWon()
    {
        gameState = GameStates.GameWon;
        // Set the text value of our result text
        gameView.resultText.text = "You Win!";
        //Hide count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);
    }

    private void OnGameLost()
    {
        gameState = GameStates.GameLost;
        // Set the text value of our result text
        gameView.resultText.text = "You Lose.";
        //Hide count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);
    }

    public void StateUpdate(GameStates newState)
    {
        //Exit condition- if the game is not in play, we cannot advance to win or lose
        if (gameState != GameStates.GamePlaying)
        {
            return;
        }
        
        switch (newState)
        {
            case GameStates.GamePlaying:
                break;
            case GameStates.GameWon:
                gameState = GameStates.GameWon;
                OnGameWon();
                break;
            case GameStates.GameLost:
                gameState = GameStates.GameLost;
                OnGameLost();
                break;
        }
    }

    public void OnPickUpCollectible(int playerFlagCount)
    {
        gameView.SetCountText(playerFlagCount);
        // Check if our 'count' is equal to or exceeded our maxCollectibles count
        if (playerFlagCount >= maxFlagCount) 
        {
            StateUpdate(GameStates.GameWon);
        }
    }

    public void UpdateGameTimer(int timerCount)
    {
        gameView.SetTimerText(timerCount);
    }

    
}