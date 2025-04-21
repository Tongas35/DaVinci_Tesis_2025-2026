using UnityEngine;

public class WaitingState : States
{
    private readonly Elf _elf;
    private bool _cardPlaced = false;

    public WaitingState(Elf elf)
    {
        _elf = elf;
    }

    public override void OnEnter()
    {
        Debug.Log("entrando en estado Waiting...");
        _cardPlaced = false;
        
        Card.onCardPlaced += OnCardPlaced;
        _elf.Globe();
    }

    public override void OnUpdate()
    {
        
        if (_cardPlaced)
        {
            Debug.Log("carta colocada, cambiando a ConsumingState.");
            _fsm.ChangeState(StatesEnum.Consuming);
        }
    }

    public override void OnExit()
    {
        Debug.Log("saliendo de estado Waiting...");
        
        Card.onCardPlaced -= OnCardPlaced;
    }

   
    private void OnCardPlaced(Card card, Elf elf)
    {
        if (elf == _elf) 
        {
            
            _cardPlaced = true;
        }
    }
}