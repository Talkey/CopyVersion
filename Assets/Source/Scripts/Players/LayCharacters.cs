using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayCharacters : MonoBehaviour
{
    public GameObject[] Character;
    public Transform CharacterGeneratePos;
    // Start is called before the first frame update
    void Start()
    {
        CharacterGeneratePos = GameObject.FindGameObjectWithTag("CharacterGeneratePos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        InputButton();
        //Update();
    }

    public void InputButton()
    {
        if(Input.GetKeyDown(KeyCode.K) ==true)
        {
            GameObject f1;
           f1=Instantiate(Character[0],CharacterGeneratePos.position, Quaternion.identity);
            Debug.Log("°´¼ü°´ÏÂ");
        }
    }

    
}
