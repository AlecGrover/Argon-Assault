using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Bullets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(10 * (transform.parent.localPosition.y - 2) - 10 * CrossPlatformInputManager.GetAxis("Vertical"), -5f, 0f));
    }
}
