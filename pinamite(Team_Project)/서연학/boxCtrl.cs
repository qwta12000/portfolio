using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCtrl : MonoBehaviour
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
            case 15:
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


            //for (float i = 2.0f; i >= 0; i -= Time.deltaTime * 0.2f)
            //{
            //    Color color = new Vector4(1, 1, 1, i);
            //    this.transform.GetComponent<Renderer>().material.color = color;

            //    if (i <= 0.1f)
            //    {
            //        Destroy(this.gameObject);
            //    }
            //}
            Destroy(this.gameObject,0.2f);

            UI_mger.box_gold += 50;   
            itemCtrl();
            StartCoroutine(collboxdes());

        }
    }

    IEnumerator collboxdes()
    {
        for (float alpha = 1.0f; alpha >= 0; alpha -= Time.deltaTime * 0.4f)
        {
            Color color = new Vector4(1, 1, 1, alpha);
            this.transform.GetComponent<Renderer>().material.color = color;

            if (alpha <= 0.1f)
            {
                Destroy(this.gameObject);
            }
            yield return 0;
        }
        //for (float i = 1.0f; i >= 0; i -= Time.deltaTime * 0.4f)
        //{
        //    Color color = new Vector4(1, 1, 1, i);
        //    this.transform.GetComponent<Renderer>().material.color = color;

        //    if (i <= 0.1f)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
        yield return null;
    }
}
