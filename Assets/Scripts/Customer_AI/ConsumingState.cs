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
        _fsm.ChangeState(StatesEnum.Leaving); 
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}
