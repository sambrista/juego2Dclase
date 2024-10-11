using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int pointsToFinish;
    int pointsEarned;
    GameObject[] gems;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;
    public TMP_Text gameResultText;
    // Start is called before the first frame update
    void Start()
    {
        pointsToFinish = 0;
        gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach (GameObject gem in gems) {
            pointsToFinish += gem.GetComponent<Gem>().worth;
        }
        pointsEarned = 0;
        Gem.OnGemCollect += IncreasePointsEarned;
        PlayerHealth.OnPlayerDied += FinishGame;
    }

    void IncreasePointsEarned(int amount) {
        pointsEarned += amount;
        if (pointsEarned == pointsToFinish) {
            SoundEffectManager.playGameWinSound();
            scoreText.text = "Score: " + pointsEarned + " / " + pointsToFinish;
            gameResultText.text = "YOU WIN!";
            MusicManager.PauseMusic();
            gameOverScreen.SetActive(true);
        }
    }
    
    void FinishGame() {
        SoundEffectManager.playGameLostSound();
        scoreText.text = "Score: " + pointsEarned + " / " + pointsToFinish;
        gameResultText.text = "YOU LOST!";
        MusicManager.PauseMusic();
        gameOverScreen.SetActive(true);
    }


    public void PlayAgain() {
        MusicManager.ResetBackgroundMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}