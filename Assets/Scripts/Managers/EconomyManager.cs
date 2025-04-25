using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class EconomyManager : MonoBehaviour
{
    /*
     Singleton que gestiona Oro y Reputacion.
     Metodos AddGold(), SpendGold(), AddReputation(), y eventos OnGoldChanged/OnReputationChanged para actualizar UI.
    */

    public static EconomyManager Instance { get; private set; }

    [Header("Resources")]
    public int startingGold = 0;
    public int startingReputation = 50;

    public IntEvent OnGoldChanged;
    public IntEvent OnReputationChanged;

    private int gold;
    private int reputation;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public void InitializeEconomy()
    {
        gold = startingGold;
        reputation = startingReputation;
        OnGoldChanged?.Invoke(gold);
        OnReputationChanged?.Invoke(reputation);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        OnGoldChanged?.Invoke(gold);
    }

    public void AddReputation(int amount)
    {
        reputation = Mathf.Clamp(reputation + amount, 0, 100);
        OnReputationChanged?.Invoke(reputation);
    }

    public bool SpendGold(int cost)
    {
        if (gold < cost) return false;
        gold -= cost;
        OnGoldChanged?.Invoke(gold);
        return true;
    }

    public int GetCurrentGold() => gold;
    public int GetCurrentReputation() => reputation;
}