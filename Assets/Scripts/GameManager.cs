using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool gameIsStarted;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public Text percents;
    public TextMeshProUGUI nextLevelText;
    public int progress;
    public static int countOfPassedCircles;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;

    public static bool inCompleted;
    public static bool mute;
    public static int score;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        CharacterSelector.selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
    }
    void Start()
    {
        gameIsStarted = false;
        gameOver = levelCompleted = false;
        countOfPassedCircles = 0;
        highestScoreText.text = "Best score: " + PlayerPrefs.GetInt("HighScore", 0);
        Time.timeScale = 1;
    }

    void Update()
    {
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        if (!inCompleted)
        {
            progress = (countOfPassedCircles) * 100 / (((FindObjectOfType<MakeCircle>().countOfCircles * 12 - MakeCircle.countOfSetActive - 10)));
            gameProgressSlider.value = progress;
        }

        scoreText.text = score.ToString();


        // start level

        // for PC
        /*if(Input.GetMouseButton(0) && !gameIsStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            gameIsStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }*/

        // for mobile
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began && !gameIsStarted)
        {
            if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            gameIsStarted=true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);

        }

        if (gameOver)
        {
            PlayerPrefs.SetInt("SelectedCharacter", CharacterSelector.selectedCharacter);
            percents.text = progress.ToString() + "% completed";
            
            Time.timeScale = 0;
            if (Input.GetButtonUp("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                    PlayerPrefs.SetInt("HighScore", score);
                score = 0;
                SceneManager.LoadScene("Level");
                MakeCircle.countOfSetActive = 0;
            }
            gameOverPanel.SetActive(true);
            BrakeCircle.countOfBrakeParts = 0;
        }



        if (levelCompleted)
        {
            PlayerPrefs.SetInt("SelectedCharacter", CharacterSelector.selectedCharacter);
            if (score > PlayerPrefs.GetInt("HighScore", 0))
                PlayerPrefs.SetInt("HighScore", score);
            MakeCircle.countOfSetActive = 0;
            inCompleted = true;
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                inCompleted = false;
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene("Level");
            }
        }
        

    }

    public void ResetLevel()
    {
        currentLevelIndex = 1;
        PlayerPrefs.DeleteAll();
        highestScoreText.text = "Best score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}
