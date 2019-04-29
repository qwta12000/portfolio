using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_shidround : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
        //transform.RotateAround(boss.transform.position, Vector3.right, 10 * Time.deltaTime);
    }
}
