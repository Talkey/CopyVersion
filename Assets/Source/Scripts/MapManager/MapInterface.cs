using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MapInterface
{
    //���ؿ������
    IEnumerator CurrentLevelCheck();

    //UI����
    public void UITrigger();

    //��ѧ����UI����
    public void OnTeachTrigger();

    //���߼����
    public IEnumerator Inteact_Object_RayCastCheck();

    //��������¼�
    public void InputEvent();

    //�ؿ�ͨ�����º���
    public IEnumerator LevelPassed();

}
