using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    //  爆炸
    public GameObject explosion;
    //  飞船爆炸
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("找不到‘GameController’");
        }
    }

    //  当行星发生碰撞时，销毁。Destroy不会马上销毁指定的对象，而是将它们标记为要被销毁的对象，所有被标记的对象会在每一帧结束时销毁
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if (explosion != null)
        {
            Debug.Log("执行了");
            //  行星或者敌机的爆炸效果
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            //  飞船的爆炸效果  
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(scoreValue);
        //  销毁碰撞行星的物体
        Destroy(other.gameObject);
        //  销毁行星
        Destroy(gameObject);
    }


}
