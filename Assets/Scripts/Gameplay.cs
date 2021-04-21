using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public Camera mainCam;
    public SaveManager saveManager;
    public UIManager gui;
    public AudioManager audioManager;
    public FxManager fxManager;
    public SpawnerAsteroids spawnerAsteroids;
    public int maxCountWave;
    
    //for core game
    int score;
    int record;
    int asteroidsLive;
    int lives;
    int waveForView;
    int wave;
    int increaseEachWave;
    
    //for moving
    float sceneWidth;
    float sceneHeight;
    float sceneRightEdge;
    float sceneLeftEdge;
    float sceneTopEdge;
    float sceneBottomEdge;


    private void Awake() {
        spawnerAsteroids.InitSizePools(maxCountWave);
    }

    void Start()
    {
        InitGame();
        InitSizeScreen();
    }


    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void InitGame()
    {
        record = saveManager.record;
        score = 0;
        wave = 1;
        waveForView = 1;
        lives = 3;

        gui.UpdateScore("Score:" + score);
        gui.UpdateRecord("Record: " + record);
        gui.UpdateLives("Lives: " + lives);
        gui.UpdateWave("Wave: " + wave);

        SpawnAsteroid();
    }

    void SpawnAsteroid()
    {

        DestroyAllAsteroids();
        asteroidsLive = wave + increaseEachWave;
        for (int i = 0; i < asteroidsLive; i++)
        {
            spawnerAsteroids.SpawnBigAsteroid();
        }
        gui.UpdateWave("Wave: " + waveForView);
    }

    public void IncrementScore()
    {
        score++;
        gui.UpdateScore("Score:" + score);

        CheckRecord();
        CheckCompleteWave();
    }

    public void CheckRecord(){
        if (score > record)
        {
            record = score;
            gui.UpdateRecord("Record: " + record);
            saveManager.record = record;
            saveManager.SaveStats();
        }
    }

    public void CheckCompleteWave(){
        if (asteroidsLive == 0)
        {
            waveForView++;
            wave++;
            if(waveForView > maxCountWave)
                wave = maxCountWave;
            SpawnAsteroid();
        }
    }

    public void LoseLive()
    {
        lives--;
        gui.UpdateLives("Lives: " + lives);
        if (lives == 0)
            InitGame();
    }

    public void DecrementAsteroids() => asteroidsLive--;

    public void IncrementAsteroid() => asteroidsLive ++;
    

    void DestroyAllAsteroids()
    {
        GameObject[] allBigAsteroids  = GameObject.FindGameObjectsWithTag("BigAsteroid");
        foreach (var item in allBigAsteroids)
        {
            spawnerAsteroids.RemoveBigAsteroid(item);
        }

        GameObject[] allSmallAsteroids  = GameObject.FindGameObjectsWithTag("SmallAsteroid");
        foreach (var item in allSmallAsteroids)
        {
            spawnerAsteroids.RemoveBigAsteroid(item);
        }
    }


    private void InitSizeScreen(){
        sceneWidth = mainCam.orthographicSize * 2 * mainCam.aspect;
        sceneHeight = mainCam.orthographicSize * 2;
        sceneRightEdge = sceneWidth / 2;
        sceneLeftEdge = sceneRightEdge * -1;
        sceneTopEdge = sceneHeight / 2;
        sceneBottomEdge = sceneTopEdge * -1;
    }


    public void CheckPosition(Transform target)
    {
        if (target.position.x > sceneRightEdge)
        {
            target.position = new Vector2(sceneLeftEdge, target.position.y);
        }
        if (target.position.x < sceneLeftEdge) { target.position = new Vector2(sceneRightEdge, target.position.y); } if (target.position.y > sceneTopEdge)
        {
            target.position = new Vector2(target.position.x, sceneBottomEdge);
        }
        if (target.position.y < sceneBottomEdge)
        {
            target.position = new Vector2(target.position.x, sceneTopEdge);
        }
    }
}
