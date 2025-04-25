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
        _fsm.ChangeState(StatesEnum.Leaving); // Cambia al estado Leaving después de consumir
    }

    public override void OnExit()
    {
        // Aquí puedes agregar lógica cuando se sale del estado, si es necesario
    }

    public override void OnUpdate()
    {
        // No es necesario realizar nada aquí por ahora
    }
}
