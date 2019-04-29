using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerCrash : MonoBehaviour
{
    private GameObject Bomb;
    public GameObject shild;
    private Animator anim;
    private Vector3 temp_pos;
    public ParticleSystem eft_poweritem;
    public ParticleSystem eft_speeditem;
    public ParticleSystem eft_countitem;
    private GameObject[] bom_count;

    private EnemyMap myMap;

    private int Max_speed = 4;
    private int Max_power = 4;
    private int Max_count = 5;
    private int chekdie = 0;
    
    public bool chekhit = true;

    private Sound_Mgr soundmgr;

    public static bool player_die = false;

    private void Awake()
    {
        eft_poweritem.Stop();
        eft_speeditem.Stop();
        eft_countitem.Stop();
    }

    private void Start()
    {
        MgerClass.InstFunc.loadLife();
        MgerClass.InstFunc.loadData();
        anim = GetComponent<Animator>();
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        Bomb = Resources.Load("bomb_2") as GameObject;
        soundmgr = GameObject.Find("sound").GetComponent<Sound_Mgr>();

    }

    private void Update()
    {
        if (player_die == false)
        {
            if (transform.position.y >= 0.01f)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bom_count = GameObject.FindGameObjectsWithTag("Bomb");
                if (bom_count.Length < MgerClass.InstFunc.count)
                {
                    soundmgr.bomb_sound();//폭탄 놓을때 사운드                  
                    bomb_position();        
                }
            }
            chekposition();
        }
    }    

    public void chekposition()//플레이어 움직일때 발밑 패널
    {
        GameObject my_obj = myMap.panel_poschek(transform.position);
        my_obj.GetComponent<MeshRenderer>().enabled = true;
    }

    private void bomb_position()// 폭탄 생성
    {
        Mapclass newMap = myMap.worldposition(transform.position);
        if (!newMap.chek_enemy_1 && !newMap.chek_enemy_2 && !newMap.chek_enemy_3 && !newMap.chek_enemy_4 && !newMap.chek_enemy_5
            && !newMap.chek_enemy_8 && !newMap.chek_boom && !newMap.chek_boss)
        {
            Instantiate(Bomb, new Vector3(newMap.worldPos.x, 1.5f, newMap.worldPos.z), Quaternion.Euler(180, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //화력 아이템 획득시
        if (other.tag == "power")
        {
            soundmgr.playeritem_sound(); //아이템 먹을때 사운드 
            if (eft_poweritem.isPlaying) //아이템 먹을 시 파티클 플레이
            {
                eft_poweritem.Stop();
                eft_poweritem.Play();
            }
            else
            {
                eft_poweritem.Play();
            }
            //Destroy(Instantiate(eft_poweritem, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity), 1.5f);
            if (MgerClass.InstFunc.power < Max_power)
            {
                UI_mger.item_gold += 200;
                MgerClass.InstFunc.power++;
            }
            else
            {
                UI_mger.item_gold += 500;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "speed")
        {
            soundmgr.playeritem_sound();//아이템 먹을때 사운드     
            //Destroy(Instantiate(eft_speeditem, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity), 1.5f);
            //eft_speeditem.Play();
            if (eft_speeditem.isPlaying)
            {
                eft_speeditem.Stop();
                eft_speeditem.Play();
            }
            else
            {
                eft_speeditem.Play();
            }
            if (MgerClass.InstFunc.speed < Max_speed)
            {
                UI_mger.item_gold += 200;
                MgerClass.InstFunc.speed ++;
            }
            else
            {
                UI_mger.item_gold += 500;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "count")
        {
            soundmgr.playeritem_sound();//아이템 먹을때 사운드
            //Destroy(Instantiate(eft_countitem, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity), 1.5f);
            //eft_countitem.Play();
            if (eft_countitem.isPlaying)
            {
                eft_countitem.Stop();
                eft_countitem.Play();
            }
            else
            {
                eft_countitem.Play();
            }
            if (MgerClass.InstFunc.count < Max_count)
            {
                UI_mger.item_gold += 200;
                MgerClass.InstFunc.count++;
            }
            else
            {
                UI_mger.item_gold += 500;
            }
            Destroy(other.gameObject);
        }

        if (chekhit == true)
        {
            if (other.tag == "bossAtk" || other.tag == "rocket" || other.tag == "enemy_1" || other.tag == "enemy_2" || other.tag == "enemy_3" || other.tag == "enemy_4" || other.tag == "enemy_5" || other.tag == "enemy_6" || other.tag == "enemy_7" ||  other.tag == "boss")
            {
                soundmgr.playercrash_sound();//플레이러 죽을대 사운드
                chekhit = false;
                MgerClass.InstFunc.life--;
                player_die = true;
                if (MgerClass.InstFunc.life <= 0)
                {
                    soundmgr.stage_1_sound(2);
                    anim.SetBool("die", true);
                    soundmgr.playerdie_sound();//게임 끝 사운드
                    player_die = true;
                    chekhit = false;
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                }
                else
                {
                    anim.SetBool("idle", false);
                    anim.SetBool("die", true);
                    StartCoroutine(replayer());

                }
            } 
        }        
    }

    public void chek_bom_hit()
    {
        if (chekhit == true)
        {
            soundmgr.playercrash_sound();//플레이러 죽을대 사운드
            chekhit = false;
            MgerClass.InstFunc.life--;
            player_die = true;
            if (MgerClass.InstFunc.life <= 0)
            {
                soundmgr.stage_1_sound(2);
                anim.SetBool("die", true);
                soundmgr.playerdie_sound();//게임 끝 사운드
                player_die = true;
                chekhit = false;
                SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
            }
            else
            {
                anim.SetBool("idle", false);
                anim.SetBool("die", true);
                StartCoroutine(replayer());
            }
        }
    }

    IEnumerator replayer()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("idle", true);
        yield return new WaitForSeconds(1f);
        soundmgr.playerrestart_sound();//플레이어 되살아날때 사운드
        transform.position = new Vector3(-45, 0, -25);        
        Destroy(Instantiate(Resources.Load("reStart") as GameObject,  new Vector3( transform.position.x, 2, transform.position.z), Quaternion.identity),1.5f);

        yield return new WaitForSeconds(1.3f);        
        player_die = false;
        StartCoroutine(chekTime());
    }
    IEnumerator chekTime()//실드 
    {
        chekdie = 0;
        while (chekdie <= 6)
        {
            shild.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            shild.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            chekdie++;        
        }        
        chekhit = true;
    }
}
