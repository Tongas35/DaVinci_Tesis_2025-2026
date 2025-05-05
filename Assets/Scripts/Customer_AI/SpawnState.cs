using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SpawnState : States
{


    Elf _client;
    



    public SpawnState(Elf client)
    {

       
        _client = client;
        


    }

    public override void OnEnter()
    {
        Table table = TableManager.instance.GetRandomAvailableTable();

        if (table != null)
        {
            _client.assignedTable = table;
            _client.GoToTable(table); // metodo que tengas para mover al cliente
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
