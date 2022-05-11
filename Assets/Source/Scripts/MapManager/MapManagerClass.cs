using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public abstract class MapManagerClass : MonoBehaviour
{
	public string MapName;
	public bool MapSuccess = false;

	[SerializeField]
	[CNEnum("关卡进程")]
	protected LevelState state;

	public LevelState State { get { return state; } }

	protected ValueChangedListener<LevelState> stateListener;

	[Header("事件列表")]
	[SerializeField]
	UnityEvent onLevelFailedEvents;

	[SerializeField]
	UnityEvent onLevelPassedEvents;

	/*public UnityEvent OnLevelFailedActions
    {
		get { return onLevelFailedActions; }
		set { onLevelFailedActions = value; }
    }

	public UnityEvent OnLevelPassedActions
    {
		get { return onLevelPassedActions; }
		set { OnLevelPassedActions = value; }
    }*/

	public MapManagerClass()
	{
		state = LevelState.Progress;
		stateListener = new ValueChangedListener<LevelState>();
		stateListener.AddListener(OnLevelStateChanged);
		onLevelFailedEvents = new UnityEvent();
		onLevelFailedEvents.AddListener(OnLevelFailed);
		onLevelPassedEvents = new UnityEvent();
		onLevelPassedEvents.AddListener(OnLevelPassed);
		onLevelPassedEvents.AddListener(DisableButton);
	}

	protected virtual void Start()
	{
		
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		state = (IsLevelFailed() ? LevelState.Fail : (IsLevelPassed() ? LevelState.Pass : state));
		stateListener.Monitor(state);
	}

	//关卡是否失败的判断条件，每帧判断一次
	protected abstract bool IsLevelFailed();

	//是否通关的判断条件，每帧判断一次
	protected abstract bool IsLevelPassed();

	//当关卡失败时触发的主事件，已添加进On Level Failed Events（编辑器内不显示）。
	protected abstract void OnLevelFailed();

	//当通关时触发的主事件，已添加进On Level Passed Events（编辑器内不显示）。
	protected abstract void OnLevelPassed();

	void DisableButton()
    {
		Button recoverButton = GameObjectHelper.FindComponent<Button>("RecoverObjectButton");
		recoverButton.enabled = false;
    }

	//当关卡状态改变时的执行逻辑，能适用于大部分关卡，因此可以选择不重载。
	protected virtual void OnLevelStateChanged()
    {
		if (state == LevelState.Fail)
        {
			onLevelFailedEvents.Invoke();
        }
		else if (state == LevelState.Pass)
        {
			onLevelPassedEvents.Invoke();
        }
    }
}
