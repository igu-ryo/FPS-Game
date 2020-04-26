using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject enemyPrefab;

    float limitPos = 45;

    GameObject ground;

    public float waitTime;
    float deltaTime = 0;

    // Use this for initialization
    void Start () {
        ground = GameObject.Find("Ground");
	}
	
	// Update is called once per frame
	void Update () {
        this.deltaTime += Time.deltaTime;
        
        if (this.deltaTime > waitTime)
        {
            this.deltaTime = 0;
            GameObject enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(Random.Range(- limitPos, limitPos) + ground.transform.position.x, 5, Random.Range(-limitPos, limitPos) + ground.transform.position.z);
        }
    }
}
