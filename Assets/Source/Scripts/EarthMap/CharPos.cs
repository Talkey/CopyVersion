using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPos : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] charPos;
    public Transform[] RightPos;
    public int j = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckPos()
    {
        for (int i = 0; i < 4; i++)
        {
            if (charPos[i].position == RightPos[i].position)
            {
                j += 1;
            }
            else
            {
                j -= 1;
            }
            Debug.Log(j+"ok");
        }
    }
}
