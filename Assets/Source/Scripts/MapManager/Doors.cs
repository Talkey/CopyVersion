using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Doors : MonoBehaviour, MapInterface
{
    //BoomBoomHan edited in 2022,3,6,16:00
    [SerializeField]
    [CNEnum("地图元素")]
    Element mapElement;

    public Transform TransToTargetPos;
    public Transform ThisTrans;
    public Transform RayCastStartPos;
    public Transform PlayerTrans;
    public GameObject Map;

    public Ray2D PlayerColiderCast;
    public Vector2 RayCastDirection;

    [SerializeField] private int AudioNum;  //音乐编号

    public int DoorIndex;
    public float RayCastDistance;
    public bool isInTrigger = false;
    protected bool Passed = false;

    public ElementUpDate TransUI;

    // Start is called before the first frame update
    void Start()
    {
        Map.SetActive(false);
        ThisTrans = this.transform;
    }

    public Vector2 ReturnTargetTrans()
    {
        return TransToTargetPos.position;
    }

    private void Update()
    {
        StartCoroutine(Inteact_Object_RayCastCheck());
        InputEvent();
    }


    public IEnumerator Inteact_Object_RayCastCheck()
    {
        Console.WriteLine("协程启动");
        
        RaycastHit2D hit = Physics2D.Raycast(RayCastStartPos.position, RayCastDirection, RayCastDistance);
        Debug.DrawRay(RayCastStartPos.position, RayCastDirection, Color.red);
        //是否检测到玩家的tag
        if (hit.collider != null)
        {
            Console.WriteLine(this.tag + DoorIndex.ToString() + "检测到玩家!");

            Console.WriteLine("协程更新");
            isInTrigger = true;

            yield return new WaitForSeconds(1f);
            Console.WriteLine(hit.collider.ToString());
        }
        if (hit.collider == null)
        {
            Console.WriteLine("玩家离开");
            isInTrigger = false;
            yield return new WaitForSeconds(1f);
        }
    }

    public  void InputEvent()
    {
        if (Input.GetMouseButtonDown(0) && isInTrigger == true&&TransUI.Transing==false)
        {
            TransUI.Initialize();
            Map.SetActive(true);
            Console.WriteLine("传送外");
            //ui转黑函数
            //UItrans();
            //位置判定
            isInTrigger = false;

            TransUI.UITrans();

            
            Map.SetActive(true);
            AudioManager.instance.MapMusic(AudioNum);

            PlayerTrans.position = TransToTargetPos.position;
            //BoomBoomHan edited in 2022,3,6,16:00
            BaseInstance instance = GameModeHandle.GetBaseInstance();
            instance.CurrentElement = mapElement;
            instance.PlayerInitPosition = TransToTargetPos.position;
        }


        if (Input.GetMouseButtonDown(1) && TransUI.Transing == false)
        {
            TransUI.Initialize();
            TransUI.UITrans();
            Debug.Log("传送回");
            PlayerTrans.position = ThisTrans.position;
            Map.SetActive(false);
            AudioManager.instance.StartMapMusic();
        }
    }


    public IEnumerator CurrentLevelCheck()
    {
        throw new NotImplementedException();
    }

    public void UITrigger()
    {
        throw new NotImplementedException();
    }

    public void OnTeachTrigger()
    {
        throw new NotImplementedException();
    }



    public IEnumerator LevelPassed()
    {
        yield return null;
    }

}
