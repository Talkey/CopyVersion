using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TipCanvasComponent : MonoBehaviour
{

	[SerializeField]
	TMP_Text tipWords;

	[SerializeField]
	Button previous;

	[SerializeField]
	Button close;

	[SerializeField]
	Button next;

	[SerializeField]
	DialuogeGroup dialuogeGroup;

	// Start is called before the first frame update
	void Start()
	{
		if (dialuogeGroup == null)
		{
			return;
		}
		previous.onClick.AddListener(ToPrevious);
		close.onClick.AddListener(CloseCanvas);
		next.onClick.AddListener(ToNext);
	}

	void ToPrevious()
	{
		dialuogeGroup?.ToPrevious();
	}

	void CloseCanvas()
	{
		gameObject.SetActive(false);
	}

	void ToNext()
	{
		dialuogeGroup?.ToNext();
	}

	void SetVisibility(Button button, bool visibility)
	{
		button.gameObject.SetActive(visibility);
		button.enabled = visibility;
	}

	// Update is called once per frame
	void Update()
	{
		SetVisibility(previous, dialuogeGroup != null && dialuogeGroup.HasPrevious);
		SetVisibility(close, dialuogeGroup != null && !dialuogeGroup.HasNext);
		SetVisibility(next, dialuogeGroup != null && dialuogeGroup.HasNext);
		tipWords.text = dialuogeGroup != null ? dialuogeGroup.Now : string.Empty;
	}
}
