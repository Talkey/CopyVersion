using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using RotaryHeart.Lib.SerializableDictionary;

public class BaseInstance : MonoBehaviour
{
    public static BaseInstance Baseinstance;
   
    [SerializeField]
    [CNEnum("��ǰ������ڵ�ͼԪ��")]
    public Element currentElement;
    [SerializeField]
    Vector2 playerInitPosition;

    [FormerlySerializedAs("Ԫ�ظı�ʱ")]
    [SerializeField]
    ValueChangedListener<Element> elementListener;

    [Serializable]
    public class ElementToColor : SerializableDictionaryBase<Element, Color> { }

	[FormerlySerializedAs("Ԫ�ض�Ӧ��ɫ�ֵ�")]
	[SerializeField]
	ElementToColor elementColorKVP;

    public ElementToColor ElementColorKVP
    { get { return elementColorKVP; } }

	public Element CurrentElement
    {
        get { return currentElement; }
        set { currentElement = value; }
    }

    public Vector2 PlayerInitPosition
    {
        get { return playerInitPosition; }
        set { playerInitPosition = value; }
    }

    public BaseInstance()
    {
        currentElement = Element.None;
        playerInitPosition = Vector2.zero;
        elementListener = new ValueChangedListener<Element>();
    }

    void Start()
    {
        Baseinstance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
	{
        elementListener.Monitor(CurrentElement);
	}

	void OnDestroy()
	{
		elementListener.RemoveAllListeners();
	}
}
