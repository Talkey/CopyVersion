using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform Character_Pie;  //���Pie��
    /*
    private bool CanEnterGame = false;
    private bool FinishedGame = false;
    */
    public GameObject StartMenu;
    public GameObject Game;
    public GameObject rightDoor;
    private void Update()
    {
        if(Input.GetMouseButton(0) && Character_Pie.localRotation.y < 0)
        {
            //�����ŵ���ת����
            GetComponent<Animator>().enabled = true;
            rightDoor.GetComponent<Animator>().enabled = true;
        }
    }
    //�����¼��е��ø÷���
    public void GamePlay()  
    {
       // CanEnterGame = true;
        //StartMenu.SetActive(!CanEnterGame);
        //Game.SetActive(CanEnterGame);
        //Camera.main.GetComponent<CameraController>().enabled = true;
    }
}
