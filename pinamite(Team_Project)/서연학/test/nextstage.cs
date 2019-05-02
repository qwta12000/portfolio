using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextstage : MonoBehaviour
{
    private string stage;
    // Start is called before the first frame update
    void Start()
    {
        stage = MgerClass.InstFunc.loadstage();
    }

    public void stagenext()
    {
        SceneManager.LoadScene(stage);
    }
    
}
