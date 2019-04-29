using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMap : MonoBehaviour {
    public GameObject exp; //폭탄

    private GameObject player_posEft;
    private GameObject roketbomPos;
    private GameObject[,] mypos;
    private GameObject[,] rocketPos;


    public Transform topfloor;
    public Transform dwonfloor;

    public int size_whith = 5;
    public int size_height = 5;

    public Mapclass[,] myMap;

    private int xnode;
    private int znode;

    private int xmap;
    private int zmap;

    public LayerMask isobs_1;
    public LayerMask isobs_2;
    public LayerMask isobs_enemy_1;
    public LayerMask isobs_enemy_2;
    public LayerMask isobs_enemy_3;
    public LayerMask isobs_enemy_4;
    public LayerMask isobs_enemy_5;
    public LayerMask isobs_enemy_6;
    public LayerMask isobs_enemy_7;
    public LayerMask isobs_enemy_8;
    public LayerMask isobs_boss;
    public LayerMask isobs_player_1;
    public LayerMask isobs_player_2;
    public LayerMask isobs_player_3;
    public LayerMask isobs_boom;


    private void Awake()
    {
        createMap();
        chek_my_position();

    }
    
    
    public void createMap()
    {
        xnode = Mathf.RoundToInt((topfloor.position.x - dwonfloor.position.x) / size_whith) + 1;
        znode = Mathf.RoundToInt((topfloor.position.z - dwonfloor.position.z) / size_height) + 1;

        myMap = new Mapclass[xnode, znode];

        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                float xpos = dwonfloor.position.x + (size_whith * x);
                float zpos = dwonfloor.position.z + (size_height * z);

                bool chek_1mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_1);
                bool chek_2mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_2);
                bool chek_enemy_1_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_1);
                bool chek_enemy_2_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_2);
                bool chek_enemy_3_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_3);
                bool chek_enemy_4_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_4);
                bool chek_enemy_5_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_5);
                bool chek_enemy_6_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_6);
                bool chek_enemy_7_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_7);
                bool chek_enemy_8_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_enemy_8);
                bool chek_boss_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_boss);
                bool chek_player_1_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_player_1);
                bool chek_player_2_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_player_2);
                bool chek_player_3_mask = Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_player_3);
                bool chek_boom= Physics.CheckSphere(new Vector3(xpos, transform.position.y, zpos), size_whith * 0.3f, isobs_boom);
           
                myMap[x, z] = new Mapclass(x, z, new Vector3(xpos, transform.position.y, zpos), chek_1mask, chek_2mask, chek_enemy_1_mask, chek_enemy_2_mask,
                                                chek_enemy_3_mask, chek_enemy_4_mask, chek_enemy_5_mask, chek_enemy_6_mask, 
                                                chek_enemy_7_mask, chek_enemy_8_mask, chek_boss_mask, chek_player_1_mask, 
                                                chek_player_2_mask, chek_player_3_mask, chek_boom);
            }
        }
    }

    public Vector3 mon_target_position()//몬스터 이동목표 랜덤위치를 반환
    {
        int rand_x = Random.Range(1, xnode - 2);
        int rand_z = Random.Range(1, znode - 2);
        return myMap[rand_x, rand_z].worldPos;
    }


    public Vector3 mon_instatate()// 몬스터 생성 위치 랜덤.
    {
        int rand_x = Random.Range(1, xnode - 2);
        int rand_z = Random.Range(1, znode - 2);
        if (rand_x <= 2)
        {
            rand_z = Random.Range(5, znode - 2);
        }
        if (rand_z <= 2)
        {
            rand_x = Random.Range(5, znode - 2);
        }
        while (!myMap[rand_x, rand_z].chek_1obs && myMap[rand_x, rand_z].chek_2obs)
        {
            rand_x = Random.Range(1, xnode - 2);
            rand_z = Random.Range(1, znode - 2);

            if(rand_x <= 2)
            {
                rand_z = Random.Range(5, znode - 2);
            }
            if (rand_z <= 2)
            {
                rand_x = Random.Range(5, znode - 2);
            }
        }
        return myMap[rand_x, rand_z].worldPos;
    }


    public GameObject panel_poschek(Vector3 pos)//배열에서 플레이어 이동 패널 위치
    {
        int array_1 = Mathf.RoundToInt((pos.x - dwonfloor.position.x) / size_whith);
        int array_2 = Mathf.RoundToInt((pos.z - dwonfloor.position.z) / size_height);

        return mypos[array_1, array_2];
    }

    public void chekrocket_enable()//로켓위치 패널 체크하여 투명하게 만듬 
    {
        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                rocketPos[x, z].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public void chek_roketpos()//보스로켓 발사후 떨어지는 위치 패널
    {
        roketbomPos = Resources.Load("roketbompos") as GameObject;
        roketbomPos.GetComponent<MeshRenderer>().enabled = false;
        rocketPos = new GameObject[xnode, znode];

        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                float xpos = dwonfloor.position.x + (size_whith * x);
                float zpos = dwonfloor.position.z + (size_height * z);

                rocketPos[x, z] = Instantiate(roketbomPos, new Vector3(xpos, transform.position.y, zpos), Quaternion.identity);
            }
        }

    }
    public GameObject panel_rocket(int x, int z)//로켓패널 배열에서의 위치를 반환
    {

        return rocketPos[x, z];
    }

    public void chek_my_position()//플레이어 패널 깔기
    {
        player_posEft = Resources.Load("player_pos") as GameObject;
        player_posEft.GetComponent<MeshRenderer>().enabled = false;
        mypos = new GameObject[xnode, znode];
        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                float xpos = dwonfloor.position.x + (size_whith * x);
                float zpos = dwonfloor.position.z + (size_height * z);

                mypos[x, z] = Instantiate(player_posEft, new Vector3(xpos, transform.position.y, zpos), Quaternion.identity);
            }
        }
    }

    public void chekmypos_enable() //이동 패널 투명 항시 체크
    {
        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                mypos[x, z].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }



    public int getxnode()//배열의 x길이 반환
    {
        xnode = Mathf.RoundToInt((topfloor.position.x - dwonfloor.position.x) / size_whith) + 1;
        return xnode;
    }
    public int getznode()//배열의 z길이 반환
    {
        znode = Mathf.RoundToInt((topfloor.position.z - dwonfloor.position.z) / size_height) + 1;
        return znode;
    }


    public Mapclass rand_target()// 배열에서의 장애물을 뺀 위치를 랜덤으로 반환
    {
        int x = Random.Range(1, xnode - 1);
        int z = Random.Range(1, znode - 1);

        while (myMap[x, z].chek_1obs == true || myMap[x, z].chek_2obs == true)
        {
            x = Random.Range(1, xnode - 1);
            z = Random.Range(1, znode - 1);
        }
        return myMap[x, z];
    }




    private void Update()
    {
        createMap();//맵상태 항시테크
        chekmypos_enable();//플레이어 이동패널 항시체크
    }

    private void OnDrawGizmos()
    {
        if (myMap != null)
        {
            foreach (Mapclass newmap in myMap)
            {
                if (newmap.chek_1obs == true)
                {
                    
                    Gizmos.color = Color.yellow;
                }

                else if (newmap.chek_2obs == true)
                {
                    
                    Gizmos.color = Color.red;

                }

                else if(newmap.chek_enemy_1 ==true|| newmap.chek_enemy_2 == true || newmap.chek_enemy_3 == true ||
                    newmap.chek_enemy_4 == true || newmap.chek_enemy_5 == true || newmap.chek_boss == true)
                {
                    Gizmos.color = Color.magenta;
                }
                else
                {
                    Gizmos.color = Color.white;
                }

                Gizmos.DrawWireCube(newmap.worldPos, new Vector3(size_whith, 0, size_height));
            }
        }
    }


    public Vector3 chekpos(Vector3 pos)
    {
        return pos;
    }

    public Mapclass bom_worldpos(int x, int z)//폭탄의 배열에서의 위치를 반환
    {
        return myMap[x, z];
    }


    public Mapclass worldposition(Vector3 pos)//월드위치에서 해당하는 배열의 위치.
    {
        int array_1 = Mathf.RoundToInt((pos.x - dwonfloor.position.x) / size_whith);
        int array_2 = Mathf.RoundToInt((pos.z - dwonfloor.position.z) / size_height);

        return myMap[array_1, array_2];
    }

    public List<Mapclass> getnextmap(Mapclass map)
    {
        List<Mapclass> newmap = new List<Mapclass>();

        if(map.list_x > 1)
        {
            newmap.Add(myMap[map.list_x - 1, map.list_z]);
        }
        if(map.list_x < xnode - 2)
        {
            newmap.Add(myMap[map.list_x + 1, map.list_z]);
        }
        if(map.list_z > 1)
        {
            newmap.Add(myMap[map.list_x, map.list_z - 1]);
        }
        if(map.list_z < znode - 2)
        {
            newmap.Add(myMap[map.list_x, map.list_z + 1]);
        }
        return newmap;
    }
}
