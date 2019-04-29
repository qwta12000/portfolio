using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Color : MonoBehaviour
{
    float random;
    float max_num;
    Color bright = new Color(1, 1, 1, 1);

    void Start()
    {
        max_num = 255.0f;
        random = 0.0f;
        this.GetComponent<Image>().color = new Color();
    }
    private void set_Color()
    {
        random = Random.Range(225.0f, 255.0f);
        bright = new Color(random / max_num, random / max_num, random / max_num);
        this.GetComponent<Image>().color = bright;
    }

    void Update()
    {
        set_Color();
    }
}
