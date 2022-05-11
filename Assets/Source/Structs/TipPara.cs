using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TipPara
{
	[SerializeField]
	bool withTab;
	public bool WithTab
	{
		get { return withTab; }
	}

	[SerializeField]
	Color wordColor;
	public Color WordColor
	{
		get { return wordColor; }
	}

	[SerializeField]
	string para;
	public string Para
	{
		get { return para; }
	}
}