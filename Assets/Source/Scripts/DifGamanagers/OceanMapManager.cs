using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMapManager : MapManagerClass
{
	public Puzzle[] puzzlesParticles;

	public OceanMapManager()
		:base()
	{

	}

	int randomIndex;
	// Start is called before the first frame update
	protected override void Start()
	{
		base.Start();
		randomIndex = Random.Range(0, puzzlesParticles.Length);
		SetRandomFixedPuzzleToSlot();
		//StartCoroutine(SetRandomPuzzleToSlot(target));
		//target.transform.position = Vector2.MoveTowards(target.transform.position, target.correctTrans.position, )
	}

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
	}

	public void SetRandomFixedPuzzleToSlot()
    {
		Puzzle target = puzzlesParticles[randomIndex];
		target.transform.position = target.correctTrans.position;
		target.IsOnPos = true;
		target.IsFinished = true;
	}

	public IEnumerator LevelPassed(string mapname)
	{
		if (MapSuccess == true)
		{
			Debug.Log(mapname + "关卡通关");
		}
		yield return new WaitForSeconds(1f);
	}


	public void LevelCheck()
	{
		int Counter=puzzlesParticles.Length;
		foreach (var puzzle in puzzlesParticles)
		{
			if(puzzle.IsOnPos== true)
			{
				Counter -= 1;
			}
		}
		if(Counter==0)
		{
			MapSuccess = true;
		}
	}

	protected override bool IsLevelFailed()
	{
		return false;
	}

	protected override bool IsLevelPassed()
	{
		return MapSuccess;
	}

	protected override void OnLevelFailed()
	{
		Debug.LogWarning(MapName + "失败");
	}

	protected override void OnLevelPassed()
	{
		Debug.LogWarning(MapName + "通关");
	}
}
