using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCtrl_6 : MonoBehaviour
{
    private int randItem = 0;

    private GameObject power = null;
    private GameObject speed = null;
    private GameObject count = null;


    private void Start()
    {
        power = Resources.Load("power") as GameObject;
        speed = Resources.Load("speed") as GameObject;
        count = Resources.Load("count") as GameObject;

    }
    public void itemCtrl()
    {

        randItem = Random.Range(1, 20);

        switch (randItem)
        {
            case 1:
                {
                    Instantiate(power, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
                    break;
                }
            case 11:
                {
                    Instantiate(speed, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
                    break;
                }
            case 19:
                {
                    Instantiate(count, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
                    break;
                }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hit_box")
        {
            //Debug.Log("trigger");
            Destroy(this.gameObject);

            itemCtrl();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "hit_box")
        {

            Destroy(this.gameObject);

            itemCtrl();
        }
    }
}
