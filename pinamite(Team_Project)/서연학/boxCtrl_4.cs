using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCtrl_4 : MonoBehaviour
{
    private int randItem = 0;

    private GameObject power = null;
    private GameObject speed = null;
    private GameObject count = null;
    private GameObject boxEft;


    private void Start()
    {
        power = Resources.Load("power") as GameObject;
        speed = Resources.Load("speed") as GameObject;
        count = Resources.Load("count") as GameObject;
        boxEft = Resources.Load("box_bomeft") as GameObject;

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
            Destroy(Instantiate(boxEft, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.Euler(90, 0, 0)), 1.5f);
            Destroy(this.gameObject);

            UI_mger.box_gold += 50;
            itemCtrl();
        }
    }
}
