using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    GameObject targetObj;
    Vector3 targetPos;
    public float cameraSpeed;

	// Use this for initialization
	void Start () {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;

        // プレイヤーと一定距離離れたところにカメラ位置を初期化
        Vector3 cameraDistance = new Vector3(0, 1, 0);
        transform.position = targetPos + cameraDistance;

        // カメラの向きをプレイヤー方向に向ける
        //transform.rotation = Quaternion.LookRotation(targetPos - transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        float horizontal = 0;
        float vertical = 0;
        if (Input.GetKey(KeyCode.L)) horizontal = 1;
        if (Input.GetKey(KeyCode.J)) horizontal = -1;
        if (Input.GetKey(KeyCode.I)) vertical = 1;
        if (Input.GetKey(KeyCode.K)) vertical = -1;
        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, horizontal * cameraSpeed);
        // カメラの垂直移動
        transform.RotateAround(targetPos, transform.right, vertical * cameraSpeed);
    }
}
