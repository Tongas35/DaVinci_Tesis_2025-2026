using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 
       Singleton que orquesta el inicio del juego.
       En Start(): inicializa el mazo (DeckManager), la economia (EconomyManager) y arranca el primer turno (TurnManager).
    */

    public static GameManager Instance { get; private set; }
    [Header("Managers")]
    public PlayerDeckManager deckManager;
    public TurnManager turnManager;
    public EconomyManager economyManager;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        Debug.Assert(deckManager != null, "DeckManager no asignado en GameManager");
        Debug.Assert(turnManager != null, "TurnManager no asignado en GameManager");
        Debug.Assert(economyManager != null, "EconomyManager no asignado en GameManager");
    }

    private void Start()
    {
        deckManager.InitializeDeck();
        economyManager.InitializeEconomy();
        turnManager.StartDay();
    }
}