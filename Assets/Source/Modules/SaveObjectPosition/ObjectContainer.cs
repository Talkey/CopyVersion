using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ObjectContainer
{
    [SerializeField]
    RefreshableObject[] objReferences;

    public void InitPositions()
    {
        /*for (int i = 0; i < objReferences.Length; i++)
        {
            objReferences[i].Position = objReferences[i].GObject.transform.position;
        }*/
        for (int i = 0; i < objReferences.Length; i++)
        {
            objReferences[i].InitPosition();
        }
    }

    public void RecoverAll()
    {
        for (int i = 0; i < objReferences.Length; i++)
        {
            objReferences[i].Refresh();
        }
    }

    /*public Dictionary<GameObject, Vector2> ToDictioary()
    {
        Dictionary<GameObject, Vector2> dict = new Dictionary<GameObject, Vector2>();
        foreach(var obj in objReferences)
        {
            dict.Add(obj.GObject, obj.Position);
        }
        return dict;
    }*/
}
