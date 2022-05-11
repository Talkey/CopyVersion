using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshableEarth : RefreshableObject
{
	PuzzleEarth puzzleEarth;
	// Start is called before the first frame update
	void Start()
	{
		puzzleEarth = GetComponent<PuzzleEarth>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

    public override void Refresh()
    {
		puzzleEarth.isOnPos = false;
        base.Refresh();
    }
}
