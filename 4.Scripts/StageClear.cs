using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public GameObject dice_1;
    public GameObject dice_2;
    public GameObject dice_3;
    public GameObject dice_4;
    public GameObject dice_5;
    public GameObject dice_6;


    public GameObject clear_1;
    public GameObject clear_2;
    public GameObject clear_3;
    public GameObject clear_4;
    public GameObject clear_5;
    public GameObject clear_6;

    private bool chekdice_1 = false;
    private bool chekdice_2 = false;
    private bool chekdice_3 = false;
    private bool chekdice_4 = false;
    private bool chekdice_5 = false;
    private bool chekdice_6 = false;


    public bool dice_1_func(bool dice)
    {
        chekdice_1 = dice;
        return chekdice_1;
    }

    public bool dice_2_func(bool dice)
    {
        chekdice_2 = dice;
        return chekdice_2;
    }

    public bool dice_3_func(bool dice)
    {
        chekdice_3 = dice;
        return chekdice_3;
    }

    public bool chek_4_func(bool dice)
    {
        chekdice_4 = dice;
        return chekdice_4;
    }

    public bool chek_5_func(bool dice)
    {
        chekdice_5 = dice;
        return chekdice_5;
    }

    public bool chek_6_func(bool dice)
    {
        chekdice_6 = dice;
        return chekdice_6;
    }


    public void clearAnimation()
    {
        
    }
}
