using System.Collections.Generic;
using UnityEngine;

public class HandManager
{
    private static HandManager _instance;
    private PositionAndRotation _positionAndRotation;
    private readonly List<TransformAndRotation> _slots;
    private readonly Dictionary<int, Transform> _occupiedSlots;
    private const float MaxDistance = 5f;
    public static HandManager Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new System.Exception("HandManager no inicializado. llama a Initialize primero");
            }
            return _instance;
        }
    }

   

    // inicializar el singleton
    public static void Initialize(PositionAndRotation positionAndRotation)
    {
        if (_instance != null)
        {
            return;
        }
        _instance = new HandManager(positionAndRotation);
    }

    private HandManager(PositionAndRotation positionAndRotation)
    {
        _positionAndRotation = positionAndRotation ?? throw new System.ArgumentNullException(nameof(positionAndRotation));

        _slots = new List<TransformAndRotation>
        {
            _positionAndRotation.HandOne,
            _positionAndRotation.HandTwo,
            _positionAndRotation.HandThree,
            _positionAndRotation.HandFour
        };


        _occupiedSlots = new Dictionary<int, Transform>();
    }


    public void MoveToNextSlot(Card card)
    {
        if (card == null)
        {

            return;
        }

        CheckAndFreeSlots();


        if (_occupiedSlots.Count >= _slots.Count)
        {

            return;
        }

        int availableSlot = ReserveAvailableSlot(card.transform);
        if (availableSlot == -1)
        {

            return;
        }
        


        Vector3 targetPos = _slots[availableSlot].position;
        Quaternion targetRot = Quaternion.Euler(_slots[availableSlot].rotation);
        

        card.transform.position = targetPos;
        card.transform.rotation = targetRot;
        card.currentPosition = Card.Position.Hand;
        
    }

    private void CheckAndFreeSlots()
    {
        var slotsToFree = new List<int>();
        foreach (var slot in _occupiedSlots)
        {
            Transform card = slot.Value;
            if (card == null ||
                !card.gameObject.activeInHierarchy)
            {
                slotsToFree.Add(slot.Key);
            }
        }
        foreach (int slotIndex in slotsToFree)
        {
            _occupiedSlots.Remove(slotIndex);
        }

    }

    private int ReserveAvailableSlot(Transform card)
    {

        for (int i = 0; i < _slots.Count; i++)
        {
            if (!_occupiedSlots.ContainsKey(i))
            {
                _occupiedSlots[i] = card;

                return i;
            }
        }
        
        return -1;
    }
}