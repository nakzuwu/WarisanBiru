using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start()
    {
        Transition.Instance.FadeOut();
    }
    public void ChangeScene(string name)
    {
        Transition.Instance.FadeIn(()=>SceneManager.LoadScene(name));
    }
    public void paused(){
        Time.timeScale =0;
    }
    public void resume (){
        Time.timeScale=1;
    }
    public void exit()
    {
        Application.Quit();
    }
}
