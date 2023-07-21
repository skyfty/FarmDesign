using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitError : MonoBehaviour
{
    public float distance;
    public float originYOffset = 0;
    private void OnEnable()
    {
        Invoke("Init",0);
    }
    private Ray ray;
    public bool isup;
    public void Init() {
        if (isup) 
            Debug.Log("Run");
        ray = new Ray(transform.position , Vector3.down);
        Confirm(ray);
        ray = new Ray(transform.position + Vector3.up*3, Vector3.down);
        Confirm(ray);
    }
    public void Confirm(Ray ray) {
        RaycastHit hit;
        if (isup) Debug.Log("Run1");
        if (Physics.Raycast(ray, out hit))
        {
            if (isup) Debug.Log("Run2");
            if (hit.transform.name == "Terrain")
            {
                if (isup) Debug.Log("Run3");
                distance = (transform.position - hit.point).magnitude;
                transform.position = hit.point + Vector3.up * originYOffset;

            }
        }
    }
}
