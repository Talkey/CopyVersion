using System.Collections;
using System.Collections.Generic;
using UnityEngine;


delegate bool LeavesDelegate();

public class RiddleCaster : MonoBehaviour
{
    public string RiddleAnswer;
    public int CheckNum;
    public int CurrentNum;
    public bool AllreadyRight = false;

    public Leaves leaf;

    private LeavesDelegate LeavesDel;

    // Start is called before the first frame update
    void Start()
    {
        if(CheckNum==1)
        {
            LeavesDel = RightRiddleCheck;
            Debug.Log("木调用检查1");
        }

        if (CheckNum == 2)
        {
            LeavesDel = MulTipleCheck;
            Debug.Log("木调用检查2");
        }

        if (CheckNum == 3)
        {
            LeavesDel = TrippleCheck;
            Debug.Log("木调用检查3");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RightRiddleCheck()
    {
        return leaf.name == RiddleAnswer;
    }


    public bool MulTipleCheck()
    {

        return CurrentNum==CheckNum;
    }

    public bool TrippleCheck()
    {
        return CurrentNum == CheckNum;
    }



}
