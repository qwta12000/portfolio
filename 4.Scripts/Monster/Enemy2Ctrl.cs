using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Ctrl : MonoBehaviour {

    public Vector3 target;
    private Animator anim;

    //private GameObject tg;

    public List<Mapclass> move_route;
    public List<Mapclass> stop_route;
    public List<Mapclass> unique_route;

    public float x;
    public float z;

    private Collider coll;
    private EnemyMap myMap;
    //private int temprand = 0;
    private bool catDie = false;

    public Mapclass[,] mymap;
    private int xnode;
    private int znode;
    public LayerMask isobs;
    private EnemyMap e_map;

    public void rand_target()
    {
        target = myMap.mon_target_position();

        x = target.x;
        z = target.z;

    }

    private void Awake()
    {
        e_map = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        xnode = e_map.getxnode();
        znode = e_map.getznode();
        creatarry();
    }

    public void creatarry()
    {
        mymap = new Mapclass[xnode, znode];
        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                float xpos = e_map.dwonfloor.position.x + (e_map.size_whith * x);
                float zpos = e_map.dwonfloor.position.z + (e_map.size_height * z);
                //bool chekmask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.4f, isobs);

                mymap[x, z] = new Mapclass(x, z, new Vector3(xpos, transform.position.y, zpos), false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            }
        }

    }


    private void Start()
    {
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();

        //tg = GameObject.Find("target");

        anim = GetComponent<Animator>();
        coll = GetComponent<SphereCollider>();
    }

    private void Update()
    {

        if (catDie == false)
        {
            movemap();
        }
    }


    void movemap()
    {
        if(unique_route.Count>0)
        {
            Vector3 dist = unique_route[0].worldPos;

            if (dist != transform.position)
            {
                Quaternion look = Quaternion.LookRotation(dist - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 10f);

            }
            transform.position = Vector3.MoveTowards(transform.position, dist, Time.deltaTime * 4f);

            if(Vector3.Distance(transform.position,dist)<0.01f)
            {
                //rand_target();
                StartFind();
            }
            if(Vector3.Distance(transform.position,target)<0.05f)
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
                MgerClass.InstFunc.enemyCount--;
                UI_mger.enemy_gold += 150;
                catDie = true;
                anim.SetBool("die", true);
                Destroy(this.gameObject, 2);
            }
        }
    }


    public Mapclass worldposition(Vector3 pos)
    {
        int array_x = Mathf.RoundToInt(pos.x - e_map.dwonfloor.position.x) / e_map.size_whith;
        int array_z = Mathf.RoundToInt(pos.z - e_map.dwonfloor.position.z) / e_map.size_height;

        return mymap[array_x, array_z];
    }

    public List<Mapclass> getnextmap(Mapclass map)
    {
        List<Mapclass> newMap = new List<Mapclass>();
        if (map.list_x > 1)
        {
            newMap.Add(mymap[map.list_x - 1, map.list_z]);
        }
        if (map.list_x < xnode - 2)
        {
            newMap.Add(mymap[map.list_x + 1, map.list_z]);
        }
        if (map.list_z > 1)
        {
            newMap.Add(mymap[map.list_x, map.list_z - 1]);
        }
        if (map.list_z < znode - 2)
        {
            newMap.Add(mymap[map.list_x, map.list_z + 1]);
        }
        return newMap;

    }


    void StartFind()
    {
        Mapclass startMap = worldposition(transform.position);
        Mapclass endMap = worldposition(target);

        move_route.Clear();
        stop_route.Clear();

        move_route.Add(startMap);

        while(move_route.Count>0)
        {
            Mapclass newMap = move_route[0];//현재맵

            for(int i = 0; i < move_route.Count; i++)
            {
                if(move_route[i].f_cost < newMap.f_cost|| move_route[i].f_cost==newMap.f_cost&&move_route[i].h_cost<newMap.h_cost)
                {
                    newMap = move_route[i];
                }
            }

            move_route.Remove(newMap);
            stop_route.Add(newMap);

            if(newMap==endMap)
            {
                List<Mapclass> temp = new List<Mapclass>();

                while(endMap!=startMap)
                {
                    temp.Add(endMap);
                    endMap = endMap.justpos;
                }

                temp.Reverse();

                unique_route = temp;
                return;
            }

            foreach ( Mapclass nextMap in getnextmap(newMap))
            {
                if( !nextMap.chek_1obs && !stop_route.Contains(nextMap))
                {
                    int move_cost = newMap.g_cost + manhattandist(newMap, nextMap);

                    if( !move_route.Contains(newMap)||nextMap.g_cost>move_cost)
                    {
                        nextMap.g_cost = move_cost;

                        nextMap.h_cost = manhattandist(nextMap, endMap);

                        nextMap.justpos = newMap;

                        if(!move_route.Contains(nextMap))
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
        int dist = Mathf.Abs((start.list_x - next.list_x) * e_map.size_whith) + Mathf.Abs((start.list_z - next.list_z) * e_map.size_height);
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
