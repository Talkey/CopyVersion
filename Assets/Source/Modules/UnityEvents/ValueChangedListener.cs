using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ValueChangedListener<T>
{
	[Header("Events")]
	[SerializeField]
	UnityEvent OnValueChanged;

	public ValueChangedListener()
	{
		OnValueChanged = new UnityEvent();
	}

	T originValue;
	public T Value
	{
		get { return originValue; }
		private set
		{
			if (!value.Equals(originValue))
			{
				OnValueChanged?.Invoke();
				originValue = value;
			}
		}
	}

	public void Monitor(T val)
	{
		Value = val;
	}

	public void AddListener(UnityAction call)
	{
		OnValueChanged.AddListener(call);
	}

	public void SetPersistentListenerState(int index, UnityEventCallState state)
	{
		OnValueChanged.SetPersistentListenerState(index, state);
	}

	public void RemoveListener(UnityAction call)
	{
		OnValueChanged.RemoveListener(call);
	}

	public void RemoveAllListeners()
	{
		OnValueChanged.RemoveAllListeners();
	}
}
