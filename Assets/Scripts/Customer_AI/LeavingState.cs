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
        _elf.assignedTable = null;
        _table.Release();
        if (_elf.countGood == 2)
        {
            _elf.elfChat?.text.gameObject.SetActive(true);
            _elf.elfChat?.Chat();

        }

        if (_elf.tolerance <= 0)
        {
            _fsm.ChangeState(StatesEnum.Chaos);

        }
        else 
        {
            _elf.StartCoroutine(_elf.NotExit());
        }
    }

    public override void OnExit()
    {
        _elf.elfChat?.text.gameObject.SetActive(false);
    }

    public override void OnUpdate()
    {
        
    }
}
