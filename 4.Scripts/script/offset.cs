using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offset : MonoBehaviour
{
    public float speed = 0.1f;
    private Material thisMaterial;

    public void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 newOffset = thisMaterial.mainTextureOffset;
        newOffset.Set(newOffset.x + (speed * Time.deltaTime), 0);
        thisMaterial.mainTextureOffset = newOffset;
    }
}
