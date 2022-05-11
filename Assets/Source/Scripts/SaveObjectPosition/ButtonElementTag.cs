using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElementTag : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����ť��Ӧ��Ԫ������")]
    [CNEnum("Ԫ��")]
    Element Element;
    // Start is called before the first frame update
    void Awake()
    {
        if (!GetComponent<UnityEngine.UI.Button>())
        {
            Debug.LogError("ButtonElementTag������������֮��ĵط���" + gameObject.name + "���뽫�丽���ڰ�ť�ϣ�");
            this.enabled = false;
        }
    }
}
