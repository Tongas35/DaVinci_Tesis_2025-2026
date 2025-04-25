using UnityEngine;

public class WaitingState : States
{
    private readonly Elf _elf;

    public WaitingState(Elf elf)
    {
        _elf = elf;
    }

    public override void OnEnter()
    {
        Debug.Log("entrando en estado Waiting...");
        _elf.Globe();
        _elf.EnteredWaiting(); // Suscribimos el elfo al evento onCardPlaced
    }

    public override void OnUpdate()
    {
        // Lógica no necesaria en Update
    }

    public override void OnExit()
    {
        Debug.Log("saliendo de estado Waiting...");
        _elf.ExitedWaiting(); // Desuscribimos al elfo del evento onCardPlaced
    }
}
