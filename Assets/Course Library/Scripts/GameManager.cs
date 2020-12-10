using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    int score;
    public ResetEvent resetEvent;
    public bool gameOver;
    bool bgm;
    [SerializeField] Text scoreText;
    [SerializeField] Button restartButton;
    [SerializeField] AudioSource bgmSource;
    private void Start()
    {
        gameOver = false;
        DontDestroyOnLoad(gameObject);
        restartButton.gameObject.SetActive(false);
        resetEvent = new ResetEvent();
        bgm = true;
        
    }


    void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName,LoadSceneMode.Additive);
    }

    public void IncreaseScore()
    {
        score = int.Parse(scoreText.text) + 1;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        restartButton.gameObject.SetActive(true);
    }

    public void Restart()
    {
        gameOver = false;
        resetEvent.Invoke();
        score = 0;
        scoreText.text = score.ToString();


        AsyncOperation ao = SceneManager.UnloadSceneAsync("Main");

        SceneManager.LoadScene("Main", LoadSceneMode.Additive);

        restartButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToggleBGM()
    {
        if (!bgm)
        {
            bgmSource.Play();
        }
        else
        {
            bgmSource.Stop();
        }
        bgm = bgmSource.isPlaying;
    }
}
