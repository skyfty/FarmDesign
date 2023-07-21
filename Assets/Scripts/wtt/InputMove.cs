using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : MonoBehaviour
{
    private Transform cameraMainTrans;
    public float xZSpeed=0.5f;
    public float ySpeed=3;
    private void Start()
    {
        cameraMainTrans = Camera.main.transform;
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y=0;
        if (Input.GetKey(KeyCode.Space)) {
            y += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            y -= Time.deltaTime;
        }
        cameraMainTrans.position += new Vector3(x*xZSpeed, y*ySpeed, z* xZSpeed);
    }
}
