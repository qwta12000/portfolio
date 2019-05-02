using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class br_color : MonoBehaviour
{
    public Material rend;
    Color rainbow = new Color(1, 1, 1, 1);
    float num = 150.0f;
    float max_num = 255.0f;

    private void sp_Color()
    {
        num = Random.Range(150.0f, 225.0f);
        rainbow = new Color(0, num / max_num, 0);
        rend.color = rainbow;
    }

    void Update()
    {
        sp_Color();
    }
}
