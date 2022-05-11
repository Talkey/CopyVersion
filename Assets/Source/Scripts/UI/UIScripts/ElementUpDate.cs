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


    //��ʼ���������岻�ɼ�
    public void Initialize()
    {
        Transing = false;
        //���ʧȥ����Ȩ
        Player.GetComponent<PlayerController>().enabled = false;
        
        //�����ɼ�
        Transui.SetActive(false);

        //������ֹ
        foreach (var element in Elements)
        {
            element.SetActive(false);
        }

        //���岻�ɼ�
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

            //�������һ������
            RandomPlay();
            Debug.Log("����UI����");
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

    //���Ƚ���
    public void TransEnd()
    {
        

        elementUI[0].enabled = false;
        Elements[0].SetActive(false);

        Transui.SetActive(false);
        TransUI.GetComponent<Animator>().enabled = false;
        Transing = false;
        //��һ�ȡ�ű�����Ȩ
        Player.GetComponent<PlayerController>().enabled = true;
    }

}
