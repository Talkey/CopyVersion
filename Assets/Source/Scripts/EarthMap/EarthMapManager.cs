using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMapManager: MapManagerClass
{
	public List<PuzzleEarth> puzzleEarths;
	public int Step;
	
	public static int InitialSteps { get { return 10; } }

	public EarthMapManager()
		:base()
	{
		Step = InitialSteps;
	}
	
	//便利Puzzle列表判断是否onPos
	IEnumerator LevelCheck()
	{
		yield return new WaitForSeconds(2f);
		if(Step==0&&puzzleEarths.Count>0)
		{
			state = LevelState.Fail;
			
		}
		else if(puzzleEarths.Count==0)
		{

			//Debug.Log("土关卡游戏成功");
			MapSuccess = true;
			state = LevelState.Pass;
		}
	}

	protected override void Start()
	{
		base.Start();
		//puzzleEarths = new List<PuzzleEarth>();
	}

	protected override void Update()
	{
		base.Update();
		//StartCoroutine(LevelCheck());
	}

	protected override bool IsLevelFailed()
	{
		return Step == 0 && puzzleEarths.Count > 0;
	}

	protected override bool IsLevelPassed()
	{
		return puzzleEarths.Count == 0;
	}

	protected override void OnLevelFailed()
	{
		Debug.LogWarning(MapName + "失败");
	}

	protected override void OnLevelPassed()
	{
		MapSuccess = true;
		Debug.LogWarning(MapName + "通关");
	}
}
