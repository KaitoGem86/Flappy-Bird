using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverScore;
    [SerializeField] TMP_Text highestScore;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text currentLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScore.SetText("Score: " + DataManager.Points);
        highestScore.SetText("Highest Score: " + DataManager.HighestPoint);
        gameOverPanel.SetActive(true);
    }

    public void UpdatePoint()
    {
        score.SetText("Score: " + GameManager.instance.bird.Point);
    }

    public void UpdateLevel()
    {
        currentLevel.SetText(GameManager.instance.data.name);
    }
}
