using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCtrl_2 : MonoBehaviour
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


    IEnumerator chektime()
    {
        yield return new WaitForSeconds(0.1f);
        itemCtrl();
    }



    void itemCtrl()
    {
        randItem = Random.Range(1, 15);
        switch (randItem)
        {
            case 1:
                {
                    Instantiate(power, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
                    break;
                }
            case 7:
                {
                    Instantiate(speed, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity);
                    break;
                }
            case 14:
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

            Destroy(gameObject);

            Destroy(Instantiate(Resources.Load("GenericDeath") as GameObject, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.Euler(-90.0f,0f,0f)), 1.5f);
            UI_mger.box_gold += 50;
            itemCtrl();
        }
    }
}
