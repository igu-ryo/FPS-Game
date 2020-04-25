using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody rb;
    //プレイヤーの移動速度
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        this.rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = 0;
        float vertical = 0;
        if (Input.GetKey(KeyCode.F)) horizontal = 1;
        if (Input.GetKey(KeyCode.S)) horizontal = -1;
        if (Input.GetKey(KeyCode.E)) vertical = 1;
        if (Input.GetKey(KeyCode.D)) vertical = -1;
        //カメラの向きのy成分を除いた単位ベクトル
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));
        //カメラの向きと方向キーから移動方向の単位ベクトルを決める
        Vector3 moveForward = (cameraForward * vertical + Camera.main.transform.right * horizontal).normalized;
        //移動方向にスピードを掛け、y方向の速度は触らない
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        //プレイヤーの向きを進行方向に
        if(moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
