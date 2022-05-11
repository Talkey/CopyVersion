using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementUpDate : MonoBehaviour
{
    public Animator[] elementUI;
    public GameObject[] Elements;

    public Animator TransUI;
    public GameObject Transui;
    public GameObject Player;

    public  bool Transing = false;

    public  int CurrentRandomNum = -1;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }


    //初始化所有物体不可见
    public void Initialize()
    {
        Transing = false;
        //玩家失去控制权
        Player.GetComponent<PlayerController>().enabled = false;
        
        //本身不可见
        Transui.SetActive(false);

        //动画禁止
        foreach (var element in Elements)
        {
            element.SetActive(false);
        }

        //物体不可见
        foreach (var element in elementUI)
        {
            element.GetComponent<Animator>().enabled = false;
        }

        Transui.SetActive(false);
        TransUI.GetComponent<Animator>().enabled = false;
    }

    public void UITrans()
    {
        if(Transing==false)
        {

            //随机播放一个动画
            RandomPlay();
            Debug.Log("过渡UI调用");
            Transing = true;
            Invoke("TransEnd", 2f);
        }
    }


    public void RandomPlay()
    {
        CurrentRandomNum = 0;
        Elements[0].SetActive(true);
        elementUI[0].GetComponent<Animator>().enabled=true;

        Transui.SetActive(true);
        TransUI.GetComponent<Animator>().enabled = true;
    }

    //过度结束
    public void TransEnd()
    {
        

        elementUI[0].enabled = false;
        Elements[0].SetActive(false);

        Transui.SetActive(false);
        TransUI.GetComponent<Animator>().enabled = false;
        Transing = false;
        //玩家获取脚本控制权
        Player.GetComponent<PlayerController>().enabled = true;
    }

}
