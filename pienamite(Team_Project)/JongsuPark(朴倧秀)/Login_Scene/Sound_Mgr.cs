using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Mgr : MonoBehaviour
{
    public AudioClip bom_explotion;
    public AudioClip bom_sound;
    public AudioClip stage;
    public AudioClip player_die;
    public AudioClip player_clear;
    public AudioClip player_crash;
    public AudioClip plaeyr_restart;
    public AudioClip item_sound;
    public AudioClip roketexp;
    public AudioClip roketfound;


    private AudioSource mysource;


    private void Awake()
    {
        
        mysource = GetComponent<AudioSource>();
    }

    public void stage_1_sound(int chek)
    {
        if (chek == 1)
        {
            mysource.clip = stage;
            mysource.loop = true;
            mysource.Play();
        }
        else if (chek == 2)
        {
            mysource.Stop();
        }


    }

    public void roketexpotion()
    {
        mysource.PlayOneShot(roketexp);
    }

    public void roket_roundert()
    {
        mysource.PlayOneShot(roketfound);
    }

    public void explotion_sound()
    {
        mysource.PlayOneShot(bom_explotion);
    }
    
    public void bomb_sound()
    {
        mysource.PlayOneShot(bom_sound);
    }

    public void playerdie_sound()
    {
        mysource.PlayOneShot(player_die);
    }

    public void playercrash_sound()
    {
        mysource.PlayOneShot(player_crash);
    }

    public void playerclaer_sound()
    {
        mysource.PlayOneShot(player_clear);
    }

    public void playerrestart_sound()
    {
        mysource.PlayOneShot(plaeyr_restart);
    }

    public void playeritem_sound()
    {
        mysource.PlayOneShot(item_sound);
    }

   
}
