using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; 
    [SerializeField] private float jumpForce;  
    [HideInInspector] public float moveH;  
    [SerializeField] private float moveSpeed;  //ˮƽ������ƶ��ٶ�
    public Transform checkPoint; //���ĺ���
    public LayerMask layerMask; //��������ĵ���㣬�����ж��Ƿ��������
    [SerializeField] private Vector2 checkBoxSize; 
    [SerializeField] private bool isGround;
    public bool IsGround { get { return isGround; } }
    [SerializeField] private float fallFactor; //����������������
    [SerializeField] private float shortJumpFactor; //����������������

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
        //���¿ո��ж��Ƿ�����Ծ
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
    
    //���������˶�
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
    
    //�����ƶ�ʱ��תͼƬ����
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
    
    //����Ƿ��������淽��
    private void CheckGround() 
    {
        //�������������Ӵ���λ�ں����ڲ���������ײ�塣
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

    //���ӻ������ײ���ķ�Χ����
    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(checkPoint.position, checkBoxSize);
        Gizmos.color = Color.red;
    }
    
    //ʵ���������ԾЧ������
    private void BetterJump() 
    {   
        
        if (rb.velocity.y < 0)  //������ʱ���ٶ���ʱ������
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallFactor * Time.fixedDeltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) //������������û�а��¿ո�����ٶ��𽥼�С�����䡣ʵ�ֶ���Ч��
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * shortJumpFactor * Time.fixedDeltaTime;
        }
    }
}
