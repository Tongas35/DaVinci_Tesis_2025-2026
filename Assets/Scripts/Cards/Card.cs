using System;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    DragAndDrop _dragAndDrop;
    TableOnHand _tableOnHand;
    

    public static event Action<Card, Elf> onCardPlaced;

    [SerializeField]
    private Vector3 customRotation = Vector3.zero;
    [SerializeField]
    private PositionAndRotation _positionAndRotation;

    public CardsData _cardData;
    public Position currentPosition = Position.Spawn;

    void Start()
    {
        var slotPositions = new List<TransformAndRotation>
        {
            _positionAndRotation.HandOne,
            _positionAndRotation.HandTwo,
            _positionAndRotation.HandThree,
            _positionAndRotation.HandFour,
            _positionAndRotation.TableOne,
            _positionAndRotation.TableTwo,
            _positionAndRotation.TableThree,
            _positionAndRotation.TableFour,
            _positionAndRotation.TableFive,
            _positionAndRotation.TableSix
        };

        _dragAndDrop = new DragAndDrop(transform, customRotation, _positionAndRotation);
        _tableOnHand = new TableOnHand(this, slotPositions);
    }

    void OnMouseUp()
    {
        if (currentPosition == Position.Hand)
        {
            _tableOnHand.GoObjetive();

            // Encuentra el elfo más cercano
            Elf targetElf = null;
            float minDistance = Mathf.Infinity;
            Vector3 cardPosition = transform.position;

            foreach (var elf in GameObject.FindObjectsOfType<Elf>())
            {
                float distance = Vector3.Distance(cardPosition, elf.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetElf = elf;
                }
            }

            if (targetElf != null)
            {
                
                onCardPlaced?.Invoke(this, targetElf);
            }
            else
            {
                Debug.LogWarning("No se encontró un Elf cercano para esta carta.");
            }
        }
        else if (currentPosition == Position.Spawn)
        {
            HandManager.Instance.MoveToNextSlot(this);
        }
    }

    void OnMouseDown()
    {
        if (currentPosition == Position.Hand)
            _dragAndDrop.OnMouseDownCard();
    }

    void OnMouseDrag()
    {
        if (currentPosition == Position.Hand)
            _dragAndDrop.OnMouseDragCard();
    }

    public enum Position
    {
        Spawn,
        Hand,
        Discard
    }
}
