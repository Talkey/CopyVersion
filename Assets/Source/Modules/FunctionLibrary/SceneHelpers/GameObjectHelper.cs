using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectHelper
{
    /// <summary>
    /// 寻找附着在游戏物体上的组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="objectName">游戏物体名称</param>
    /// <returns>在指定物体上的指定组件对象</returns>
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
    /// 寻找附着在游戏物体上的组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="gameObject">游戏物体对象引用</param>
    /// <returns>在指定物体上的指定组件对象</returns>
    public static T FindComponent<T>(GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>();
    }

    /// <summary>
    /// 游戏物体上是否拥有某一组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="gameObject">游戏物体对象引用</param>
    /// <returns>该游戏物体上获取的该组件是否为空</returns>
    public static bool HasAComponent<T>(GameObject gameObject) where T : Component
    {
        return gameObject.GetComponent<T>();
    }

    /// <summary>
    /// 组件的父项游戏物体上是否拥有某一组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="component">组件对象引用</param>
    /// <returns>该父项游戏物体上获取的该组件是否为空</returns>
    public static bool WithAComponent<T>(Component component) where T : Component
    {
        return component.gameObject.GetComponent<T>();
    }
}
