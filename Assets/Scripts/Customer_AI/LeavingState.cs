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
        _elf.elfChat?.text.gameObject.SetActive(true);
        _elf.StartCoroutine(_elf.ExitBar());
        Debug.Log("asdasda");
        _elf.assignedTable = null;
        _table.Release();
        _elf.elfChat.Chat();
    }

    public override void OnExit()
    {
        _elf.elfChat.text.gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        
    }
}
