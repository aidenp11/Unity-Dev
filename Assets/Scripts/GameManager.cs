using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] GameObject respawn;

    [SerializeField] FloatVariable health;
    [Header("Events")]
   // [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gamestartEvent; 
    [SerializeField] GameObjectEvent respawnEvent; 


    public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER
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
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                Timer = 60;
                Lives = 3;
                health.value = 100;
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
        state = State.START_GAME;
    }

    public void OnAddPoint(int points)
    {
        print(points);
    }
}
