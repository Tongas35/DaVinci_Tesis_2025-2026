using UnityEngine;

public class ConsumingState : States
{
    Elf _client;
    
    public ConsumingState(Elf client)
    {
        _client = client;
        
    }

    public override void OnEnter()
    {
        

        _client.Globe();

        Card.onCardPlaced += HandleCardPlaced;
    }

    public override void OnExit()
    {
        Card.onCardPlaced -= HandleCardPlaced;
    }

    public override void OnUpdate()
    {
        
        
        _client.globe.gameObject.SetActive(false);
    }

    private void HandleCardPlaced(Card card, Elf elf)
    {
        if (elf == _client)
        {
            _client.OrderActionActive(card);
        }
    }
}
