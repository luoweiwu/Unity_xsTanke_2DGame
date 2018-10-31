using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {

    public GameObject playerPrefab;

    public GameObject[] enemyPrefabList;

    //判断是否产生敌人
    public bool createPlay;

	// Use this for initialization
	void Start () {
        Invoke("BornTank",1f);
        Destroy(gameObject,1f);
	}

    private void Update()
    {

    }

    private void BornTank()
    {
        if (createPlay)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemyPrefabList[num], transform.position, Quaternion.identity);
        }
    }
}
