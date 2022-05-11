using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshableEarthManager : RefreshableObject
{
    EarthMapManager earthMapManager;

    // Start is called before the first frame update
    void Start()
    {
        earthMapManager = GetComponent<EarthMapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Refresh()
    {
        earthMapManager.Step = EarthMapManager.InitialSteps;
    }
}
