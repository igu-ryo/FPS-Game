using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

    Rigidbody enemyRb;

    GameObject destination;
    GameObject[] destinationList;

    public Vector3 destPos;

    public float moveSpeed;

    Vector3 moveForward;

    float distance = 2f;
    //目的地の個数
    int destinationLength = 0;

    int destinationNumber;

    float elapsedTime = 0;

    public float waitTime;

    float escapeTime = 0;

    public string enemyState = "patrol";

    public Vector3 GetDestinationPos()
    {
        if (destinationLength == 0)
        {
            return transform.position;
        }
        else
        {
            destinationNumber = Random.Range(1, destinationLength + 1);
            destination = GameObject.Find(string.Format("Destination ({0})", destinationNumber));

            return destination.transform.position;
        }
    }

    void Move()
    {
        //敵を始点とする、目的地を示す単位ベクトルのy成分を除いたもの
        moveForward = Vector3.Scale(destPos - transform.position, new Vector3(1, 0, 1)).normalized;

        //移動方向にスピードを掛け、y方向の速度は触らない
        enemyRb.velocity = moveForward * moveSpeed + new Vector3(0, enemyRb.velocity.y, 0);

        //敵の向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    // Use this for initialization
    void Start () {
        destinationList = GameObject.FindGameObjectsWithTag("Destination");
        destinationLength = destinationList.Length;

        enemyRb = GetComponent<Rigidbody>();

        //目的地の座標を取得
        destPos = GetDestinationPos();
    }
	
	void Update () {
        if (enemyState == "patrol")
        {
            //敵と目的地の距離がごくわずかになったら止まる
            if ((destPos - transform.position).magnitude > distance)
            {
                Move();
            }
            else
            {
                enemyRb.velocity = Vector3.zero;
                elapsedTime += Time.deltaTime;
            }
            if (elapsedTime > waitTime)
            {
                elapsedTime = 0;
                destPos = GetDestinationPos();
            }
        }
        else if(enemyState == "chase")
        {
            destination = GameObject.Find("Player");
            destPos = destination.transform.position;
            Move();
        }
    }
}
