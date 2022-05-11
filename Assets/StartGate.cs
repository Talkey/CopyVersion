using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public Transform Character_Pie;  //»ñµÃPie×Ö
    public gamemanager gamemanager;
    public GameObject rightDoor,leftDoor;

    public void GamePlay()
    {
        gamemanager.CanEnterGame = true;
    }

    private void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

}
