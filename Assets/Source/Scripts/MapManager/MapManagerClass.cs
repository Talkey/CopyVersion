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
	[CNEnum("�ؿ�����")]
	protected LevelState state;

	public LevelState State { get { return state; } }

	protected ValueChangedListener<LevelState> stateListener;

	[Header("�¼��б�")]
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

	//�ؿ��Ƿ�ʧ�ܵ��ж�������ÿ֡�ж�һ��
	protected abstract bool IsLevelFailed();

	//�Ƿ�ͨ�ص��ж�������ÿ֡�ж�һ��
	protected abstract bool IsLevelPassed();

	//���ؿ�ʧ��ʱ���������¼�������ӽ�On Level Failed Events���༭���ڲ���ʾ����
	protected abstract void OnLevelFailed();

	//��ͨ��ʱ���������¼�������ӽ�On Level Passed Events���༭���ڲ���ʾ����
	protected abstract void OnLevelPassed();

	void DisableButton()
    {
		Button recoverButton = GameObjectHelper.FindComponent<Button>("RecoverObjectButton");
		recoverButton.enabled = false;
    }

	//���ؿ�״̬�ı�ʱ��ִ���߼����������ڴ󲿷ֹؿ�����˿���ѡ�����ء�
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
