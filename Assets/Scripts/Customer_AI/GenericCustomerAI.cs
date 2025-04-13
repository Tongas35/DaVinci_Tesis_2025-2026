using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericCustomerAI : MonoBehaviour
{
    public CustomerState currentState;
    public float stateTimer;
    public float waitTime = 5f; // Tiempo de espera para decidir o consumir, etc.

    // Variables base para personalizar segun la raza (esto va a ser util cuando haya herencias de este code y cuando haya logica ya aplicada)
    public string customerRace;
    public float tolerance;
    public float reputationModifier;

    protected virtual void Start()
    {
        TransitionToState(CustomerState.Spawn); // Aparece el cliente, inicializando con el estado Spawn
    }

    protected virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        switch (currentState)
        {
            case CustomerState.Spawn:
                OnSpawn();
                break;
            case CustomerState.Deciding:
                OnDeciding();
                break;
            case CustomerState.Waiting:
                OnWaiting();
                break;
            case CustomerState.Consuming:
                OnConsuming();
                break;
            case CustomerState.Leaving:
                OnLeaving();
                break;
            case CustomerState.Crisis:
                OnCrisis();
                break;
        }
    }

    public void TransitionToState(CustomerState newState)
    {
        currentState = newState;
        stateTimer = waitTime;  // Reiniciar el temporizador para el nuevo estado
        
        // Agregar algo que haga falta? (animaciones, notificaciones, etc.)
    }

    protected virtual void OnSpawn()
    {
        // Entra, se mueve, se sienta y despues del Timer, arranca a decidir que quiere
        
        if (stateTimer <= 0)
        {
            TransitionToState(CustomerState.Deciding);
        }
    }

    protected virtual void OnDeciding()
    {
        // Logica de elección de pedido basandose en la raza y preferencias

        if (stateTimer <= 0)
        {
            // Funcion para pedir la carta de receta

            TransitionToState(CustomerState.Waiting);
        }
    }

    protected virtual void OnWaiting()
    {
        // Espera a que se le sirva la carta asignada
        
        /*if(clientServed)
        {
            Logica para pasar a OnConsuming()
            return;
        }*/

        if (tolerance <= 0)
        {
            // Se agota la tolerancia, y habria chance de crisis o leave
            float crisisChance = Random.Range(0, 100);
            
            if (crisisChance >= 10)
            {
                TransitionToState(CustomerState.Leaving);
            }
            else if (crisisChance < 10)
            {
                TransitionToState(CustomerState.Crisis);
            }
        }
    }

    protected virtual void OnConsuming()
    {
        // El cliente consume la carta, aplicando efectos (tolerancia, reputacion, etc.)
        
        if (stateTimer <= 0)
        {
            TransitionToState(CustomerState.Leaving);
        }
    }

    protected virtual void OnLeaving()
    {
        // Animacion del cliente y limpieza de la escena.

        Destroy(gameObject);
    }

    protected virtual void OnCrisis()
    {
        // Logica para los clientes en crisis.

        if (stateTimer <= 0)
        {
            TransitionToState(CustomerState.Leaving);
        }
    }
}

public enum CustomerState
{
    Spawn,
    Deciding,
    Waiting,
    Consuming,
    Leaving,
    Crisis,
}
