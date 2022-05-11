using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlameGameObjects : MonoBehaviour, MapInterface
{
	//蜡烛本身部分
	public  Transform FollowTrans;//影子需要跟随的物体的坐标
	public Transform RayCastStartPos1;//射线检测的开始点
	public Transform RayCastStartPos2;    //第二个射线检测
	public GameObject Flame;//蜡烛的火焰
	private Vector2 Direction1, Direction2;//射线检测的左右两个方向
	private RaycastHit2D FlameHitLeft, FlameHitRight;//射线检测的发射器
	private float RayCastDistance=1f;


	//影子部分
	public GameObject Shadow;//物体影子
	public Transform ShadowTrans;
	public bool IsOnPos = false;
	public float distance;
	public Transform TargetTrans;
	[SerializeField]
	private bool PlayerReachedNear = false;
	public bool PlayerReached { set { PlayerReachedNear = value; } }

	[NonSerialized]
	ValueChangedListener<bool> flameIgniteListener;

	bool isFlameIgnite;

	void Start()
	{
		distance = 0.2f;
		Direction1 = new Vector2(1,0);
		Direction2 = new Vector2(-1, 0);
		flameIgniteListener = new ValueChangedListener<bool>();
		flameIgniteListener.AddListener(InfluenceFlame);
		Flame.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		StartCoroutine(Inteact_Object_RayCastCheck());
		StartCoroutine(PositionCheck());
		flameIgniteListener.Monitor(PlayerReachedNear);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="followtarg"></param>
	public void ShadowTransUpdate(Transform followtarg)
	{
		if (PlayerReachedNear && (!IsOnPos))
		{
			Vector2 Player_Candle_Distance = this.transform.position - followtarg.position;
			Shadow.transform.position = new Vector2(followtarg.position.x - Player_Candle_Distance.x, followtarg.position.y - Player_Candle_Distance.y);
		}
	}


	public IEnumerator Inteact_Object_RayCastCheck()
	{
		FlameHitLeft = Physics2D.Raycast(RayCastStartPos1.position, Direction1, RayCastDistance);
		FlameHitRight = Physics2D.Raycast(RayCastStartPos2.position, Direction2, RayCastDistance);
		if (FlameHitLeft.collider != null || FlameHitRight.collider != null)
		{
			InputEvent();
		}
		yield return new WaitForSeconds(1f);
		ShadowTransUpdate(FollowTrans);
	}

	public void InputEvent()
	{
		if (Input.GetMouseButton(0))
		{
			//Debug.Log("检测到玩家点燃蜡烛");
			PlayerReachedNear = true;
			
		}
	}

	public void InfluenceFlame()
	{
		if (PlayerReachedNear) FlameIgnited();
		else FlameExtinguished();
	}

	void FlameIgnited()
	{
		Flame.SetActive(true);
		Shadow.SetActive(true);
	}

	void FlameExtinguished()
	{
		Flame.SetActive(false);
		Shadow.SetActive(false);
		IsOnPos = false;
		PlayerReachedNear = false;
	}

	public IEnumerator LevelPassed()
	{
		yield return null;
	}

	IEnumerator PositionCheck()
	{
		yield return null;
		if (Vector2.Distance(ShadowTrans.position, TargetTrans.position) <= distance)
		{
			IsOnPos = true;
			ShadowTrans.position = Vector2.MoveTowards(ShadowTrans.position, TargetTrans.position, 0.03f);
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

}
