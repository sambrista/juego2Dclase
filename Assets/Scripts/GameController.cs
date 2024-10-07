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
    }

    void IncreasePointsEarned(int amount) {
        Debug.Log(amount);
        pointsEarned += amount;
        if (pointsEarned >= pointsToFinish) {
            scoreText.text = "Score: " + pointsEarned + " / " + pointsToFinish;
            gameResultText.text = "YOU WIN!";
            gameOverScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}