using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshableOceanManager : RefreshableObject
{
    OceanMapManager oceanMapManager;
    // Start is called before the first frame update
    void Start()
    {
        oceanMapManager = GetComponent<OceanMapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Refresh()
    {
        oceanMapManager.SetRandomFixedPuzzleToSlot();
    }
}
