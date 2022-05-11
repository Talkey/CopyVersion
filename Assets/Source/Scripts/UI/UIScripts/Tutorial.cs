using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH;
    [SerializeField] private float moveSpeed;  //移动速度
    [SerializeField] private float jumpForce;  //跳跃高度
    private bool isJump;
    private bool isleft;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Flip();
        Move();
    }
    private void Move()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        if (moveH <= 0&&isleft==false)
        {
            moveH = 0;
        }
        rb.velocity = new Vector2(moveH, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)&&isJump)
        {
            if (rb.velocity.y == 0)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "piena")
        {
            other.transform.SetParent(transform);
            isJump = true;
            isleft = true;
        }
        if(Input.GetMouseButton(0)&&transform.eulerAngles.y==180)
        {

        }
    }
    private void Flip()
    {
        if (moveH > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveH < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
