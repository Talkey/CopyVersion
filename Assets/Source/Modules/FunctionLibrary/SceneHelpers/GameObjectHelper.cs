using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectHelper
{
    /// <summary>
    /// Ѱ�Ҹ�������Ϸ�����ϵ����
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="objectName">��Ϸ��������</param>
    /// <returns>��ָ�������ϵ�ָ���������</returns>
    public static T FindComponent<T>(string objectName) where T : Component
    {
        T comp = null;
        var obj = GameObject.Find(objectName);
        if (obj)
        {
            comp = FindComponent<T>(obj);
        }
        return comp;
    }

    /// <summary>
    /// Ѱ�Ҹ�������Ϸ�����ϵ����
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="gameObject">��Ϸ�����������</param>
    /// <returns>��ָ�������ϵ�ָ���������</returns>
    public static T FindComponent<T>(GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>();
    }

    /// <summary>
    /// ��Ϸ�������Ƿ�ӵ��ĳһ���
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="gameObject">��Ϸ�����������</param>
    /// <returns>����Ϸ�����ϻ�ȡ�ĸ�����Ƿ�Ϊ��</returns>
    public static bool HasAComponent<T>(GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>();
    }

    /// <summary>
    /// ����ĸ�����Ϸ�������Ƿ�ӵ��ĳһ���
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="component">�����������</param>
    /// <returns>�ø�����Ϸ�����ϻ�ȡ�ĸ�����Ƿ�Ϊ��</returns>
    public static bool WithAComponent<T>(Component component) where T : Component
    {
        return component.gameObject.GetComponent<T>();
    }
}
