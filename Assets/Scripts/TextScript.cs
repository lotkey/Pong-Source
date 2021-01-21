using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour // script for updating text fields on screen
{
    public Text enemyScore;
    public Text playerScore;

    // Start is called before the first frame update
    void Start()
    {
        enemyScore.text = "Enemy: 0";
        playerScore.text = "Player: 0";
    }

    public void UpdateEnemyScore(int score)
    {
        enemyScore.text = $"Enemy: {score}";
    }
    public void UpdatePlayerScore(int score)
    {
        playerScore.text = $"Player: {score}";
    }
}
