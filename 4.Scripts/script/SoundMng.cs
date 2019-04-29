using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{
    public AudioClip BGM;
    public AudioClip BtnClick;
    public AudioClip BtnError;
    public AudioClip BtnCancel;
    public AudioClip BtnSuccess;
    private AudioSource mySource;

    private void Awake()
    {
        mySource = GetComponent<AudioSource>();
    }

    public void BtnClick_Sound()
    {
        mySource.PlayOneShot(BtnClick);
    }

    public void Btn_Cancel()
    {
        mySource.PlayOneShot(BtnCancel);
    }

    public void Btn_Error()
    {
        mySource.PlayOneShot(BtnError);
    }

    public void Btn_Success()
    {
        mySource.PlayOneShot(BtnSuccess);
    }

    private void Update()
    {
        if(mySource.isPlaying == false)
        {
            mySource.clip = BGM;
            mySource.Play();
        }
    }
}
