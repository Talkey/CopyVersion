using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsageChecker : MonoBehaviour
{

	static UsageChecker()
	{
#if UNITY_EDITOR
		if (true)
		{
			Debug.LogError("已有其他人正在使用编辑器，请于该人协商好后再修改内容。");
		}
#endif
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
