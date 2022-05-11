using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCharacter_0 : MonoBehaviour
{
    private bool[] ShadowOnPos;
    public Transform[] ShadowTrans; 
    public Transform[] TargetTrans;
    public GameObject[] Candle;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       // StartCoroutine(PositionCheck());
    }
    /*
    IEnumerator PositionCheck()
    {
        yield return null;
        foreach(Transform shadowtrans in ShadowTrans)
        {
            int i = 0;
            if (Vector2.Distance(shadowtrans.position,TargetTrans[i].position) <= distance)
            {
                Candle[i].GetComponent<FlameGameObjects>().enabled = false;
                SetOnPos(shadowtrans, TargetTrans[i++]);
            }

        }

    }

    public void SetOnPos(Transform ShadowTrans, Transform TargetTrans)
    {
        ShadowTrans.position = TargetTrans.position;
    }
    */

}
