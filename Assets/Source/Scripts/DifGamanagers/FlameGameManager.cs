using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlameGameManager : MapManagerClass
{
    public FlameGameObjects f1, f2, f3,f4;

    public FlameGameManager()
        : base()
    {

    }

    public IEnumerator CurrentLevelCheck()
    {

        yield return new WaitForSeconds(2f);
        
        if(f1.IsOnPos==true&& f2.IsOnPos==true&& f3.IsOnPos==true)
        {
           if(f4.IsOnPos==true)
            {
                MapSuccess = true;
            }
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public IEnumerator LevelPassed(string mapname)
    {
        if (MapSuccess == true)
        {
            Console.WriteLine(mapname + "关卡通关");
            Debug.Log(mapname + "关卡通关");
        }
        yield return new WaitForSeconds(1f);
    }


    public void UITrigger()
    {
        Console.Write("UI调用");
        Debug.Log("UI调用");
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override bool IsLevelFailed()
    {
        return false;
    }

    protected override bool IsLevelPassed()
    {
        return f1.IsOnPos && f2.IsOnPos && f3.IsOnPos;
    }

    protected override void OnLevelFailed()
    {
        Debug.LogWarning(MapName + "失败");
    }

    protected override void OnLevelPassed()
    {
        MapSuccess = true;
        Debug.LogWarning(MapName + "通关");
    }
}
