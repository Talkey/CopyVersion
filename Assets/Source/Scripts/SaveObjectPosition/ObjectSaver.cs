using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 首先，先将所有可能被移动的游戏物体下附着一个自定义脚本，该脚本类继承于RefreshableObject（该类已经是MonoBehaviour子类，无需再继承于MonoBehaviour），重载Refresh()函数。
/// 随后，在Unity编辑器中，将五个地图的所有可能会被移动的游戏物体拖入各自对应的数组中即可。
/// </summary>
public class ObjectSaver : MonoBehaviour
{
    [SerializeField]
    [Tooltip("金关卡游戏物体原位置")]
    ObjectContainer objectsInMetal;

    [SerializeField]
    [Tooltip("木关卡游戏物体原位置")]
    ObjectContainer objectsInWood;

    [SerializeField]
    [Tooltip("水关卡游戏物体原位置")]
    ObjectContainer objectsInOcean;

    [SerializeField]
    [Tooltip("火关卡游戏物体原位置")]
    ObjectContainer objectsInFire;

    [SerializeField]
    [Tooltip("土关卡游戏物体原位置")]
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
            Debug.LogWarning("R按下");
            objectsInOcean.RecoverAll();
        }
    }
}
