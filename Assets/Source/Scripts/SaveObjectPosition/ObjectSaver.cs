using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ȣ��Ƚ����п��ܱ��ƶ�����Ϸ�����¸���һ���Զ���ű����ýű���̳���RefreshableObject�������Ѿ���MonoBehaviour���࣬�����ټ̳���MonoBehaviour��������Refresh()������
/// �����Unity�༭���У��������ͼ�����п��ܻᱻ�ƶ�����Ϸ����������Զ�Ӧ�������м��ɡ�
/// </summary>
public class ObjectSaver : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��ؿ���Ϸ����ԭλ��")]
    ObjectContainer objectsInMetal;

    [SerializeField]
    [Tooltip("ľ�ؿ���Ϸ����ԭλ��")]
    ObjectContainer objectsInWood;

    [SerializeField]
    [Tooltip("ˮ�ؿ���Ϸ����ԭλ��")]
    ObjectContainer objectsInOcean;

    [SerializeField]
    [Tooltip("��ؿ���Ϸ����ԭλ��")]
    ObjectContainer objectsInFire;

    [SerializeField]
    [Tooltip("���ؿ���Ϸ����ԭλ��")]
    ObjectContainer objectsInEarth;

    Dictionary<Element, ObjectContainer> elementMapKVP;

    public ObjectSaver()
    {
        objectsInMetal = new ObjectContainer();
        objectsInWood = new ObjectContainer();
        objectsInOcean = new ObjectContainer();
        objectsInFire = new ObjectContainer();
        objectsInEarth = new ObjectContainer();
        elementMapKVP = new Dictionary<Element, ObjectContainer>()
        {
            {Element.Metal, objectsInMetal},
            {Element.Wood, objectsInWood},
            {Element.Ocean, objectsInOcean},
            {Element.Fire, objectsInFire},
            {Element.Earth, objectsInEarth},
        };
    }

    public ObjectContainer GetTargetContainer(Element element)
    {
        return elementMapKVP[element];
    }
    // Start is called before the first frame update
    void Start()
    {
        ObjectContainer[] five = new[] {objectsInMetal, objectsInWood, objectsInOcean, objectsInFire, objectsInEarth};
        foreach (ObjectContainer container in five)
        {
            container.InitPositions();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.LogWarning("R����");
            objectsInOcean.RecoverAll();
        }
    }
}
