using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score, highscore;

    public float currentTime;

    [SerializeField] private float startTime;

    public bool gameStarted;

    private UIController uiController;


    private void Awake()
    {
        DeleteHighscore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        highscore = GetScore();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void SaveScore()
    {
        if(score > highscore)
        {
        highscore = score;
        //PlayerPrefs é uma funcionalidade da Unity qye salva permanentemente um atributo
        PlayerPrefs.SetInt("highscore", highscore);
        }
        else
        {
            return;
        }
    }

    public int GetScore()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }

    public void DeleteHighscore()
    {
        PlayerPrefs.DeleteKey("highscore");
    }

    public void InvokeCountdownTime()
    {
        InvokeRepeating("CountDownTime", 1f, 1f);
    }

    public void StartGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountdownTime();
    }

    public void BackMainMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountDownTime");
    }

    public void CountDownTime()
    {
        if(currentTime > 0f && gameStarted)
        {
            currentTime -= 1f;
        }

        else
        {
            uiController.panelGameOver.gameObject.SetActive(true);
            uiController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            currentTime = 0f;
            SaveScore();
            CancelInvoke("CountdownTime");
            return;
        }
        
    }
}
