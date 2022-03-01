using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Text textScore;

    [SerializeField]
    private Text textHighScore;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private AudioSource audioSourceAddScore;

    [SerializeField]
    private AudioSource audioSourceLose;

    [SerializeField]
    private AudioSource audioSourceBackground;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public bool isGameOver;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    private void Start()
    {
        audioSourceBackground.Play();
        isGameOver = false;
        gameOver.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }

        textHighScore.text = SaveManager.LoadScore();
    }

    private void Update()
    {
        CheckExitGame();
    }

    private void CheckExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddScore()
    {
        audioSourceAddScore.Play();
        score++;
        textScore.text = score.ToString();
    }

    public void ShowGameOver()
    {
        audioSourceBackground.Stop();
        isGameOver = true;
        audioSourceLose.Play();
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        if (score > Convert.ToInt32(textHighScore.text))
        {
            SaveManager.SaveScore(score);
        }

        SceneManager.LoadScene("Main");
    }    
}