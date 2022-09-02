using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public Transform[] camPosition;
    public Camera cam;
    Vector3 positions;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "BarrierR":
                //positions = cam.transform.position + new Vector3(30, 0, 0);
                cam.transform.position = cam.transform.position + new Vector3(30, 0, 0);
                Debug.Log("Right barrier");
                break;
            case "BarrierL":
                positions = cam.transform.position + new Vector3(-30, 0, 0);
                cam.transform.position = positions;
                Debug.Log("Left barrier");
                break;
            case "BarrierU":
                positions = cam.transform.position + new Vector3(0, 15, 0);
                cam.transform.position = positions;
                Debug.Log("Upper  barrier");
                break;
            case "BarrierD":
                positions = cam.transform.position + new Vector3(0, -15, 0);
                cam.transform.position = positions;
                Debug.Log("Lower barrier");
                break;
        }
        /*
        if (collision.gameObject.CompareTag("BarrierR"))
        {
            positions = cam.transform.position + new Vector3(30, 0, 0);
            cam.transform.position = positions;
        } 
        if (collision.gameObject.CompareTag("BarrierL"))
        {
            positions = cam.transform.position + new Vector3(-30, 0, 0);
            cam.transform.position = positions;
        }
        if (collision.gameObject.CompareTag("BarrierU"))
        {
            positions = cam.transform.position + new Vector3(0, 15, 0);
            cam.transform.position = positions;
        }
        if (collision.gameObject.CompareTag("BarrierD"))
        {
            positions = cam.transform.position + new Vector3(0, -15, 0);
            cam.transform.position = positions;
        }
        */

    }
    
}
