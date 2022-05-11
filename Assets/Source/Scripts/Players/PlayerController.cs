using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; 
    [SerializeField] private float jumpForce;  
    [HideInInspector] public float moveH;  
    [SerializeField] private float moveSpeed;  //水平方向的移动速度
    public Transform checkPoint; //检测的盒体
    public LayerMask layerMask; //检测碰到的地面层，用以判断是否可以起跳
    [SerializeField] private Vector2 checkBoxSize; 
    [SerializeField] private bool isGround;
    public bool IsGround { get { return isGround; } }
    [SerializeField] private float fallFactor; //长跳下落重力因素
    [SerializeField] private float shortJumpFactor; //短跳下落重力因素

    public Animator PlayerAni;
    private bool canJump;

    void Start()
    {
        PlayerAni.SetBool("Walking", false);
        PlayerAni.SetBool("Jumping", false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //按下空格判断是否能跳跃
        PlayerAni.SetBool("Jumping",canJump);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            canJump = true;
        }
        moveH = Input.GetAxis("Horizontal") * moveSpeed;

        if(Mathf.Abs( Input.GetAxis("Horizontal"))>0.2)
        {
            PlayerAni.SetBool("Walking", true);
        }
        else
        {
            PlayerAni.SetBool("Walking", false);
        }
        Filp();
        CheckGround();
    }
    
    //控制物理运动
    private void FixedUpdate() 
    {
        if (canJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            canJump = false;
        }
        rb.velocity = new Vector2(moveH, rb.velocity.y);
        BetterJump();
    }
    
    //左右移动时翻转图片方法
    private void Filp() 
    {
        if (moveH > 0)
        {
            transform.localScale = new Vector3(1, 1,1);
        }
        
        if (moveH < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
        }
    }
    
    //检测是否碰到地面方法
    private void CheckGround() 
    {
        //查找与给定盒体接触或位于盒体内部的所有碰撞体。
        Collider2D collider = Physics2D.OverlapBox(checkPoint.position, checkBoxSize, 0, layerMask); 
        if (collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    //可视化检测碰撞到的范围方法
    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
        Gizmos.color = Color.red;
    }
    
    //实现马里奥跳跃效果方法
    private void BetterJump() 
    {   
        
        if (rb.velocity.y < 0)  //当下落时，速度随时间增加
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallFactor * Time.fixedDeltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) //当上升过程中没有按下空格键，速度逐渐减小并下落。实现短跳效果
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * shortJumpFactor * Time.fixedDeltaTime;
        }
    }
}
