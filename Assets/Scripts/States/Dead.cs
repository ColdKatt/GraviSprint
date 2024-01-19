using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : PlayerState
{
    public override void OnStateChange()
    {
        Input.SetEnable(false);
    }
}
