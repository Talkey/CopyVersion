using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleLeaf :Leaves
{
    public Transform TargetTrans;
    public GameObject[] NextgameObjects;
    public WoodMapManager WoodMapManager;

    void Start()
    {
        IsOnPos = false;
        foreach (GameObject obj in NextgameObjects)
        {
            obj.SetActive(false);
            Debug.Log("����������Ҷ");
            obj.GetComponent<Animator>().enabled = false;
        }
    }

    void Update()
    {
        if (IsOnPos == false)
        {
            TransToPos();
        }
    }


    private void TransToPos()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, TargetTrans.position)) < 0.5f)
        //��ȷ���
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetTrans.position, testspeed);
            Debug.Log("Ҷ���ƶ�����");
            
            WoodMapManager.Step--;
            WoodMapManager.LeafList.Remove(this);
            if(Mathf.Abs(Vector2.Distance(transform.position, TargetTrans.position)) < 0.02f)
            {
                Active();
                IsOnPos = true;
            }
        }
    }

    public void Active()
    {
        foreach (var obj in NextgameObjects)
        {
            obj.SetActive(true);
            obj.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnMouseUp()
    {
        if (IsOnPos == false)
        {
            //��ʧ
        }
        if (IsOnPos == true)
        {
            Active();
        }
    }

}
