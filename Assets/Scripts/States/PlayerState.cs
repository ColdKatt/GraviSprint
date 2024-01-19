using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public void ChangeState(PlayerState state)
    {
        GameRoot.PlayerState = state;
    }

    public abstract void OnStateChange();
}
