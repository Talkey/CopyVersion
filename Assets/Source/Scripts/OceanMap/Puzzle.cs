using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform correctTrans;  //图片正确的位置
    private Vector2 startPos;  //图片一开始的位置
    [SerializeField] private bool isFinished; //拖入正确位置则完成
    public bool IsFinished { set { isFinished = value; } }

    public bool IsOnPos = false;
    private Vector3 FinshedScale;  //图片原本的大小
    public float Testspeed;

    PlayerController pc;

    OceanMapManager manager;
    private void Start()
    {
        startPos = transform.position;
        FinshedScale = transform.localScale;
        pc = GameObjectHelper.FindComponent<PlayerController>("Player");
        manager = GameObjectHelper.FindComponent<OceanMapManager>("OceanMap");
    }

    private void Update()
    {
        if (isFinished)
        {
            transform.position = Vector2.MoveTowards(transform.position, correctTrans.position, Testspeed); 
        }
    }

    //鼠标拖拽方法
    private void OnMouseDrag()
    {
        if (!isFinished)
        {
            //屏幕坐标轴转换为世界坐标轴
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        }
    }

    bool InCorrectPosition
	{
        get
        {
            return (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
               Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f);
        }
    }

    bool PlayerJumping
	{
        get
		{
            return !pc.IsGround;
		}
	}

    //鼠标松开方法
    private void OnMouseUp()
    {
        //如果图片到达正确位置，则调用不可再移动
        if (InCorrectPosition)
        {
            if (!IsOnPos) GetShrinked();
            isFinished = true;
            IsOnPos = true;
            manager.LevelCheck();
        }
        else
        {
            //transform.position = startPos;
        }
    }

    bool validMouseEnter = false;
    //鼠标进入图片则放大图片
    private void OnMouseEnter()
    {
        if (PlayerJumping) return;
        validMouseEnter = true;
        if (!isFinished)
        {
            GetMagnified();
        }     
    }
    //离开则恢复图片大小
    private void OnMouseExit()
    {
        if (!validMouseEnter) return;
        validMouseEnter = false;
        if (!isFinished)
        {
            GetShrinked();
        }
        else
        {
            transform.localScale = FinshedScale;
        } 
    }

    IEnumerator MagnifySprite()
	{
        if (!PlayerJumping)
		{
            yield return null;
		}
        else
		{
            while (PlayerJumping)
			{
                yield return new WaitForEndOfFrame();
			}
		}
        GetMagnified();
	}

    void GetMagnified()
	{
        transform.localScale += Vector3.one * 0.02f;
    }

    void GetShrinked()
	{
        transform.localScale -= Vector3.one * 0.02f;
    }
}
