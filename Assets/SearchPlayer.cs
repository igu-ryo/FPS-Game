using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour {
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.GetComponent<Enemy>().enemyState = "chase";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.GetComponent<Enemy>().destPos = enemy.GetComponent<Enemy>().GetDestinationPos();
            enemy.GetComponent<Enemy>().enemyState = "patrol";
        }
    }

    GameObject enemy;

    // Use this for initialization
    void Start () {
        enemy = transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
