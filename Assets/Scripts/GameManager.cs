using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject goUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] List<GameObject> mushrooms;

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
                Lives = 3;
                Timer = 60;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                health.value = 100;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gamestartEvent.RaiseEvent();
                state = State.PLAY_GAME;
                respawnEvent.RaiseEvent(respawn);
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
        }

        healthUI.value = health.value / 100.0f;
    }



    public void ONStartGame()
    {
        state = State.START_GAME;
    }

    public void OnPlayerDead()
    {
        if (Lives <= 0)
        {
            state = State.GAME_OVER;
        }
        else
        {
            Lives -= 1;
            state = State.START_GAME;
        }
    }

    public void OnGameOver()
    {
        for (int i = 0; i < mushrooms.Count; i++)
        {
            mushrooms[i].SetActive(true);
        }

        goUI.SetActive(false);
        state = State.TITLE;
    }

    public void OnAddPoint(int points)
    {
        print(points);
    }
}
