using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemanager : MonoBehaviour
{
    [Header("GameObject")]
    public GameObject Game;
    public GameObject Player;
    public Collider2D GateColi;
    public Camera MainCamera;
    public Animator GateAni;
    public GameObject rightDoor, leftDoor;

    [Header("地图管理器")]
    public FlameGameManager FlameGameManager;
    public OceanMapManager OceanGameManager;
    public EarthMapManager EarthGameManager;
    public WoodMapManager WoodGameManager;


    [Header("Transform")]
    public Transform startPos;
    public Transform endPos;
    public Transform Character_Pie;



    [Header("布尔值")]
    public  bool CanEnterGame = false;
    public bool EnteredGame = false;
    private bool FinishedGame = false;





    [Header("UI界面")]
    public GameObject GuoDuUI;
    public GameObject Thanks;
    public GameObject EndUI;
    public Animator EndUIAnim;
    public GameObject StartMenu;
    public ElementUpDate TransUI;
    public Button Exit;
    public GameObject Exitobj;

    [Header("最后一段的金字")]
    public GameObject wang;
    public GameObject twoPoint;
    public bool Combined = false;
    public GameObject LastDoor;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        Initialize_GetComponent();
    }

    // Update is called once per frame
    void Update()
    {
        OnTrigger();
        EnterGame();
        MapSuccess();
        if(Combined == false )
        {
            GoldenManager();
        }
        if (Combined==true&&Player.transform.position.y-wang.transform.position.y < 0.7f&& Player.transform.position.y - wang.transform.position.y > 0.1f && Input.GetMouseButtonUp(0) == true)
        {
            Debug.LogWarning("正在结束游戏点击UI过度");
            Player.SetActive(false);
            EndUI.SetActive(true);
            Exitobj.SetActive(true);
            StartMenu.SetActive(true);
            EndUIAnim.enabled = true;
            MainCamera.GetComponent<CameraController>().enabled = false;
            MainCamera.transform.position = new Vector3( endPos.position.x, endPos.position.y,MainCamera.transform.position.z);
        }

    }

    public void  EnterGame()
    {
        if (CanEnterGame == true&& EnteredGame == false&&FinishedGame==false)
        {
            if (Input.GetMouseButton(0)&& Character_Pie.rotation.y<0)
            {
                EnteredGame = true;
                TransUI.UITrans();
                Invoke("EnterGameToPlay", 1f);
            }
        }
    }

    private void OnTrigger()
    {
        if (Character_Pie.localRotation.y < 0 &&Mathf.Abs( Vector2.Distance(Character_Pie.position, startPos.position))<=0.2f)
        {
            CanEnterGame = true;
            GateAni.enabled = true;
        }
    }




    private void Initialize()
    {
        //初始化
        //Exit.enabled=false;
        Exitobj.SetActive(false);
        GateAni.enabled = false;
        EndUI.SetActive(false);
        Game.SetActive(CanEnterGame);
        StartMenu.SetActive(!CanEnterGame);
        Thanks.SetActive(FinishedGame);
        EndUIAnim.enabled = false;
        Player.SetActive(CanEnterGame);


    }

    public void EnterGameToPlay()
    {
        StartMenu.SetActive(!CanEnterGame);
        Game.SetActive(CanEnterGame);
        Camera.main.GetComponent<CameraController>().enabled = true;
        Player.SetActive(CanEnterGame);
    }


    private void Initialize_GetComponent()
    {
        MainCamera.GetComponent<CameraController>().enabled = false;
        Camera.main.GetComponent<CameraController>().enabled = false;
    }

    public void MapSuccess()
    {
        if(FlameGameManager.MapSuccess==true&&OceanGameManager.MapSuccess==true&&WoodGameManager.MapSuccess==true&&EarthGameManager.MapSuccess==true)
        {
          
            wang.SetActive(true);
            twoPoint.SetActive(true);
        }
        else
        {
           LastDoor.SetActive(false);
            wang.SetActive(false);
            twoPoint.SetActive(false);
        }
    }

    public void GoldenManager()
    {
        if(Vector2.Distance(wang.transform.position,twoPoint.transform.position)<0.5)
        {
            twoPoint.transform.position = Vector2.MoveTowards(wang.transform.position, twoPoint.transform.position, 0.02f);
            Combined = true;
            twoPoint.transform.SetParent(wang.transform);
            LastDoor.SetActive(true);
            FinishedGame = true;
            Exitobj.SetActive(true);
        }
    }

    public void ExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


    

}

