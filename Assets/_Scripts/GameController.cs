using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //  障碍物
    public GameObject hazard;
    public Vector3 spawnValue;
    //  每一波行星的个数
    public int spawnCount;
    //  每两个行星之间的时间间隔
    public float spawnWait;
    //  开始生成行星的等待时间
    public float startWait;
    //  每两波行星之间的时间间隔
    public float waveWait;

    public Text scoreText;
    private int score;

    public Text restartText, gameOverText;
    public bool restart, gameOver;

    void Start()
    {
        restart = false;
        gameOver = false;
        restartText.text = "";
        gameOverText.text = "";


        score = 0;
        UpdateScore();
        //  协同
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        //  等待startWait秒后开始生成行星
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                //  不旋转
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                //  等待spawnWait秒后生成下一个行星
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver == true)
            {
                restartText.text = "按下'R'键重新开始";
                restart = true;
            }
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
