using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour {
    public GameObject bulletPrefab;

    public float moveSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = Camera.main.transform.position;
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
            bulletRb.velocity = (Camera.main.ScreenToWorldPoint(mousePos) - Camera.main.transform.position) * moveSpeed;
        }
	}
}
