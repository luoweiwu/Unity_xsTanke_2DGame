using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    //属性值
    public int lifeVale = 3;
    public int playerScore = 0;
    public bool isDead=false;
    public bool isDefeat;

    //引用
    public GameObject born;

    //单例
    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    public void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead)
        {
            Recover();
        }
	}

    private void Recover()
    {
        if (lifeVale < 0)
        {
            //游戏失败，返回主界面

            SceneManager.LoadScene("Game");
        }
        else
        {
            lifeVale--;
            GameObject go = Instantiate(born,new Vector3(-2,-8,0),Quaternion.identity);
            go.GetComponent<Born>().createPlay = true;
            isDead = false;
        }
    }
}
