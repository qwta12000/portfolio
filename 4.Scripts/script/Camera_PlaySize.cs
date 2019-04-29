using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_PlaySize : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(Screen.width, (Screen.width / 16) * 9, false);
        Screen.SetResolution(1280,720, false);
    }
}
