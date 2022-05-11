using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverButtonHandle : MonoBehaviour
{

	ObjectSaver saver;
	BaseInstance instance;
	GameObject player;

	// Start is called before the first frame update
	void Start()
	{
		saver = GameObjectHelper.FindComponent<ObjectSaver>(GameModeHandle.GameModeObjectName);
		instance = GameObjectHelper.FindComponent<BaseInstance>(GameModeHandle.GameInstanceName);
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/// <summary>
	/// »Ö¸´°´Å¥ÊÂ¼þ¡£
	/// </summary>
	public void RecoverObjectsInCurrentElement()
	{
		if (instance.CurrentElement == Element.None)
		{
			return;
		}
		ObjectContainer container = saver.GetTargetContainer(instance.CurrentElement);
		container.RecoverAll();
		player.transform.position = instance.PlayerInitPosition;
	}
}
