using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SpawnState : States
{


    Elf _client;
    



    public SpawnState(Elf client, Table table)
    {

       
        _client = client;
        _client.table = table;


    }

    public override void OnEnter()
    {
        //Table table = TableManager.instance.GetRandomAvailableTable();

        if (_client.table != null)
        {
            _client.assignedTable = _client.table;
            _client.GoToTable(_client.table); // metodo para mover al cliente
        }
        else
        {
            Debug.Log("No hay mesas disponibles");
            
        }
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {


        _client.MoveToTarget();



    }
}
