using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform Character_Pie;  //获得Pie字
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
            //播放门的旋转动画
            GetComponent<Animator>().enabled = true;
            rightDoor.GetComponent<Animator>().enabled = true;
        }
    }
    //动画事件中调用该方法
    public void GamePlay()  
    {
       // CanEnterGame = true;
        //StartMenu.SetActive(!CanEnterGame);
        //Game.SetActive(CanEnterGame);
        //Camera.main.GetComponent<CameraController>().enabled = true;
    }
}
