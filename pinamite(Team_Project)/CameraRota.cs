using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRota : MonoBehaviour
{
    private int chekcam = 0;
    
    
    private void Start()
    {
        
        chekcam = PlayerPrefs.GetInt("chekcam");
        
        if (chekcam == 1)
        {
            transform.Rotate(90.0f, 0, 0);
        }
        else if(chekcam == 2)
        {
            transform.Rotate(25.0f, 0, 0);
        }

    }
    void Update()
    {
        //if(chekcam == 2)
        //{
        //    RaycastHit hit;

        //    if(Physics.Raycast(transform.position,Input.mousePosition,out hit, floorMask))
        //    {
        //        Vector3 playerMouse = hit.point - transform.position;
        //    }
        //}
        
    }
}
