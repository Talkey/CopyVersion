using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelState
{
    [CNEnum("过程")]
    Progress,
    [CNEnum("失败")]
    Fail,
    [CNEnum("通关")]
    Pass,
}
