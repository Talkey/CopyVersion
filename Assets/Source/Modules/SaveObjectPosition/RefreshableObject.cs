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
	/// ˢ����������������������Ϸ��ʼʱ��
	/// ��ˮ�ؿ�Ϊ����������R-C_0~11�����RefreshableOcean���Refresh()�������У���Puzzle�����IsOnPos��isFinished����Ϊ��Ϸ��ʼʱ��false������λ����Ϊ�˳�ʼʱ�����ꡣ
	/// </summary>
	public virtual void Refresh()
	{
		transform.position = pos;
	}

}
