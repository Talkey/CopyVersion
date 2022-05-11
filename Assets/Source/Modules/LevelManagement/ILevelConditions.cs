using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelConditions
{
    bool IsLevelFailed();

    bool IsLevelPassed();
}
