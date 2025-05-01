using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeUI : BaseUI
{
    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}
