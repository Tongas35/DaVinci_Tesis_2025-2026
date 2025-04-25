using UnityEngine;

public class ConsumingState : States
{
    private Elf _client;

    public ConsumingState(Elf client)
    {
        _client = client;
    }

    public override void OnEnter()
    {
        _client.globe.gameObject.SetActive(false);
        _fsm.ChangeState(StatesEnum.Leaving); // Cambia al estado Leaving despu�s de consumir
    }

    public override void OnExit()
    {
        // Aqu� puedes agregar l�gica cuando se sale del estado, si es necesario
    }

    public override void OnUpdate()
    {
        // No es necesario realizar nada aqu� por ahora
    }
}
