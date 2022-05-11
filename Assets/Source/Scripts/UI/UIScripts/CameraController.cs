using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  Transform playerTrans;//��ҵ�λ������
    public LimitTrans[] DifMapLimit;
    public LimitTrans CurrentLimitTrans;
    [SerializeField] private float smoothLerpSpeed;//ƽ�������ɫ�ٶ�

    
    private void Start()
    {
      CurrentLimitTrans = DifMapLimit[0];
    }

    private void Update()
    {
        FollowSmooth();
       // RestrictCamera();
    }
    
    //�����ƶ�����
    private void FollowSmooth() 
    {
        //��������ɫ�ƶ����Բ�ֵ
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z), smoothLerpSpeed * Time.deltaTime);
    }

    //��������߽緽��
    private void RestrictCamera()   
    {
        Debug.LogWarning("���ڵ����ƶ�����");
        //����ڴ˷�Χ�ڿ��ƶ�
        ElementLimit();
        transform.position = 
            new Vector3(Mathf.Clamp(transform.position.x, CurrentLimitTrans.Minx.position.x, CurrentLimitTrans.Maxx.position.x),
            Mathf.Clamp(transform.position.y, CurrentLimitTrans.Miny.position.y, CurrentLimitTrans.Maxy.position.y), transform.position.z);
    }

    public void ElementLimit()
    {
        switch (BaseInstance.Baseinstance.currentElement)
        {
            case Element.Metal:
                {
                  CurrentLimitTrans=  ValueTrans (0);
                }
                break;
            case Element.Wood:
                {
                    CurrentLimitTrans = ValueTrans(1);
                }
                break;
            case Element.Ocean:
                {
                    CurrentLimitTrans = ValueTrans(2);
                }
                break;
            case Element.Fire:
                {
                    CurrentLimitTrans = ValueTrans(3);
                }
                break;
            case Element.Earth:
                {
                    CurrentLimitTrans = ValueTrans(4);
                }
                break;
        }
    }

    public LimitTrans ValueTrans(int Map_index)
    {
        CurrentLimitTrans.Maxx = DifMapLimit[Map_index].Maxx;
        CurrentLimitTrans.Maxy= DifMapLimit[Map_index].Maxy;
        CurrentLimitTrans.Minx= DifMapLimit[Map_index].Minx;
        CurrentLimitTrans.Miny= DifMapLimit[Map_index].Miny;
        return CurrentLimitTrans;
    }

}
