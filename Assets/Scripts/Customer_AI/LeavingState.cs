using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingState : States
{
    Elf _elf;
    Table _table;
    public LeavingState(Elf elf, Table table)
    {
        _elf = elf;
        _table = table; 
    }

    public override void OnEnter()
    {
        _elf.StartCoroutine(_elf.ExitBar());
        Debug.Log("asdasda");
        _elf.assignedTable = null;
        _table.Release();
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}
