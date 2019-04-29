using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_jumpAtk : MonoBehaviour
{
    private Animator anim;
    private float time = 0.0f;
    void Start()
    {
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.4f)
        {
            anim.SetBool("jump", true);
        }
    }

    public void destoy_obj()
    {
        Destroy(this.gameObject);
    }

}
