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
            Debug.LogError(string.Format($"游戏模式物体不存在或名称被篡改，请将其改回\"{GameModeObjectName}\"！"));
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
            Debug.LogError(string.Format($"游戏实例物体不存在或名称被篡改，请将其改回\"{GameInstanceName}\"！"));
        }
        return gameObject;
    }

    public static BaseInstance GetBaseInstance()
    {
        return GetGameInstance().GetComponent<BaseInstance>();
    }
}
