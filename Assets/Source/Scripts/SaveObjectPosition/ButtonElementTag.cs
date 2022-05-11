using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElementTag : MonoBehaviour
{
    [SerializeField]
    [Tooltip("这个按钮对应的元素属性")]
    [CNEnum("元素")]
    Element Element;
    // Start is called before the first frame update
    void Awake()
    {
        if (!GetComponent<UnityEngine.UI.Button>())
        {
            Debug.LogError("ButtonElementTag附着在了意料之外的地方：" + gameObject.name + "，请将其附着在按钮上！");
            this.enabled = false;
        }
    }
}
