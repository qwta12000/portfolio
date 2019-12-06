using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_view : MonoBehaviour
{
    Transform Cmr;
    Transform Ply;
    public GameObject target_player;
    private RaycastHit ray_hit;
    private Vector3 Player_position;
    private Vector3 targetPos;
    private Vector3 thisPos;

    private float ray_num;
    private bool ray_ck;
    private bool count_ck;
    private int view_cameraCk;

    //카메라 ->오브젝트 이동
    //private void Player_Position()
    //{
    //    Vector3 targetpos = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    //    Vector3 pos1 = new Vector3(position1.transform.position.x, position1.transform.position.y, position1.transform.position.z);
    //    Vector3 pos2 = new Vector3(position2.transform.position.x, position2.transform.position.y, position2.transform.position.z);
    //    Vector3 pos3 = new Vector3(position3.transform.position.x, position3.transform.position.y, position3.transform.position.z);
    //    Vector3 pos4 = new Vector3(position4.transform.position.x, position4.transform.position.y, position4.transform.position.z);
    //    Vector3 thisPos = this.transform.position;

    //    if(targetpos.x <= pos1.x)
    //    {
    //        //카메라 줌인 설정.
    //    }
    //    else if (pos1.x< targetpos.x && targetpos.x <= pos2.x)
    //    {
    //        this.transform.position = Vector3.Lerp(thisPos, pos1, Time.deltaTime * 3.0f);
    //    }

    //    else if (pos2.x < targetpos.x && targetpos.x <= pos3.x)
    //    {
    //        this.transform.position = Vector3.Lerp(thisPos, pos2, Time.deltaTime * 3.0f);
    //    }

    //    else if (pos3.x < targetpos.x && targetpos.x <= pos4.x)
    //    {
    //        this.transform.position = Vector3.Lerp(thisPos, pos3, Time.deltaTime * 3.0f);
    //    }

    //    else if (pos4.x < targetpos.x)
    //    {
    //        this.transform.position = Vector3.Lerp(thisPos, pos4, Time.deltaTime * 3.0f);
    //    }
    //}


    //public void test()
    //{
    //    Vector3 vec = Ply.transform.position - transform.position;
    //    vec.Normalize();
    //    Quaternion q = Quaternion.LookRotation(vec);
    //    transform.rotation = q;
    //}

    //카메라 -> 캐릭터 추적, 이동

    void Awake()
    {
        reset_var();
    }

    //변수 초기 reset 함수
    private void reset_var()
    {
        Cmr = this.GetComponent<Transform>();
        Ply = GameObject.FindGameObjectWithTag("Player").transform;
        ray_num = 70.0f;
        ray_ck = false;
        count_ck = false;
        view_cameraCk = 1;
    }
    
    //카메라 -> 캐릭터 방향으로 Spherecast 적용. 범위 밖 벗어날 시 카메라 시야 조절
    private void Player_Chaser()
    {
        Player_position = new Vector3(target_player.transform.position.x,0, target_player.transform.position.z);

        Vector3 forwardRay = this.transform.forward;

        targetPos = new Vector3(Ply.transform.position.x, Ply.transform.position.y+49.5f, Ply.transform.position.z-50.0f);
        thisPos = new Vector3(this.Cmr.position.x, this.Cmr.position.y, this.Cmr.position.z);

        ray_ck = Physics.SphereCast(thisPos, 4.0f, forwardRay, out ray_hit, ray_num, 1 << LayerMask.NameToLayer("Player"));

        Cmr.transform.position = Vector3.Lerp(thisPos, targetPos, 0.01f);

        if (ray_ck)
        { 
            if(view_cameraCk == 1 && count_ck ==false)
            {
                view_cameraCk--;
                StartCoroutine(Camera_See(0));
            }
        }
        else
        {
            if(view_cameraCk == 0 && count_ck == true)
            {
                view_cameraCk++;
                StartCoroutine(Camera_See(1));
            }
        }
    }
    
    //ray 체크, 범위 밖 -> 카메라 field of view 조절 코루틴 설정
    IEnumerator Camera_See(int ck)
    {
        if (ck == 0)
        {
            for (float i = 25; i > 20; i--)
            {
                yield return new WaitForSeconds(0.02f);
                Camera.main.fieldOfView = i;
                if(i == 21)
                {
                    count_ck = true;
                }
            }
        }
        if (ck == 1)
        {
            for (float i = 20; i < 25; i++)
            {
                yield return new WaitForSeconds(0.02f);
                Camera.main.fieldOfView = i;
                if(i == 24)
                {
                    count_ck = false;
                }
            }
        }
    }

    //ray 범위 보여주기
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 forwardRay = this.transform.forward;

        Gizmos.DrawRay(thisPos, forwardRay * 70.0f);
        Gizmos.DrawWireSphere(thisPos + forwardRay * 70.0f, 5.0f);
    }

    private void FixedUpdate()
    {
        Player_Chaser();
    }
}
