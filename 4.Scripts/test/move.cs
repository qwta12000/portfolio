using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = (Vector3.forward * v) + (Vector3.right * h);

        transform.Translate(move * 5 * Time.deltaTime);

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100f * Input.GetAxis("Mouse X"));
        }

    }
}
