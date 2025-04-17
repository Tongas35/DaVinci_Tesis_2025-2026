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

    // Aca estan los pesos de cada preferencia, y se asignan en cada herencia por medio de DefineCategoryWeights()
    protected Dictionary<Category, int> categoryWeights;

    protected virtual void Awake()
    {
        // Se crea el diccionario y se completa en cada clase que haya con herencia de esta misma
        categoryWeights = new Dictionary<Category, int>();
        DefineCategoryWeights();
    }

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
        if (stateTimer <= 0)
        {
            // Seleccionamos el tipo de carta pedida segun los pesos de chance asigados por raza
            Category chosen = SelectCategory();

            // Se llama al sistema de cartas para pedir una receta de ese tipo
            RequestRecipe(chosen);

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

    private Category SelectCategory()
    {
        // Se tira el random
        int roll = Random.Range(0, 100);
        
        // variable que va tomando el random y comparandolo contra cada categoria
        int cumulative = 0;
        
        // kv = keyValue - Si es kv.Value chequea el peso/chance asignado, si es kv.Key chequea la categoria
        foreach (var kv in categoryWeights)
        {
            cumulative += kv.Value;
            
            // chequea si el roll le dio dentro de una categoria o si se paso y tiene que ir a otra
            if (roll < cumulative)
                return kv.Key;
        }
        
        // En caso de que cumulative se pase de 100, devolvemos la primera de las categorias en el diccionario
        foreach (var kv in categoryWeights)
            return kv.Key;
        
        // Y esto es por si todo falla, aunque nunca tendria por que llegar aca
        return Category.Light;
    }

    // ESTE METODO SE IMPLEMENTA EN CADA HERENCIA 
    protected virtual void DefineCategoryWeights()
    {
        // Carga de Testeo, suman 100 dividido equitativamente
        categoryWeights[Category.Light] = 25;
        categoryWeights[Category.Strong] = 25;
        categoryWeights[Category.Exotic] = 25;
        categoryWeights[Category.Meal] = 25;
    }

    // Debug de llamada al sistema de cartas
    protected void RequestRecipe(Category cat)
    {
        Debug.Log($"{customerRace} pide una {cat}");
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

public enum Category
{   
    Light,
    Strong,
    Exotic,
    Meal
}
