using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //坦克销毁后0.167秒销毁爆炸特效
        Destroy(gameObject,0.167f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
