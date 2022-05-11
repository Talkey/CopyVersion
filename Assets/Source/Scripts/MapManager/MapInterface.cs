using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MapInterface
{
    //单关卡检测器
    IEnumerator CurrentLevelCheck();

    //UI调用
    public void UITrigger();

    //教学引导UI调用
    public void OnTeachTrigger();

    //射线检测器
    public IEnumerator Inteact_Object_RayCastCheck();

    //玩家输入事件
    public void InputEvent();

    //关卡通过更新函数
    public IEnumerator LevelPassed();

}
