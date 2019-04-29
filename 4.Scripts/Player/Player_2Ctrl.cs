using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_2Ctrl : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject shild;
    private Animator anim;

    private GameObject[] bom_count;

    private EnemyMap myMap;

    private int Max_speed = 5;
    private int Max_power = 5;
    private int Max_count = 5;
    private int chekdie = 0;

    public bool chekhit = true;




    private void Start()
    {
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        MgerClass.InstFunc.loadLife();
        MgerClass.InstFunc.loadData();
        anim = GetComponent<Animator>();
    }



    private void Update()
    {

        if (transform.position.y >= 0.05f)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            bom_count = GameObject.FindGameObjectsWithTag("Bomb");
            if (bom_count.Length < MgerClass.InstFunc.count)
            {
                bomb_position();
            }
        }
    }

    private void bomb_position()
    {
        Mapclass newMap = myMap.worldposition(transform.position);
        //Instantiate(Bomb, newMap.worldPos, Quaternion.identity);
        Instantiate(Bomb, new Vector3(newMap.worldPos.x, 2, newMap.worldPos.z), Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        //화력 아이템 획득시
        if (other.tag == "power")
        {
            if (MgerClass.InstFunc.power < Max_power)
            {
                MgerClass.InstFunc.power++;
            }
            else
            {
                MgerClass.InstFunc.score += 200;
            }
            Destroy(other.gameObject);

        }
        if (other.tag == "speed")
        {
            if (MgerClass.InstFunc.speed < Max_speed)
            {
                MgerClass.InstFunc.speed++;
            }
            else
            {
                MgerClass.InstFunc.score += 200;
            }
            Destroy(other.gameObject);

        }
        if (other.tag == "count")
        {
            if (MgerClass.InstFunc.count < Max_count)
            {
                MgerClass.InstFunc.count++;
            }
            else
            {
                MgerClass.InstFunc.score += 200;
            }
            Destroy(other.gameObject);

        }

        if (chekhit == true)
        {
            if (other.tag == "explotion" || other.tag == "enemy_1" || other.tag == "enemy_2" || other.tag == "enemy_3" || other.tag == "enemy_4" || other.tag == "enemy_5" || other.tag == "enemy_6" || other.tag == "enemy_7" || other.tag == "enemy_8" || other.tag == "boss")
            {
                chekhit = false;
                MgerClass.InstFunc.life--;

                if (MgerClass.InstFunc.life == 0)
                {
                    Destroy(this.gameObject);
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


    IEnumerator replayer()
    {
        yield return new WaitForSeconds(1.6f);
        anim.SetBool("idle", true);

        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector3(-35, 0, -35);
        Destroy(Instantiate(Resources.Load("reStart") as GameObject, new Vector3(transform.position.x, 2, transform.position.z), Quaternion.identity), 1.5f);

        yield return new WaitForSeconds(2.0f);
        chekhit = true;
    }

    public void chekDieFunc()
    {
        MgerClass.InstFunc.life--;

        if (MgerClass.InstFunc.life == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
        chekhit = false;

    }

    IEnumerator chekTime()//실드 
    {
        chekdie = 0;
        while (chekdie <= 8)
        {
            shild.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            shild.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            chekdie++;
        }
        //Debug.Log(MgerClass.InstFunc.life);
        chekhit = true;
    }
}
