using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DialuogeGroup
{
	[SerializeField]
	TipPara[] diaguoles;

	int index = 0;

	public bool HasNext
	{
		get
		{
			return index < diaguoles.Length - 1;
		}
	}

	public bool HasPrevious
	{
		get
		{
			return index > 0;
		}
	}

	public bool InRange
	{
		get
		{
			return (index < diaguoles.Length) && (index >= 0);
		}
	}

	public string Now
	{
		get
		{
			return diaguoles[index].Para;
		}
	}

	public void ToNext()
	{
		if (HasNext)
		{
			index++;
		}
		else
		{
			Debug.LogError("索引越界。");
		}
	}

	public void ToPrevious()
	{
		if (HasPrevious)
		{
			index--;
		}
		else
		{
			Debug.LogError("索引越界。");
		}
	}
}
