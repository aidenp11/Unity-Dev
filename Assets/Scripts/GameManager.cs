using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject goUI;
    [SerializeField] GameObject gwUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] GameObject respawn;

    [SerializeField] FloatVariable health;
    [Header("Events")]
   // [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gamestartEvent; 
    [SerializeField] GameObjectEvent respawnEvent;

    [SerializeField] List<GameObject> mushrooms;


    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER,
        GAME_WIN
    }

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;

    public int Lives { get { return lives; } set { lives = value; livesUI.text = "LiXes: " + lives.ToString(); } }

    public float Timer { get { return timer; } set { timer = value; timerUI.text = "Time: " + timer.ToString(); } }

    void Start()
    {
       // scoreEvent.Subscribe(OnAddPoint);
    }

    private void OnEnable()
    {
       // scoreEvent.Subscribe(OnAddPoint);
    }

    private void OnDisable()
    {
       // scoreEvent.UnSubscribe(OnAddPoint);
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                health.value = 100;
                Lives = 5;
                Timer = 120;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gamestartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer < 0) state = State.GAME_OVER;
                break;
            case State.GAME_OVER:
                goUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.GAME_WIN:
                gwUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }

        healthUI.value = health.value / 100.0f;
    }



    public void ONStartGame()
    {
        state = State.START_GAME;
    }

    public void OnPlayerDead()
    {
        Lives--;
        if (Lives <= 0)
        {
            state = State.GAME_OVER;
        }
        else
        {

        state = State.START_GAME;
        }
    }

    public void GOButton()
    {
        goUI.SetActive(false);
        foreach (var mushroom in mushrooms)
        {
            mushroom.SetActive(true);
        }
        state = State.TITLE;
    }

    public void GWButton()
    {
        gwUI.SetActive(false);
        foreach (var mushroom in mushrooms)
        {
            mushroom.SetActive(true);
        }
        state = State.TITLE;
    }

    public void OnWin()
    {
        state = State.GAME_WIN;
    }
    
    public void OnAddPoint(int points)
    {
        //if (points > 0)
        //{
            
        //}
        print(points);
     }
}
