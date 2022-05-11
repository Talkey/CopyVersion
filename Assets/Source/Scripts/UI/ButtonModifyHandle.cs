using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RotaryHeart.Lib.SerializableDictionary;

public class ButtonModifyHandle : MonoBehaviour
{
	Button button;
	Image image;

	[Serializable]
	public class ElementToManager : SerializableDictionaryBase<Element, MapManagerClass> { }

	[SerializeField]
	ElementToManager elementManagerKVP;

	// Start is called before the first frame update
	void Start()
	{
		button = GetComponent<Button>();
		image = button.image;

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			Debug.LogWarning(button.enabled);
		}
	}

	public void Modify(BaseInstance instance)
	{
		Element element = instance.CurrentElement;
		MapManagerClass manager = elementManagerKVP.ContainsKey(element) ? elementManagerKVP[element] : null;
		bool visible = ((element != Element.None) && manager && (manager.State != LevelState.Pass));
		button.enabled = visible;
		gameObject.SetActive(visible);
		if (visible)
		{
			Color color = instance.ElementColorKVP[element];
			image.enabled = true;
			//button.colors
			image.color = color;
		}
	}
}
