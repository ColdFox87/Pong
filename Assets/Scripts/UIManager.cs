using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject gameOverScreen;
    TMP_Text winner;
    TMP_Text[] score;

    void Awake()
    {
        score = canvas.GetComponentsInChildren<TMP_Text>();
        winner = gameOverScreen.GetComponentsInChildren<TMP_Text>().Where(txt => txt.gameObject.name.Equals("Txt Winner")).ToArray()[0];
    }

    void OnEnable()
    {
        GameEvents.OnScoreChanged += UpdateScore;
        GameEvents.OnGameEnded += GameOver;
    }

    void OnDisable()
    {
        GameEvents.OnScoreChanged -= UpdateScore;
        GameEvents.OnGameEnded -= GameOver;
    }

    void UpdateScore(int[] score)
    {
        this.score[0].text = score[0].ToString();
        this.score[1].text = score[1].ToString();
    }

    void GameOver(int player) {
        winner.text = "P" + player + " WINS"; 
        gameOverScreen.SetActive(true);
    }
}