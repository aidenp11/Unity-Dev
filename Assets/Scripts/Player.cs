using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    private int score = 0;
    private float health = 100;
    public int Score
    { 
        get { return score; }
        set { score = value; scoreText.text = score.ToString(); } 
    }

    public void AddPoint(int points)
    {
        Score += points;
    }
}
