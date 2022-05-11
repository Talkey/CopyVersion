using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves :MonoBehaviour
{
    public bool IsOnPos = false;
    public float testspeed;
    public SpriteRenderer spriteRenderer;
    
    public  Animator LeafAni;
    // Start is called before the first frame update

    private void Start()
    {
        IsOnPos = false;
    }

    private void OnMouseDrag()
    {
        //屏幕坐标轴转换为世界坐标轴
        if (IsOnPos == false)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
          Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
    }



}
