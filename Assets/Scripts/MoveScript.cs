using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Transform moveTrans;
    public float moveSpeed=5;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveTrans.position += new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveTrans.position+= Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveTrans.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
}
