using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  Transform playerTrans;//玩家的位置坐标
    public LimitTrans[] DifMapLimit;
    public LimitTrans CurrentLimitTrans;
    [SerializeField] private float smoothLerpSpeed;//平滑跟随角色速度

    
    private void Start()
    {
      CurrentLimitTrans = DifMapLimit[0];
    }

    private void Update()
    {
        FollowSmooth();
       // RestrictCamera();
    }
    
    //跟随移动方法
    private void FollowSmooth() 
    {
        //相机跟随角色移动线性插值
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z), smoothLerpSpeed * Time.deltaTime);
    }

    //限制相机边界方法
    private void RestrictCamera()   
    {
        Debug.LogWarning("正在调用移动限制");
        //相机在此范围内可移动
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
