using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //属性值
    public float moveSpeed = 3;
    private Vector3 bullectEulerAugles;
    private float v=-1;
    private float h;

    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite; //上 右 下 左
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;

    //计时器
    public float timeVal;
    public float timeValChangeDirection=0;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //攻击的时间间隔
        if (timeVal >= 0.3f)
        {
            //间隔大于0.4的时候才有攻击效果
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    //坦克的攻击方法
    private void Attack()
    {
         //子弹参数的角度：当前坦克的角度+子弹应该旋转的角度
         Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAugles));
         timeVal = 0;
    }

    //坦克的移动方法
    private void Move()
    {

        if(timeValChangeDirection>=4)
        {
            int num = Random.Range(0,8);
            if(num>5)
            {
                v = -1;
                h = 0;
            }else if (num == 0)
            {
                v = 1;
                h = 0;
            }else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }else if (num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }

        //监听玩家垂直轴输入
      
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAugles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAugles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }

        //监听玩家水平轴输入
     
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAugles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAugles = new Vector3(0, 0, -90);
        }
    }

    //坦克的死亡方法
    private void Die()
    {
        PlayerManager.Instance.playerScore++;
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

    //优化敌人AI
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            timeValChangeDirection = 4;
        }
    }

}

