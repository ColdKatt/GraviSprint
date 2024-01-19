using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : PlayerState
{
    public override void OnStateChange()
    {
        Input.SetEnable(true);
    }
}
