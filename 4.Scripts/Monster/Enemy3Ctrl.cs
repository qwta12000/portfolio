using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Ctrl : MonoBehaviour
{
    public Vector3 target;

    //private GameObject tg;
    private GameObject shild;

    private Animator anim;
    private Collider coll;
    public List<Mapclass> move_route;
    public List<Mapclass> stop_route;
    public List<Mapclass> unique_route;


    private EnemyMap myMap;
    //private int temprand = 0;


    private bool catDie = false;
    private bool chekhit = false;




    public void rand_target()
    {
        target = myMap.mon_target_position();
    }

    private void Start()
    {
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();

        //tg = GameObject.Find("target");
        shild = transform.Find("shild").gameObject;
        anim = GetComponent<Animator>();
        coll = GetComponent<SphereCollider>();

        StartCoroutine(chekshild());

    }

    IEnumerator chekshild()
    {
        while(!catDie)
        {
            shild.SetActive(true);
            chekhit = false;
            yield return new WaitForSeconds(4);
            shild.SetActive(false);
            chekhit = true;
            yield return new WaitForSeconds(6);
        }
    }

    private void Update()
    {

        if(catDie == false)
        {
            movemap();
        }

    }


    void movemap()
    {
        if (unique_route.Count > 0)
        {
            Vector3 dist = unique_route[0].worldPos;

            if (dist != transform.position)
            {
                Quaternion look = Quaternion.LookRotation(dist - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 10f);

            }
            else
            {
                rand_target();
            }
            transform.position = Vector3.MoveTowards(transform.position, dist, Time.deltaTime * 5);

            if (Vector3.Distance(transform.position, dist) < 0.01f)
            {
                
                StartFind();
            }
            if (Vector3.Distance(transform.position, target) < 0.5f)
            {
                move_route.Clear();
                //rand_target();
            }
        }
        else
        {
            rand_target();
            StartFind();
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (catDie == false && chekhit == true)
        {
            if (other.tag == "explotion")
            {
                anim.SetBool("die", true);
                coll.enabled = false;
                MgerClass.InstFunc.enemyCount--;
                UI_mger.enemy_gold += 150;
                catDie = true;
                Destroy(this.gameObject, 2);
            }
        }
    }




    void StartFind()
    {
        Mapclass startMap = myMap.worldposition(transform.position);
        Mapclass endMap = myMap.worldposition(target);

        move_route.Clear();
        stop_route.Clear();

        move_route.Add(startMap);

        while (move_route.Count > 0)
        {
            Mapclass newMap = move_route[0];//현재맵

            for (int i = 0; i < move_route.Count; i++)
            {
                if (move_route[i].f_cost < newMap.f_cost || move_route[i].f_cost == newMap.f_cost && move_route[i].h_cost < newMap.h_cost)
                {
                    newMap = move_route[i];
                }
            }

            move_route.Remove(newMap);
            stop_route.Add(newMap);

            if (newMap == endMap)
            {
                List<Mapclass> temp = new List<Mapclass>();

                while (endMap != startMap)
                {
                    temp.Add(endMap);
                    endMap = endMap.justpos;
                }

                temp.Reverse();

                unique_route = temp;
                return;
            }

            foreach (Mapclass nextMap in myMap.getnextmap(newMap))
            {
                if (!nextMap.chek_2obs && !nextMap.chek_boom && !nextMap.chek_1obs && !stop_route.Contains(nextMap))
                {
                    int move_cost = newMap.g_cost + manhattandist(newMap, nextMap);

                    if (!move_route.Contains(newMap) || nextMap.g_cost > move_cost)
                    {
                        nextMap.g_cost = move_cost;

                        nextMap.h_cost = manhattandist(nextMap, endMap);

                        nextMap.justpos = newMap;

                        if (!move_route.Contains(nextMap))
                        {
                            move_route.Add(nextMap);
                        }
                    }
                }
            }
        }
    }


    int manhattandist(Mapclass start, Mapclass next)
    {
        int dist = Mathf.Abs((start.list_x - next.list_x) * myMap.size_whith) + Mathf.Abs((start.list_z - next.list_z) * myMap.size_height);
        return dist;
    }


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.magenta;

    //    if (unique_route != null)
    //    {
    //        for (int i = 0; i < unique_route.Count - 1; i++)
    //        {
    //            Gizmos.DrawLine(unique_route[i].worldPos, unique_route[i + 1].worldPos);
    //        }
    //    }
    //}
}
