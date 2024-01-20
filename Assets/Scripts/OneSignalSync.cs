using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;

public class OneSignalSync : MonoBehaviour
{
    void Start()
    {
        OneSignal.Initialize("11245cf0-4b48-4db9-b704-9eea25d7b4e7");
    }
}
