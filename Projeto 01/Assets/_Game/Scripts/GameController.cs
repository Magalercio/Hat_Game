using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int score, highscore;

    public float currentTime;

    [SerializeField] private float startTime;
    [SerializeField] private Transform player;
    private Vector2 playerPosition;

    public bool gameStarted;

    private UIController uiController;

    private SpawnControle spawnController;


    private void Awake()
    {
        DeleteHighscore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();
        spawnController = FindObjectOfType<SpawnControle>();
        highscore = GetScore();
        uiController.txtTime.text = currentTime.ToString();
        playerPosition = player.position;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyAllBalls()
    {
        foreach(Transform child in spawnController.allBallsParent)
        {
            Destroy(child.gameObject);
        }
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
        InvokeRepeating("CountDownTime", 0f, 1f);
    }

    public void StartGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountdownTime();
        player.position = playerPosition;
    }

    public void BackMainMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountDownTime");
        player.position = playerPosition;
    }

    public void CountDownTime()
    {

        uiController.txtTime.text = currentTime.ToString();
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
