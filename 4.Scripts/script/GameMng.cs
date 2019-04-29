using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    [Header("InputField")]
    public InputField IDInput;
    public InputField PassInput;
    public InputField New_IDInput;
    public InputField New_PassInput;
    [Header("PopupPanel")]
    public GameObject New_Success;
    public GameObject New_Fail;
    public GameObject Login_Success;
    public GameObject Login_Fail;
    public GameObject Game_Title;
    [Header("LoginPanelChange")]
    public GameObject Create_Panel;
    public GameObject Login_Panel;

    string LoginUrl;
    bool Change_Panel;

    private SoundMng Btn_sound;

    StringBuilder sendInfo;

    Animator Login_Sani;
    Animator Login_Fani;
    Animator NewId_Fani;
    Animator NewId_Sani;

    public void Awake()
    {
        LoginUrl = "";
        Login_Success.SetActive(false);
        Login_Fail.SetActive(false);
        New_Fail.SetActive(false);
        New_Success.SetActive(false);
        Change_Panel = false;
        Login_Sani = Login_Success.GetComponent<Animator>();
        Login_Fani = Login_Fail.GetComponent<Animator>();
        NewId_Fani = New_Fail.GetComponent<Animator>();
        NewId_Sani = New_Success.GetComponent<Animator>();
        Btn_sound = GameObject.Find("Sound").GetComponent<SoundMng>();
    }

    public void Login()
    {
        LoginUrl = "http://192.168.0.10:10001/Login";
        sendInfo = new StringBuilder();
        sendInfo.Append("id=" + IDInput.text);
        sendInfo.Append("&password=" + PassInput.text);
        string LoginSv = login_serv.ConnectServer(LoginUrl, sendInfo);
        Debug.Log(LoginSv);

        if (LoginSv == "success")
        {
            //Login 성공 했을시 성공 팝업창 생성
            Login_Success.SetActive(true);
            Btn_sound.Btn_Success();
            Login_Sani.SetBool("close", false);
            Login_Sani.SetBool("open", true);
        }
        else if(LoginSv == "fail")
        {
            Login_Fail.SetActive(true);
            Btn_sound.Btn_Error();
            Login_Fani.SetBool("close", false);
            Login_Fani.SetBool("open", true);
        }
    }

    public void Create_Id()
    {
        LoginUrl = "http://192.168.0.10:10001/Signup";
        sendInfo = new StringBuilder();
        sendInfo.Append("id=" + New_IDInput.text);
        sendInfo.Append("&password=" + New_PassInput.text);
        string CreateSv = login_serv.ConnectServer(LoginUrl, sendInfo);
        Debug.Log(CreateSv);
        if (CreateSv == "signup")
        {
            New_Success.SetActive(true);
            Btn_sound.Btn_Success();
            NewId_Sani.SetBool("close", false);
            NewId_Sani.SetBool("open", true);
        }
        else if (CreateSv == "fail")
        {
            New_Fail.SetActive(true);
            Btn_sound.Btn_Error();
            NewId_Fani.SetBool("close", false);
            NewId_Fani.SetBool("open", true);
        }
    }

    public void Create_Id_Btn()
    {
        Change_Panel = true;
        Btn_sound.BtnClick_Sound();
    }
    public void Cancel_Btn()
    {
        Change_Panel = false;
        Btn_sound.Btn_Cancel();
    }

    public void LoginBtn_Success()
    {
        //Login 성공 팝업창 확인버튼 눌렀을시
        Login_Sani.SetBool("close", true);
        Login_Sani.SetBool("open", false);
        Btn_sound.BtnClick_Sound();
        StartCoroutine("next");
    }

    public void NewId_Success()
    {
        NewId_Sani.SetBool("close", true);
        NewId_Sani.SetBool("open", false);
        Btn_sound.BtnClick_Sound();
        StartCoroutine("NewSuccess");
    }

    public void LoginBtn_Fail()
    {
        //Login 실패 팝업창 확인버튼 눌렀을시
        Login_Fani.SetBool("close", true);
        Login_Fani.SetBool("open", false);
        Btn_sound.Btn_Cancel();
        StartCoroutine("Fail");
    }

    public void NewId_Fail()
    {
        NewId_Fani.SetBool("close", true);
        NewId_Fani.SetBool("open", false);
        Btn_sound.Btn_Cancel();
        StartCoroutine("NewFail");
    }

    IEnumerator next()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Charrac");
        Login_Success.SetActive(false);
    }
    IEnumerator Fail()
    {
        yield return new WaitForSeconds(0.5f);
        Login_Fail.SetActive(false);
    }
    IEnumerator NewFail()
    {
        yield return new WaitForSeconds(0.5f);
        New_Fail.SetActive(false);
    }
    IEnumerator NewSuccess()
    {
        yield return new WaitForSeconds(0.5f);
        New_Success.SetActive(false);
        Change_Panel = false;
    }

    private void FixedUpdate()
    {
        if(Change_Panel == false)
        {
            Create_Panel.SetActive(false);
            Login_Panel.SetActive(true);
        }
        else if(Change_Panel == true)
        {
            Login_Panel.SetActive(false);
            Create_Panel.SetActive(true);
        }
    }
}
