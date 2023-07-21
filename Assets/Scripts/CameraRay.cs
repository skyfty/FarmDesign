using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public Transform CanvasTrans;
    Ray ray;
    RaycastHit hit;
    public HttpTest httpTest;
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,10000,1<<6))
            {
                Debug.Log(hit.point);
                CanvasTrans.position = hit.point+Vector3.up*0.01f;
                httpTest.X = (int)hit.point.x;
                httpTest.z = (int)hit.point.z;
                foreach (Collider item in Physics.OverlapSphere(hit.point, 6))
                {
                    Debug.Log(item.name);
                    if (item.transform != transform &&item.transform.name!="Terrain")
                    {
                        item.SendMessage("Init");
                    }
                }
            }
        }
    }
}
