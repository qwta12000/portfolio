using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mapclass
{

    public int g_cost = 0;
    public int h_cost = 0;
    public int f_cost { get { return g_cost + h_cost; } }

    public Mapclass justpos;

    public int list_x;
    public int list_z;

    public Vector3 worldPos;

    public bool chek_1obs;
    public bool chek_2obs;
    public bool chek_enemy_1;
    public bool chek_enemy_2;
    public bool chek_enemy_3;
    public bool chek_enemy_4;
    public bool chek_enemy_5;
    public bool chek_enemy_6;
    public bool chek_enemy_7;
    public bool chek_enemy_8;
    public bool chek_boss;
    public bool chek_player_1;
    public bool chek_player_2;
    public bool chek_player_3;
    public bool chek_boom;

    public Mapclass(int x,int z,Vector3 pos,bool isobs,bool isobs2,bool enemy_1, 
                        bool enemy_2, bool enemy_3, bool enemy_4, bool enemy_5, bool enemy_6, 
                            bool enemy_7, bool enemy_8, bool boss,bool player_1,bool player_2,bool player_3,bool boom)
    {
        list_x = x;
        list_z = z;
        worldPos = pos;
        chek_1obs = isobs;
        chek_2obs = isobs2;
        chek_enemy_1 = enemy_1;
        chek_enemy_2 = enemy_2;
        chek_enemy_3 = enemy_3;
        chek_enemy_4 = enemy_4;
        chek_enemy_5 = enemy_5;
        chek_enemy_6 = enemy_6;
        chek_enemy_7 = enemy_7;
        chek_enemy_8 = enemy_8;
        chek_boss = boss;
        chek_player_1 = player_1;
        chek_player_2 = player_2;
        chek_player_3 = player_3;
        chek_boom = boom;
    }
}
