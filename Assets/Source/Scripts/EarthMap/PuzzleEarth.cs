using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEarth : MonoBehaviour
{
	public EarthMapManager mapManager;
	
	
	public Transform TargetTrans;
	public CharPos charcheck;


	public float TestSpeed;
	public bool isOnPos;


	private void Start()
	{

	}

	private void Update()
	{

		Trans();
	}

	//鼠标拖拽方法
	private void OnMouseDrag()
	{
		//屏幕坐标轴转换为世界坐标轴
		transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
		Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
	}


	public void Trans()
	{
		if (Mathf.Abs(Vector2.Distance(transform.position, TargetTrans.position)) < 0.5f)
		{
			transform.position = Vector2.MoveTowards(transform.position, TargetTrans.position, TestSpeed);
			isOnPos= true;
		}
	}

    private void OnMouseUp()
    {
		mapManager.Step--;
		if(isOnPos==true)
        {
			mapManager.puzzleEarths.Remove(this);
		}
    }
}

