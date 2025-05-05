using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingState : States
{
    Elf _elf;
    public LeavingState(Elf elf)
    {
        _elf = elf;
    }

    public override void OnEnter()
    {
        _elf.StartCoroutine(_elf.ExitBar());
        Debug.Log("asdasda");
        _elf.assignedTable = null;
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}
