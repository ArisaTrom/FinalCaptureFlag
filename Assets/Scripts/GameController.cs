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
    private Dictionary gameDictionary;
    public CanvasGroup achievements;
    private int maxFlagCount;
    public SimpleTimer simpleTimer;
    public Text doodoo;

    private int playerFlag;

    private void Start()
    {
        simpleTimer = GetComponent<SimpleTimer>();
        gameView = GetComponentInChildren<GameView>();
        gameDictionary = GetComponent<Dictionary>();
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

        doodoo.text = gameDictionary.displayAchievement(0);
        StartCoroutine(waitForSeconds());
        StartCoroutine(backwardsWaitForSeconds());

    }

    IEnumerator waitForSeconds()
    {
        for (float i = 0; i < 1; i += 0.01f)
        {
            yield return new WaitForSeconds(0.005f);
            achievements.alpha = i;
        }
    }
    
    IEnumerator backwardsWaitForSeconds()
    {
        yield return new WaitForSeconds(1.5f);
        for (float i = 1; i > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.0125f);
            achievements.alpha = i;
        }
    }

    private void OnGameLost()
    {
        gameState = GameStates.GameLost;
        // Set the text value of our result text
        gameView.resultText.text = "You Lose.";
        //Hide count and timer text
        gameView.countText.gameObject.SetActive(false);
        gameView.timerText.gameObject.SetActive(false);

        switch (playerFlag)
        {
            case 0:
                doodoo.text = gameDictionary.displayAchievement(1);
                break;
            case 1:
            case 2:
                doodoo.text = gameDictionary.displayAchievement(2);
                break;
        }
        StartCoroutine(waitForSeconds());
        StartCoroutine(backwardsWaitForSeconds());
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

    public void OnFlagCollectible(int playerFlagCount)
    {
        gameView.SetCountText(playerFlagCount);
        playerFlag = playerFlagCount;
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
