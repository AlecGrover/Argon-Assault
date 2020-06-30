using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class WaypointProgressTrackerInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WaypointProgressTracker waypointProgressTracker = GetComponent<WaypointProgressTracker>();
        waypointProgressTracker.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
