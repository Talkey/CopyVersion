using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RefreshableObject : MonoBehaviour
{
	protected Vector2 pos;

    public void InitPosition()
	{
		pos = transform.position;
	}

	/// <summary>
	/// 刷新这个物体的所有特征于游戏开始时。
	/// 以水关卡为例，附着在R-C_0~11下面的RefreshableOcean类的Refresh()函数体中，将Puzzle组件的IsOnPos、isFinished均设为游戏开始时的false，并将位置设为了初始时的坐标。
	/// </summary>
	public virtual void Refresh()
	{
		transform.position = pos;
	}

}
