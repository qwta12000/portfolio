using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Ctrl : MonoBehaviour {

    //   public Vector3 target;
    //   private GameObject tg;
    //   private Transform target_1;
    //   private Transform target_2;
    //   private Transform target_3;
    //   private Transform target_4;
    //   private Transform target_5;
    //   private Transform target_6;
    //   private Transform target_7;
    //   private Transform target_8;
    //   private Transform target_9;
    //   private Transform target_10;

    //   public List<Mapclass> move_route;
    //   public List<Mapclass> stop_route;
    //   public List<Mapclass> unique_route;


    //   private EnemyMap myMap_1;

    //   public void rand_target()
    //   {
    //       int rand = Random.Range(1, 11);
    //       if (rand == 1)
    //       {
    //           target = target_1.position;
    //       }
    //       else if (rand == 2)
    //       {
    //           target = target_2.position;
    //       }
    //       else if (rand == 3)
    //       {
    //           target = target_3.position;
    //       }
    //       else if (rand == 4)
    //       {
    //           target = target_4.position;
    //       }
    //       else if (rand == 5)
    //       {
    //           target = target_5.position;
    //       }
    //       else if (rand == 6)
    //       {
    //           target = target_6.position;
    //       }
    //       else if (rand == 7)
    //       {
    //           target = target_7.position;
    //       }
    //       else if (rand == 8)
    //       {
    //           target = target_8.position;
    //       }
    //       else if (rand == 9)
    //       {
    //           target = target_9.position;
    //       }
    //       else if (rand == 10)
    //       {
    //           target = target_10.position;
    //       }
    //   }

    //   private void Awake()
    //   {
    //       myMap_1 = GameObject.Find("floormanager").GetComponent<EnemyMap>();

    //   }
    //   void Start ()
    //   {
    //       tg = GameObject.Find("target");

    //       target_1 = tg.transform.Find("targetpoint1");
    //       target_2 = tg.transform.Find("targetpoint2");
    //       target_3 = tg.transform.Find("targetpoint3");
    //       target_4 = tg.transform.Find("targetpoint4");
    //       target_5 = tg.transform.Find("targetpoint5");
    //       target_6 = tg.transform.Find("targetpoint6");
    //       target_7 = tg.transform.Find("targetpoint7");
    //       target_8 = tg.transform.Find("targetpoint8");
    //       target_9 = tg.transform.Find("targetpoint9");
    //       target_10 = tg.transform.Find("targetpoint10");

    //   }


    //void Update ()
    //   {
    //       movemap();
    //}

    //   void movemap()
    //   {
    //       if(unique_route.Count > 0)
    //       {
    //           Vector3 dist = unique_route[0].worldPos;
    //           Quaternion look = Quaternion.LookRotation(dist - transform.position);
    //           transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 10.0f);
    //           transform.position = Vector3.MoveTowards(transform.position, dist, Time.deltaTime * 5);

    //           if(Vector3.Distance(transform.position,dist) < 0.001f)
    //           {
    //               StartFind();
    //           }
    //           if(Vector3.Distance(transform.position,target) < 0.5f)
    //           {
    //               rand_target();
    //           }
    //       }
    //       else
    //       {
    //           rand_target();
    //           StartFind();
    //       }
    //   }

    //   void StartFind()
    //   {
    //       Mapclass startmap = myMap_1.worldposition(transform.position);
    //       Mapclass endmap = myMap_1.worldposition(target);

    //       move_route.Clear();
    //       stop_route.Clear();

    //       move_route.Add(startmap);

    //       while(move_route.Count>0)
    //       {
    //           Mapclass newMap = move_route[0];

    //           for(int i = 0; i < move_route.Count; i++)
    //           {
    //               if(move_route[i].f_cost < newMap.f_cost||move_route[i].f_cost == newMap.f_cost && move_route[i].h_cost < newMap.h_cost)
    //               {
    //                   newMap = move_route[i];
    //               }
    //           }

    //           move_route.Remove(newMap);
    //           stop_route.Add(newMap);

    //           if(newMap == endmap)
    //           {
    //               List<Mapclass> temp = new List<Mapclass>();

    //               while(endmap != startmap)
    //               {
    //                   temp.Add(endmap);
    //                   endmap = endmap.justpos;
    //               }

    //               temp.Reverse();
    //               unique_route = temp;
    //               return;
    //           }

    //           foreach(Mapclass nextMap in myMap_1.getnextmap(newMap))
    //           {
    //               if(!nextMap.chek_2obs && !nextMap.chek_1obs && !stop_route.Contains(newMap))
    //               {
    //                   int move_cost = newMap.g_cost + dist(newMap, nextMap);

    //                   if(!move_route.Contains(newMap)|| nextMap.g_cost > move_cost)
    //                   {
    //                       nextMap.g_cost = move_cost;
    //                       nextMap.h_cost = dist(nextMap, endmap);
    //                       nextMap.justpos = newMap;

    //                       if(!move_route.Contains(nextMap))
    //                       {
    //                           move_route.Add(nextMap);
    //                       }
    //                   }
    //               }
    //           }
    //       }
    //   }

    //   int dist(Mapclass start, Mapclass next)
    //   {
    //       int dis = Mathf.Abs((start.list_x - next.list_x) * myMap_1.size_whith) + Mathf.Abs((start.list_z - next.list_z) * myMap_1.size_height);

    //       return dis;
    //   }

    //   private void OnDrawGizmos()
    //   {
    //       Gizmos.color = Color.red;

    //       if(unique_route !=null)
    //       {
    //           for (int i =0;i < unique_route.Count - 1; i ++)
    //           {
    //               Gizmos.DrawLine(unique_route[i].worldPos, unique_route[i + 1].worldPos);
    //           }
    //       }
    //   }

    private Vector3 target;
    private Animator anim;
    private Collider coll;

    public List<Mapclass> move_route;
    public List<Mapclass> stop_route;
    public List<Mapclass> unique_route;

    private EnemyMap myMap;
 
    public bool catDie = false;

    public void rand_target()
    {
        target = myMap.mon_target_position();

    }



    private void Start()
    {
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        coll = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
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

            if (Vector3.Distance(transform.position, dist) < 0.001f)
            {
                StartFind();
            }
            if (Vector3.Distance(transform.position, target) < 0.05f)
            {
                rand_target();
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
        if (catDie == false)
        {
            if (other.tag == "explotion")
            {
                coll.enabled = false;
                anim.SetBool("die", true);
                MgerClass.InstFunc.enemyCount--;
                UI_mger.enemy_gold += 100;
                catDie = true;
                Destroy(this.gameObject, 2f);
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
                if (!nextMap.chek_2obs && !nextMap.chek_1obs && !stop_route.Contains(nextMap))
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


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        if (unique_route != null)
        {
            for (int i = 0; i < unique_route.Count - 1; i++)
            {
                Gizmos.DrawLine(unique_route[i].worldPos, unique_route[i + 1].worldPos);
            }
        }
    }

}
