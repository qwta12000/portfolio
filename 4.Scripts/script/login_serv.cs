using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;
using System.Text;

public class login_serv : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
        Screen.SetResolution(Screen.width, (Screen.width / 16) * 9, false);
    }

    public static string ConnectServer(string Url, StringBuilder Info) //웹서버와 연결
    {
        //전달 받은 데이터
        StringBuilder sendInfo = Info;

        //HttpWebRequest 객체 생성
        //HTTP를 사용 하여 서버와 직접 상호 작용
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url);

        //외부에서 넘겨받은 문자열 바이트 데이터 처리
        byte[] byteArr = UTF8Encoding.UTF8.GetBytes(sendInfo.ToString());

        //바이트 데이터 처리 방식
        httpWebRequest.ContentType = "application/x-www-form-urlencoded"; 
        httpWebRequest.Method = "POST"; // 전송 방식
        httpWebRequest.ContentLength = byteArr.Length;

        //바이트 문자 데이터드를 읽거나 특정 장치에 출력
        Stream stream = httpWebRequest.GetRequestStream();
        stream.Write(byteArr, 0, byteArr.Length);

        //요청 응답 받기
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        //응답 stream 읽기
        Stream result = httpWebResponse.GetResponseStream();
        StreamReader readerResult = new StreamReader(result, Encoding.Default);

        //응답 stream -> 응답 string 변환
        return readerResult.ReadToEnd();
    }
}

