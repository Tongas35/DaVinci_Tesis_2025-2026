using UnityEngine;

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
            _client.GoToTable(table); // m�todo que tengas para mover al cliente
        }
        else
        {
            Debug.Log("No hay mesas disponibles");
            // podr�as cambiar de estado, esperar, o hacer otra cosa
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
