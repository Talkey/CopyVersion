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
			Debug.LogError("��������������ʹ�ñ༭�������ڸ���Э�̺ú����޸����ݡ�");
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
