using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Transform correctTrans;  //ͼƬ��ȷ��λ��
    private Vector2 startPos;  //ͼƬһ��ʼ��λ��
    [SerializeField] private bool isFinished; //������ȷλ�������
    public bool IsFinished { set { isFinished = value; } }

    public bool IsOnPos = false;
    private Vector3 FinshedScale;  //ͼƬԭ���Ĵ�С
    public float Testspeed;

    PlayerController pc;

    OceanMapManager manager;
    private void Start()
    {
        startPos = transform.position;
        FinshedScale = transform.localScale;
        pc = GameObjectHelper.FindComponent<PlayerController>("Player");
        manager = GameObjectHelper.FindComponent<OceanMapManager>("OceanMap");
    }

    private void Update()
    {
        if (isFinished)
        {
            transform.position = Vector2.MoveTowards(transform.position, correctTrans.position, Testspeed); 
        }
    }

    //�����ק����
    private void OnMouseDrag()
    {
        if (!isFinished)
        {
            //��Ļ������ת��Ϊ����������
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        }
    }

    bool InCorrectPosition
	{
        get
        {
            return (Mathf.Abs(transform.position.x - correctTrans.position.x) <= 0.5f &&
               Mathf.Abs(transform.position.y - correctTrans.position.y) <= 0.5f);
        }
    }

    bool PlayerJumping
	{
        get
		{
            return !pc.IsGround;
		}
	}

    //����ɿ�����
    private void OnMouseUp()
    {
        //���ͼƬ������ȷλ�ã�����ò������ƶ�
        if (InCorrectPosition)
        {
            if (!IsOnPos) GetShrinked();
            isFinished = true;
            IsOnPos = true;
            manager.LevelCheck();
        }
        else
        {
            //transform.position = startPos;
        }
    }

    bool validMouseEnter = false;
    //������ͼƬ��Ŵ�ͼƬ
    private void OnMouseEnter()
    {
        if (PlayerJumping) return;
        validMouseEnter = true;
        if (!isFinished)
        {
            GetMagnified();
        }     
    }
    //�뿪��ָ�ͼƬ��С
    private void OnMouseExit()
    {
        if (!validMouseEnter) return;
        validMouseEnter = false;
        if (!isFinished)
        {
            GetShrinked();
        }
        else
        {
            transform.localScale = FinshedScale;
        } 
    }

    IEnumerator MagnifySprite()
	{
        if (!PlayerJumping)
		{
            yield return null;
		}
        else
		{
            while (PlayerJumping)
			{
                yield return new WaitForEndOfFrame();
			}
		}
        GetMagnified();
	}

    void GetMagnified()
	{
        transform.localScale += Vector3.one * 0.02f;
    }

    void GetShrinked()
	{
        transform.localScale -= Vector3.one * 0.02f;
    }
}
