using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshableOcean : RefreshableObject
{
    Puzzle puzzleComponent;

    // Start is called before the first frame update
    void Start()
    {
        puzzleComponent = GetComponent<Puzzle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Refresh()
	{
        base.Refresh();
        puzzleComponent.IsOnPos = false;
        puzzleComponent.IsFinished = false;
	}
}
