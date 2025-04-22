using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TurnPhase { Player, Client }

public class TurnManager : MonoBehaviour
{
    /*
     Controla el flujo de turnos entre dos fases: Player y Client.
     Cuenta los turnos transcurridos hasta maxTurnsPerDay, y dispara OnDayEnd al agotarlos.
     Expone eventos OnPlayerPhaseStart y OnClientPhaseStart para que otros sistemas reaccionen al cambio de fase.
    */

    public static event Action OnPlayerPhaseStart;
    public static event Action OnClientPhaseStart;
    public static event Action OnDayEnd;

    [Header("Configuración de Turnos")]
    public int maxTurnsPerDay = 20;
    private int currentTurnCount;
    public TurnPhase CurrentPhase { get; private set; }

    public void StartDay()
    {
        currentTurnCount = 0;
        BeginPlayerPhase();
    }

    private void BeginPlayerPhase()
    {
        CurrentPhase = TurnPhase.Player;
        OnPlayerPhaseStart?.Invoke();
    }

    private void BeginClientPhase()
    {
        CurrentPhase = TurnPhase.Client;
        OnClientPhaseStart?.Invoke();
    }

    public void EndPlayerPhase()
    {
        BeginClientPhase();
    }

    public void EndClientPhase()
    {
        currentTurnCount++;
        if (currentTurnCount >= maxTurnsPerDay)
        {
            OnDayEnd?.Invoke();
        }
        else
        {
            BeginPlayerPhase();
        }
    }
}