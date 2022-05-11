using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WoodMapManager : MapManagerClass
{
    public List<Leaves> LeafList=new List<Leaves>();
    public int Step = 4;

    protected override bool IsLevelFailed()
    {
        return false;
    }

    protected override bool IsLevelPassed()
    {
        return false;
        //return LeafList.Count() <= 6;
    }

    protected override void OnLevelFailed()
    {
        Debug.LogWarning(MapName + "ʧ��");
    }

    protected override void OnLevelPassed()
    {
        Debug.LogWarning(MapName + "ͨ��");
    }

    protected override void Start()
    {
        base.Start();
        for (int Counter = 1; Counter < LeafList.Count(); Counter++)
        { 
            LeafList[Counter].gameObject.SetActive(false); 
        }
  
    }

    protected override void Update()
    {
        //base.Update();
        if (LeafList.Count() <= 8)
        {
            Debug.Log("ľ��ͼͨ��");
            MapSuccess = true;
            state = LevelState.Pass;
        }
    }
}
