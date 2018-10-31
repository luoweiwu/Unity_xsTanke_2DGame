using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullect : MonoBehaviour {

    public float moveSpeed = 10;

    public bool isPlayerBullect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up*moveSpeed*Time.deltaTime,Space.World);
	}

    //子弹触发碰撞检测
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Tank":
                if(!isPlayerBullect)
                {
                    collision.SendMessage("Die");

                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                SceneManager.LoadScene("Game");
                break;
            case "Enemy":
                if(isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Wall":
                //销毁自身和墙
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
    

}
