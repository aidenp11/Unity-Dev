using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;
    [SerializeField] VoidEvent onWinEvent = default;

    // Start is called before the first frame update
    private int score = 0;
    //private float health = 100;

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }

    private void Start()
    {
        health.value = 50;
    }
    public int Score
    { 
        get { return score; }
        set {
            score = value; 
            scoreText.text = score.ToString();
            scoreEvent.RaiseEvent(score);
        } 
    }

    public void AddPoint(int points)
    {

        Score += points;

        if (Score == 5)
        {
            onWinEvent.RaiseEvent();
        }
    }

    private void OnStartGame()
    {
        characterController.enabled = true;
        Score = 0;
    }

    public void Damage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
        }
    }

    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;

        characterController.Reset();
    }
}
