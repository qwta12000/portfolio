using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombCtl : MonoBehaviour
{
    private EnemyMap enemymap;
    private GameObject exp;
    private GameObject chekhit;
    
    private int xnode = 0;
    private int znode = 0;

    private bool chek_f = true;
    private bool chek_b = true;
    private bool chek_r = true;
    private bool chek_l = true;
    private float bomdesTime = 0.4f;
    //private bool scale_chek = false;
    private float scale = 0.0f;
    private bool chek_bom = false;
    private Sound_Mgr soundmgr;



    private void Start()
    {
        chekhit = Resources.Load("chekhit") as GameObject;
        enemymap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        exp = Resources.Load("explosion") as GameObject;
        xnode = enemymap.getxnode();
        znode = enemymap.getznode();
        soundmgr = GameObject.Find("sound").GetComponent<Sound_Mgr>();
        bomb_manege();

    }

    private void Update()
    {
        if (chek_bom == true)
        {
            bombscale();
        }
    }

    public void bombscale()
    {
        if (this.transform.localScale.x < 25.0f)// && scale_chek == false)
        {
            scale = scale + 0.0007f;
            this.transform.localScale += new Vector3(scale, scale, scale);
            //if (this.transform.localScale.x > 24.9f)
            //{
            //    scale_chek = true;
            //}
        }
        //else
        //{
        //    scale = scale + 0.001f;
        //    this.transform.localScale += new Vector3(-scale, -scale, -scale);
        //    if (this.transform.localScale.x < 20.0f)
        //    {
        //        scale_chek = false;
        //    }
        //}
    }


    public void bomb_manege()
    {
        chek_bom = true;
        Destroy(this.gameObject, 2.0f);
    }

    private void OnDestroy()
    {
        
        soundmgr.explotion_sound(); //테질때 사운드
        chek_bom = false;
        Mapclass bom_pos = enemymap.worldposition(transform.position);        
        Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);

        if(bom_pos.chek_player_1)
        {
            PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
            p_ctrl.chek_bom_hit();
        }
        else if(bom_pos.chek_player_2)
        {
            PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
            p_ctrl.chek_bom_hit();
        }
        else if(bom_pos.chek_player_3)
        {
            PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_3").GetComponent<PlayerCrash>();
            p_ctrl.chek_bom_hit();
        }

        for (int i = 0; i <= MgerClass.InstFunc.power; i++)
        {
            chek_f_func(bom_pos.list_x, bom_pos.list_z + 1 + i);
            chek_b_func(bom_pos.list_x, bom_pos.list_z - 1 - i);
            chek_r_func(bom_pos.list_x + 1 + i, bom_pos.list_z);
            chek_l_func(bom_pos.list_x - 1 - i, bom_pos.list_z);
        }
        chek_f = true;
        chek_b = true;
        chek_r = true;
        chek_l = true;
        
    }


    public void chek_f_func(int x, int z)
    {
        if (chek_f == true && x > 0 && x < xnode -1 && z > 0 && z < znode -1)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                chek_f = false;
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                chek_f = false;
                
                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_enemy_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_3 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_4 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_5 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_6 == true)
            {
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_7 == true)
            {
                chek_f = false;
                return;
            }
            else if (newpos.chek_enemy_8 == true)
            {
                chek_f = false;
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                boss_jumpAtk bossatk = GameObject.FindGameObjectWithTag("bossAtk").GetComponent<boss_jumpAtk>();
                bossatk.destoy_obj();
                return;
            }
            else if (newpos.chek_boss == true)
            {
                chek_f = false;
                BossCtrl boss = GameObject.FindGameObjectWithTag("boss").GetComponent<BossCtrl>();
                boss.chekdie();
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_f = false;
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_f = false;
                return;
            }
            else if (newpos.chek_player_3 == true)
            {
                chek_f = false;

                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }
        }
    }
    public void chek_b_func(int x, int z)
    {
        if (chek_b == true && x > 0 && x < xnode - 1 && z > 0 && z < znode - 1)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                chek_b = false;
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                chek_b = false;
                

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_enemy_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_3 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_4 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_5 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_6 == true)
            {
                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_7 == true)
            {
                chek_b = false;
                return;
            }
            else if (newpos.chek_enemy_8 == true)
            {
                chek_b = false;
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                boss_jumpAtk bossatk = GameObject.FindGameObjectWithTag("bossAtk").GetComponent<boss_jumpAtk>();
                bossatk.destoy_obj();
                return;
            }
            else if (newpos.chek_boss == true)
            {
                chek_b = false;
                BossCtrl boss = GameObject.FindGameObjectWithTag("boss").GetComponent<BossCtrl>();
                boss.chekdie();
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_b = false;
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_b = false;

                return;
            }
            else if (newpos.chek_player_3 == true)
            {

                chek_b = false;

                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }
        }
    }
    public void chek_r_func(int x,int z)
    {
        if (chek_r == true && x > 0 && x < xnode - 1 && z > 0 && z < znode - 1)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                chek_r = false;
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                chek_r = false;
                
                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_enemy_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_3 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_4 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_5 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_6 == true)
            {
                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_7 == true)
            {
                chek_r = false;
                return;
            }
            else if (newpos.chek_enemy_8 == true)
            {
                chek_r = false;
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                boss_jumpAtk bossatk = GameObject.FindGameObjectWithTag("bossAtk").GetComponent<boss_jumpAtk>();
                bossatk.destoy_obj();

                return;
            }
            else if (newpos.chek_boss == true)
            {
                chek_r = false;
                BossCtrl boss = GameObject.FindGameObjectWithTag("boss").GetComponent<BossCtrl>();
                boss.chekdie();
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_r = false;
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_r = false;

                return;
            }
            else if (newpos.chek_player_3 == true)
            {
                chek_r = false;

                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }
        }
    }
    public void chek_l_func(int x, int z)
    {
        if (chek_l == true && x > 0 && x < xnode - 1 && z > 0 && z < znode - 1)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                chek_l = false;
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                chek_l = false;
                
                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_enemy_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_3 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_4 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_5 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_6 == true)
            {
                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_7 == true)
            {
                chek_l = false;
                return;
            }
            else if (newpos.chek_enemy_8 == true)
            {
                chek_l = false;
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                boss_jumpAtk bossatk = GameObject.FindGameObjectWithTag("bossAtk").GetComponent<boss_jumpAtk>();
                bossatk.destoy_obj();
                return;
            }
            else if (newpos.chek_boss == true)
            {
                chek_l = false;
                BossCtrl boss = GameObject.FindGameObjectWithTag("boss").GetComponent<BossCtrl>();
                boss.chekdie();
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_l = false;
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                chek_l = false;

                return;
            }
            else if (newpos.chek_player_3 == true)
            {
                chek_l = false;

                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "explotion")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "player_1"||other.tag == "player_2" || other.tag == "plaeyr_3")
        {
            this.GetComponent<Collider>().isTrigger = false;
        }
    }
}
