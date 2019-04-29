using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roketCtrl : MonoBehaviour
{
    private EnemyMap enemymap;
    private GameObject exp;
    private GameObject chekhit;
    private GameObject bombHit; //폭발전 이펙트

    private int xnode = 0;
    private int znode = 0;

    private float bomdesTime = 0.7f;
    
    private Sound_Mgr soundmgr;
    
    
    private void Start()
    {
        chekhit = Resources.Load("chekhit") as GameObject;
        enemymap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        bombHit = Resources.Load("rocket_hit") as GameObject;
        exp = Resources.Load("boss_exp") as GameObject;
        xnode = enemymap.getxnode();
        znode = enemymap.getznode();
        soundmgr = GameObject.Find("sound").GetComponent<Sound_Mgr>();

        
    }

    private void Update()
    {
        
    }



    public void bomb_manege()
    {
        Mapclass bom_pos = enemymap.worldposition(transform.position);
        GameObject rocket = enemymap.panel_rocket(bom_pos.list_x,bom_pos.list_z);
        rocket.GetComponent<MeshRenderer>().enabled = true;

        chekpos_f_func(bom_pos.list_x, bom_pos.list_z + 2);
        chekpos_b_func(bom_pos.list_x, bom_pos.list_z - 2);
        chekpos_r_func(bom_pos.list_x + 2, bom_pos.list_z);
        chekpos_l_func(bom_pos.list_x - 2, bom_pos.list_z);
        chekpos_fl_func(bom_pos.list_x - 1, bom_pos.list_z + 1);
        chekpos_fr_func(bom_pos.list_x + 1, bom_pos.list_z + 1);
        chekpos_bl_func(bom_pos.list_x + 1, bom_pos.list_z - 1);
        chekpos_br_func(bom_pos.list_x - 1, bom_pos.list_z - 1);
        //Destroy(this.gameObject, 2.9f);
        StartCoroutine(OnDestroyFunc());
        StartCoroutine(bomb_eneble_false());
    }

    public void chekpos_f_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_b_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_r_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_l_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_fl_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_fr_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_bl_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void chekpos_br_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = true;
        }
    }


    IEnumerator bomb_eneble_false()
    {
        yield return new WaitForSeconds(2.0f);
        Mapclass bom_pos = enemymap.worldposition(transform.position);
        GameObject rocket = enemymap.panel_rocket(bom_pos.list_x, bom_pos.list_z);
        rocket.GetComponent<MeshRenderer>().enabled = false;

        chekpos_f_func_false(bom_pos.list_x, bom_pos.list_z + 2);
        chekpos_b_func_false(bom_pos.list_x, bom_pos.list_z - 2);
        chekpos_r_func_false(bom_pos.list_x + 2, bom_pos.list_z);
        chekpos_l_func_false(bom_pos.list_x - 2, bom_pos.list_z);
        chekpos_fl_func_false(bom_pos.list_x - 1, bom_pos.list_z + 1);
        chekpos_fr_func_false(bom_pos.list_x + 1, bom_pos.list_z + 1);
        chekpos_bl_func_false(bom_pos.list_x + 1, bom_pos.list_z - 1);
        chekpos_br_func_false(bom_pos.list_x - 1, bom_pos.list_z - 1);        
    }


    public void chekpos_f_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;          
        }        
    }
    public void chekpos_b_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;           
        }
    }
    public void chekpos_r_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;            
        }
    }
    public void chekpos_l_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;            
        }
    }
    public void chekpos_fl_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;           
        }
    }
    public void chekpos_fr_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;            
        }
    }
    public void chekpos_bl_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void chekpos_br_func_false(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {            
            GameObject rocket = enemymap.panel_rocket(x, z);
            rocket.GetComponent<MeshRenderer>().enabled = false;            
        }
    }





    IEnumerator OnDestroyFunc()
    {
        Mapclass bom_pos = enemymap.worldposition(transform.position);

        yield return new WaitForSeconds(1.0f);

        Destroy(Instantiate(bombHit, new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z), Quaternion.identity), 0.95f);

        yield return new WaitForSeconds(1.0f);

        
        
        Destroy(gameObject);

        soundmgr.roketexpotion(); //테질때 사운드
        Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);

        if (bom_pos.chek_1obs == true)
        {
            Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);

            Destroy(Instantiate(chekhit, bom_pos.worldPos, Quaternion.identity), 0.1f);
            
        }
        else if (bom_pos.chek_2obs == true)
        {
            Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);

            Destroy(Instantiate(chekhit, bom_pos.worldPos, Quaternion.identity), 0.1f);
            
        }
        else if (bom_pos.chek_player_1 == true)
        {
            Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);
            PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
            p_ctrl.chek_bom_hit();
            
        }
        else if (bom_pos.chek_player_2 == true)
        {
            Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);
            PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
            p_ctrl.chek_bom_hit();

            
        }
        else if (bom_pos.chek_player_3 == true)
        {


            
        }
        else
        {
            Destroy(Instantiate(exp, new Vector3(bom_pos.worldPos.x, 2.5f, bom_pos.worldPos.z), Quaternion.identity), bomdesTime);
        }


        chek_f_func(bom_pos.list_x, bom_pos.list_z + 2);
        chek_b_func(bom_pos.list_x, bom_pos.list_z - 2);
        chek_r_func(bom_pos.list_x + 2, bom_pos.list_z);
        chek_l_func(bom_pos.list_x - 2, bom_pos.list_z);

        chek_fl_func(bom_pos.list_x - 1, bom_pos.list_z + 1);
        chek_fr_func(bom_pos.list_x + 1, bom_pos.list_z + 1);
        chek_bl_func(bom_pos.list_x + 1, bom_pos.list_z - 1);
        chek_br_func(bom_pos.list_x - 1, bom_pos.list_z - 1);
        

    }
    public void chek_fl_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);
            
            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

                return;
            }
            else if (newpos.chek_player_3 == true)
            {


                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }

        }
    }                        
    public void chek_fr_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

                return;
            }
            else if (newpos.chek_player_3 == true)
            {


                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }

        }
    }                        
    public void chek_bl_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);


            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

                return;
            }
            else if (newpos.chek_player_3 == true)
            {


                return;
            }
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }

        }
    }                        
    public void chek_br_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_2obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

                return;
            }
            
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }

        }
    }

    public void chek_f_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
            }
            else if (newpos.chek_2obs == true)
            {
                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
          
            else if (newpos.chek_boss == true)
            {
                
                return;
            }
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
          
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
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
            }
            else if (newpos.chek_2obs == true)
            {
                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
           
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
            
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

                return;
            }
            
            else
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
            }
        }
    }
    public void chek_r_func(int x, int z)
    {
        if (x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
            }
            else if (newpos.chek_2obs == true)
            {

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();

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
        if ( x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newpos = enemymap.bom_worldpos(x, z);

            if (newpos.chek_1obs == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
            }
            else if (newpos.chek_2obs == true)
            {
                

                Destroy(Instantiate(chekhit, newpos.worldPos, Quaternion.identity), 0.1f);
                return;
            }
            
            else if (newpos.chek_player_1 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_1").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                
                return;
            }
            else if (newpos.chek_player_2 == true)
            {
                Destroy(Instantiate(exp, new Vector3(newpos.worldPos.x, 2.5f, newpos.worldPos.z), Quaternion.identity), bomdesTime);
                PlayerCrash p_ctrl = GameObject.FindGameObjectWithTag("player_2").GetComponent<PlayerCrash>();
                p_ctrl.chek_bom_hit();
                

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
        if (other.tag == "explotion")
        {
            //Destroy(gameObject);
            
        }

        
    }
}
