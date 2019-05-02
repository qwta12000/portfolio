using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BossCtrl : MonoBehaviour
{
    private Vector3 target;
    private Animator anim;
    private GameObject player;
    private GameObject rocketPos;
    private GameObject bossjumpeft;
    //private Rigidbody rigi;

    public List<Mapclass> move_route;
    public List<Mapclass> stop_route;
    public List<Mapclass> unique_route;

    public float time = 4;

    private EnemyMap myMap;

    private float g = 9.8f;

    private float max_height = 30.0f;

    private bool catDie = false;
    private bool chekhit = false;
    private bool boss_anim = false; //보스 공격애니체크

    private string[] colorName;
    private bool rocket_atk = false;
    private float rocket_Time = 0.0f;
    private float rocket_Time2 = 0.0f;

    private bool chekatk = false;//분신공격체크 cd 3초.
    private Vector3 pos;
    private bool chek_f = true;
    private bool chek_b = true;
    private bool chek_r = true;
    private bool chek_l = true;
    private int select = 0;
    private int xnode = 0;
    private int znode = 0;
    //private bool chek_playerpos = false;
    private Sound_Mgr mgrsound;
    private GameObject shild;
    private void Start()
    {
        
        select = PlayerPrefs.GetInt("charac");
        rocketPos = Resources.Load("rocketPos") as GameObject;
        //rigi = GetComponent<Rigidbody>();
        colorName = new string[4] { "Blue", "Orange", "Pink", "Red" };
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        mgrsound = GameObject.Find("sound").GetComponent<Sound_Mgr>();
        shild = transform.Find("shild").gameObject;
        bossjumpeft = Resources.Load("boss_jumpeft") as GameObject;
        //bossjumpeft.transform.Rotate(new Vector3(-90, 0, 0));
        myMap.chek_roketpos();
        load_player();
        anim = GetComponent<Animator>();
        xnode = myMap.getxnode();
        znode = myMap.getznode();
        

        StartCoroutine(chek_dfs());
        
    }

    IEnumerator chek_dfs()
    {
        while (catDie == false)
        {
            chekhit = true;
            shild.SetActive(true);
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            chekhit = false;
            shild.SetActive(false);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    public void load_player()
    {
        if (select == 1)
        {
            player = GameObject.FindGameObjectWithTag("player_1");
        }
        else if (select == 2)
        {
            player = GameObject.FindGameObjectWithTag("player_2");
        }
        else if (select == 3)
        {
            player = GameObject.FindGameObjectWithTag("player_3");
        }
    }


    public void chektarget()
    {
        if (MgerClass.InstFunc.life > 0)
        {
            Mapclass newmap = myMap.worldposition(player.transform.position);
            target = newmap.worldPos;
        }
    }

    private void Update()
    {
        
        if (catDie == false)
        {
            time += Time.deltaTime;


            

            if (boss_anim == false)
            {
                movemap();
            }


            chek_Player();

            rocket_Time += Time.deltaTime;
            rocket_Time2 += Time.deltaTime;
            if (MgerClass.InstFunc.enemyCount > 3)
            {
                if (rocket_Time >= 4f)
                {
                    rocket_Time = 0.0f;
                    bomatk_Func(1);
                }
            }
            else if (MgerClass.InstFunc.enemyCount <= 3 && MgerClass.InstFunc.enemyCount > 0 && rocket_Time >= 8)
            {
                rocket_Time = 0f;
                rocket_atk = true;

            }

            if(rocket_atk == true && rocket_Time2 >= 0.2f)
            {
                rocket_Time2 = 0f;
                bomatk_Func(2);
                StartCoroutine(roketatk());
            }


        }
    }

    IEnumerator roketatk()
    {
        yield return new WaitForSeconds(1.5f);
        rocket_atk = false;
    }

    public void chek_Player()//플레이어 체크
    {
        Mapclass enemyPos = myMap.worldposition(transform.position);
        for (int i = 1; i <= 4; i++)
        {
            chekFunc_f(enemyPos.list_x, enemyPos.list_z + i);
            chekFunc_b(enemyPos.list_x, enemyPos.list_z - i);
            chekFunc_r(enemyPos.list_x + i, enemyPos.list_z);
            chekFunc_l(enemyPos.list_x - i, enemyPos.list_z);
        }
        chek_f = true;
        chek_b = true;
        chek_r = true;
        chek_l = true;
    }

    public void chekFunc_f(int x, int z)
    {
        if (chek_f == true && x > 0 && x < xnode-1 && z > 0 && z < znode-1)
        {
            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_f = false;
                return;
            }
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
            {
                chek_f = false;
                if (chekatk == false)
                {
                    anim.SetBool("attack", true);
                    boss_anim = true;
                    pos = newmap.worldPos;
                    chekatk = true;
                    enemy_Atk(1);
                }
                return;
            }
        }
    }

    public void chekFunc_b(int x, int z)
    {
        if (chek_b == true && x > 0 && x < xnode-1 && z > 0 && z < znode-1)
        {

            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_b = false;
                return;
            }
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
            {
                chek_b = false;
                if (chekatk == false)
                {
                    anim.SetBool("attack", true);
                    boss_anim = true;
                    pos = newmap.worldPos;
                    chekatk = true;
                    enemy_Atk(2);
                }
                return;
            }
        }
    }

    public void chekFunc_r(int x, int z)
    {
        if (chek_r == true && x > 0 && x < xnode - 1 && z > 0 && z < znode - 1)
        {

            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_r = false;
                return;
            }
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
            {
                chek_r = false;
                if (chekatk == false)
                {
                    anim.SetBool("attack", true);
                    boss_anim = true;
                    pos = newmap.worldPos;
                    chekatk = true;
                    enemy_Atk(3);
                }
                return;
            }
        }
    }

    public void chekFunc_l(int x, int z)
    {
        if (chek_l == true && x > 0 && x < xnode - 1 && z > 0 && z < znode - 1)
        {

            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_l = false;
                return;
            }
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
            {
                chek_l = false;
                if (chekatk == false)
                {
                    anim.SetBool("attack", true);
                    boss_anim = true;
                    pos = newmap.worldPos;
                    chekatk = true;
                    enemy_Atk(4);
                }
                return;
            }
        }
    }


    public void enemy_Atk(int num)//분신공격.  num은 방향.1 위 2 아래 3 오 4 왼
    {
        Mapclass mePos = myMap.worldposition(transform.position);
        Vector3 startPos = mePos.worldPos;
        GameObject me_boss = Instantiate(Resources.Load("boss_jumpAtk") as GameObject, mePos.worldPos, Quaternion.identity);

        float dh = pos.y - mePos.worldPos.y;
        float mh = 1f - mePos.worldPos.y;
        float speed_y = Mathf.Sqrt(2 * g * mh);
        float a = g;
        float b = -2 * speed_y;
        float c = 2 * dh;
        float dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
        float speed_x = -(mePos.worldPos.x - pos.x) / dat;
        float speed_z = -(mePos.worldPos.z - pos.z) / dat;
        float elapsed_time = 0f;
        Destroy(me_boss, 1.8f);
        
        StartCoroutine(bossjump(me_boss, num, startPos, speed_x, speed_y, speed_z, elapsed_time, dat));
    }

    IEnumerator bossjump(GameObject me_boss, int num, Vector3 startPos, float speed_x, float speed_y, float speed_z, float elapsed_time, float dat)
    {
        if (num == 1)
        {
            me_boss.transform.Rotate(new Vector3(0, 0, 0));
        }
        else if (num == 2)
        {
            me_boss.transform.Rotate(new Vector3(0, 180f, 0));
        }
        else if (num == 3)
        {
            me_boss.transform.Rotate(new Vector3(0, 90f, 0));
        }
        else if (num == 4)
        {
            me_boss.transform.Rotate(new Vector3(0, -90f, 0));
        }
        while (true)
        {
            elapsed_time += Time.deltaTime * 0.8f;
            float tx = startPos.x + speed_x * elapsed_time;
            float ty = startPos.y + speed_y * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            float tz = startPos.z + speed_z * elapsed_time;
            Vector3 tpos = new Vector3(tx, ty, tz);
            me_boss.transform.position = tpos;
            if (elapsed_time >= dat) break;
            yield return null;
        }
        anim.SetBool("attack", false);
        boss_anim = false;
        Destroy(Instantiate(bossjumpeft, me_boss.transform.position, Quaternion.Euler(-90,0,0)), 1f);
        StartCoroutine(jumpatk_chek());
    }

    IEnumerator jumpatk_chek()
    {
        yield return new WaitForSeconds(3.0f);
        chekatk = false;
    }

    public void bomatk_Func(int num)
    {
        for (int i = 0; i < num; i++)
        {
            int bomNum = Random.Range(1, 20);
            string Rocket = colorName[bomNum % 4] + "/" + "Rocket" + bomNum.ToString("00") + "_" + colorName[bomNum % 4];
            Mapclass mePos = myMap.worldposition(transform.position);
            Vector3 startPos = mePos.worldPos;
            startPos.y += 12.0f;
            mePos.worldPos.y += 12.0f;
            GameObject roketObj = Instantiate(Resources.Load(Rocket) as GameObject, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), Quaternion.identity);

            roketCtrl rocetctrl = roketObj.GetComponent<roketCtrl>();
            if (num == 1)
            {
                if (MgerClass.InstFunc.life > 0)
                {
                    Mapclass newmap = myMap.worldposition(player.transform.position);
                    Vector3 rocket_target = newmap.worldPos;
                    GameObject roc_pos = Instantiate(rocketPos, rocket_target, Quaternion.identity);
                    float dh = rocket_target.y - mePos.worldPos.y;
                    float mh = max_height - mePos.worldPos.y;
                    float speed_y = Mathf.Sqrt(2 * g * mh);
                    float a = g;
                    float b = -2 * speed_y;
                    float c = 2 * dh;
                    float dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
                    float speed_x = -(mePos.worldPos.x - rocket_target.x) / dat;
                    float speed_z = -(mePos.worldPos.z - rocket_target.z) / dat;
                    float elapsed_time = 0f;
                    Destroy(roc_pos, 2.5f);
                    StartCoroutine(shotImgl(roketObj, startPos, rocetctrl, speed_x, speed_y, speed_z, elapsed_time, dat));
                }
            }
            else
            {
                if (MgerClass.InstFunc.life > 0)
                {
                    Mapclass newmap = myMap.rand_target();
                    Vector3 rocket_target = newmap.worldPos;
                    GameObject roc_pos = Instantiate(rocketPos, rocket_target, Quaternion.identity);
                    Destroy(roc_pos, 2.5f);

                    float dh = rocket_target.y - mePos.worldPos.y;
                    float mh = max_height - mePos.worldPos.y;
                    float speed_y = Mathf.Sqrt(2 * g * mh);
                    float a = g;
                    float b = -2 * speed_y;
                    float c = 2 * dh;
                    float dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
                    float speed_x = -(mePos.worldPos.x - rocket_target.x) / dat;
                    float speed_z = -(mePos.worldPos.z - rocket_target.z) / dat;
                    float elapsed_time = 0f;
                    if (i == 0)
                        StartCoroutine(shotImgl(roketObj, startPos, rocetctrl, speed_x, speed_y, speed_z, elapsed_time, dat));
                    else if (i == 1)
                        StartCoroutine(shotImgl1(roketObj, startPos, rocetctrl, speed_x, speed_y, speed_z, elapsed_time, dat));

                }
            }
        }
    }

    IEnumerator shotImgl(GameObject roketObj, Vector3 startPos, roketCtrl rocetctrl, float speed_x, float speed_y, float speed_z, float elapsed_time, float dat)
    {
        while (true)
        {
            elapsed_time += Time.deltaTime * 1.7f;
            float tx = startPos.x + speed_x * elapsed_time;
            float ty = startPos.y + speed_y * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            float tz = startPos.z + speed_z * elapsed_time;
            Vector3 tpos = new Vector3(tx, ty, tz);
            roketObj.transform.LookAt(tpos);
            roketObj.transform.Rotate(new Vector3(90, 0, 0));
            roketObj.transform.position = tpos;
            if (elapsed_time >= dat) break;
            yield return null;
        }
        mgrsound.roket_roundert();
        rocetctrl.bomb_manege();
    }

    IEnumerator shotImgl1(GameObject roketObj, Vector3 startPos, roketCtrl rocetctrl, float speed_x, float speed_y, float speed_z, float elapsed_time, float dat)
    {
        while (true)
        {
            elapsed_time += Time.deltaTime * 1.7f;
            float tx = startPos.x + speed_x * elapsed_time;
            float ty = startPos.y + speed_y * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            float tz = startPos.z + speed_z * elapsed_time;
            Vector3 tpos = new Vector3(tx, ty, tz);
            roketObj.transform.LookAt(tpos);
            roketObj.transform.Rotate(new Vector3(90, 0, 0));
            roketObj.transform.position = tpos;
            if (elapsed_time >= dat) break;
            yield return null;
        }
        mgrsound.roket_roundert();

        rocetctrl.bomb_manege();
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
            transform.position = Vector3.MoveTowards(transform.position, dist, Time.deltaTime * 4f);
            chektarget();
            StartFind();
        }
        else
        {
            chektarget();
            StartFind();
        }
    }




    public void chekdie()
    {

        if (chekhit == false)
        {
            chekhit = true;
            anim.SetBool("damage", true);
            MgerClass.InstFunc.enemyCount--;
            shild.SetActive(true);
            if (MgerClass.InstFunc.enemyCount <= 0)
            {
                anim.SetBool("die", true);
                UI_mger.enemy_gold += 5000;
                catDie = true;
                Destroy(this.gameObject, 2f);
                StartCoroutine(loadscene());
            }

            StartCoroutine(chekhittime());
        }
    }

    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ClearScene");

    }

    IEnumerator chekhittime()
    {
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("damage", false);

        //chekhit = false;
        //shild.SetActive(false);

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
                if (!nextMap.chek_boom && !nextMap.chek_2obs && !nextMap.chek_1obs && !stop_route.Contains(nextMap))
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
