using UnityEditor.PackageManager;
using UnityEngine;

public class ChaosState : States
{
    Elf _elf;

    public ChaosState(Elf elf, Table table)
    {
        _elf = elf;
        _elf.table = table;
    }
    public override void OnEnter()
    {
        int possibilitiesChaos = Random.Range(0, 4);

        if (possibilitiesChaos > 0)
        {
            
            if (_elf.table != null)
            {
                _elf.assignedTable = _elf.table;
                
            }
            else
            {
                Debug.Log("No hay mesas disponibles");

            }
            _elf.GlobeChaos();
            _elf.EnteredWaiting2();

        }
        else
        {
            _elf.StartCoroutine(_elf.NotExit());
        }
    }

    public override void OnExit()
    {
        
        _elf.ExitedWaiting2();
    }

    public override void OnUpdate()
    {
    }


}
