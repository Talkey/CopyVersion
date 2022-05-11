using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshableFire : RefreshableObject
{
    FlameGameObjects flameGameObjects;
    // Start is called before the first frame update
    void Start()
    {
        flameGameObjects = GetComponent<FlameGameObjects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Refresh()
	{
        flameGameObjects.PlayerReached = false;
	}
}
