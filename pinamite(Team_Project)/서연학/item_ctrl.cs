using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_ctrl : MonoBehaviour
{
    float rotation = 0.0f;
    bool ck_position = false;

    private void FixedUpdate()
    {
        rotation = rotation + 2;
        if (this.transform.position.y < 4.0f && ck_position == false)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            this.transform.rotation = Quaternion.Euler(rotation, 90, 90);
        }
        else
        {
            ck_position = true;

            this.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
            this.transform.rotation = Quaternion.Euler(rotation, 90, 90);

            if (this.transform.position.y <= 1.5f)
            {
                ck_position = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "explotion")
        {
            Destroy(this.gameObject);
        }
    }
}
