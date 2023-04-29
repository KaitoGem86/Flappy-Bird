using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public BirdController bird;
    [SerializeField] private AudioClip flyClip;
    [SerializeField] private AudioClip gameOverClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private LevelList levelList;


    public LevelData data;


    public int levelIndex;

    private void Awake()
    {
        instance = this; 
    }

    public void Start()
    {
        audioSource.clip = flyClip;
        levelIndex = 0;
        SetLevelData();
        Debug.Log(levelList.levels[levelIndex].name);
        Debug.Log(levelList.levels[levelIndex].rateTime);
    }


    public void GameOver()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
        Time.timeScale = 0.0f;
        DataManager.Points = bird.Point;
        if(DataManager.Points > DataManager.HighestPoint)
            DataManager.HighestPoint = DataManager.Points;
        UIManager.instance.GameOver();
    }


    public void GainPoin()
    {
        SetLevelData();
        bird.GainPoint();
        UIManager.instance.UpdatePoint();
    }

    public void Fly()
    {
        if(audioSource.clip == flyClip)
            audioSource.Play();
    }

    private void SetLevelData()
    {
        data = levelList.levels[levelIndex];
        if(bird.Point > (levelIndex+1) * 10 - 2)
        {
            if (levelIndex < 4)
                levelIndex++;
        }
        UIManager.instance.UpdateLevel();
    }
}
