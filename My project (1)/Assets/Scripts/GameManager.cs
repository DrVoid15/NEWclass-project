using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public PlayerController Bean;
    public float time;
    public bool timeActive;

    [Header("Game UI")]
    public TMP_Text gameUI_score;
    public TMP_Text gameUI_health;
    public TMP_Text gameUI_time;

    [Header("CountDown UI")]
    public TMP_Text countdownText;
    public int countdown;

    [Header("End Screen")]
    public TMP_Text endUI_score;
    public TMP_Text endUI_time;

    [Header("Screens")]
    public GameObject countdownUI;
    public GameObject gameUI;
    public GameObject endUI;
      
    // Wow that a lot of words... to bad i'm not reading them.

    // Start is called before the first frame update
    void Start()
    {
        Bean = GameObject.Find("Bean").GetComponent<PlayerController>();

        // make sure the timer is set to 0
        time = 0;

        //disable player movement initially
        Bean.enabled = false;

        // set screen to the countdown
        SetScreen(countdownUI);

        //start coroutine
        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        countdownText.gameObject.SetActive(true);
        countdown = 3;
        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        //enable player movment
        Bean.enabled = true;

        //start the game
        startGame();

    }

    void startGame()
    {
        // set the screen to see your stats
        SetScreen(gameUI);

        // start the timer
        timeActive = true;
    }

     public void endGame()
    {
        // end the timer
        timeActive = false;

        // disable player movment
        Bean.enabled = false;

        // set UI to display your stats
        endUI_score.text = "Score: " + Bean.coincount;
        endUI_time.text = "Time: " + (time * 1).ToString("F2");

       // unlocks the Cursor after trhe game is over 
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SetScreen(endUI);
    }

    public void OnRestartButton()
    {
        // restart the scene to play again
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        // keep trake of the time that goes by
        if (timeActive)
        {
            time = time + Time.deltaTime;
        }

        // set the Ui to display starts
        gameUI_score.text = "Coins: " + Bean.coincount;
        gameUI_health.text = "health: " + Bean.Health;
        gameUI_time.text = "Time: " + (time * 1).ToString("F2");



    }

    public void SetScreen(GameObject screen)
    {
        //disable all other screens
        gameUI.SetActive(false);
        countdownUI.SetActive(false);
        endUI.SetActive(false);

        //activate the requested screen
        screen.SetActive(true);
    }



}


    
