using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bl_color : MonoBehaviour
{
    public Material rend;
    Color rainbow = new Color(1, 1, 1, 1);
    float num = 0.0f;
    float max_num = 255.0f;

    private void sp_Black()
    {
        num = Random.Range(50.0f, 100.0f);
        rainbow = new Color(num / max_num, num / max_num, num / max_num);
        rend.color = rainbow;
    }

    void Update()
    {
        sp_Black();
    }
}
