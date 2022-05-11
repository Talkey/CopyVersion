using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Obsolete("这个结构已过时，请勿使用。")]
[Serializable]
public struct ObjectPosition
{
    [SerializeField]
    RefreshableObject refreshableObject;

    Vector2 position;

    public ObjectPosition(RefreshableObject obj)
    {
        refreshableObject = obj;
        position = obj.transform.position;
    }

    public ObjectPosition(RefreshableObject obj, Vector2 pos)
    {
        refreshableObject = obj;
        position = pos;
    }

    public GameObject GObject { get { return refreshableObject.gameObject; } }
    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    public void InitPosition()
    {
        position = GObject.transform.position;
    }

    public void RecoverToInitial()
    {
        refreshableObject.Refresh();
    }
}
