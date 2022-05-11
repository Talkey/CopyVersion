using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameModeHandle
{
    public static bool Clicked = false;

    public static string GameModeObjectName
    {
        get { return "GameModeBase"; }
    }

    public static GameObject GetGameMode()
    {
        GameObject gameObject = GameObject.Find(GameModeObjectName);
        if (!gameObject)
        {
            Debug.LogError(string.Format($"��Ϸģʽ���岻���ڻ����Ʊ��۸ģ��뽫��Ļ�\"{GameModeObjectName}\"��"));
        }
        return gameObject;
    }

    public static string GameInstanceName
    {
        get { return "GameInstance"; }
    }

    public static GameObject GetGameInstance()
    {
        GameObject gameObject = GameObject.Find(GameInstanceName);
        if (!gameObject)
        {
            Debug.LogError(string.Format($"��Ϸʵ�����岻���ڻ����Ʊ��۸ģ��뽫��Ļ�\"{GameInstanceName}\"��"));
        }
        return gameObject;
    }

    public static BaseInstance GetBaseInstance()
    {
        return GetGameInstance().GetComponent<BaseInstance>();
    }
}
