using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    DragAndDrop _dragAndDrop;
    TableOnHand _tableOnHand;

    [HideInInspector]
    public Vector3 originalPosition;
    [HideInInspector]
    public Quaternion originalRotation;


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

            _positionAndRotation.TableOne,
            _positionAndRotation.TableTwo,
            _positionAndRotation.TableThree,
            _positionAndRotation.TableFour,
            _positionAndRotation.TableFive,
            _positionAndRotation.TableSix,
            _positionAndRotation.TableSeven,
            _positionAndRotation.TableEight,
            _positionAndRotation.TableNine,
        };

        _dragAndDrop = new DragAndDrop(transform, customRotation, _positionAndRotation);
        _tableOnHand = new TableOnHand(this, slotPositions);

        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void OnMouseUp()
    {
        if (currentPosition == Position.Hand)
        {
            // 1) Buscamos el Elf más cercano
            Elf targetElf = null;
            float minDistance = Mathf.Infinity;
            Vector3 cardPos = transform.position;
            foreach (var elf in GameObject.FindObjectsOfType<Elf>())
            {
                float d = Vector3.Distance(cardPos, elf.transform.position);
                if (d < minDistance)
                {
                    minDistance = d;
                    targetElf = elf;
                }
            }

            if (targetElf != null && targetElf.assignedTable != null)
            {
                // 2) Obtenemos la posición y rotación del slot ocupado
                TableID id = targetElf.assignedTable._tableID;      // expongo TableID en Table
                TransformAndRotation slot = GetTransformAndRotationFor(id);

                Debug.Log(id.Serialize());

                // 3) Comprobamos umbral de proximidad
                float threshold = 5f;
                if (Vector3.Distance(cardPos, slot.position) <= threshold)
                {
                    // 4) Movemos la carta directamente al slot ocupado
                    transform.position = slot.position;
                    transform.rotation = Quaternion.Euler(slot.rotation);
                    currentPosition = Position.Discard;  // o el estado que toque

                    onCardPlaced?.Invoke(this, targetElf);
                }
                else
                {
                    // No estaba cerca: la devolvemos a la mano
                    transform.position = originalPosition;
                    transform.rotation = originalRotation;
                }
            }
            else
            {
                Debug.LogWarning("No se encontro ningun Elf con mesa asignada");
                transform.position = originalPosition;
                transform.rotation = originalRotation;
            }

        }
        else if (currentPosition == Position.Spawn)
        {
            HandManager.Instance.MoveToNextSlot(this);
        }
        else 
        {

            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }
    }

    void OnMouseDown()
    {
        if (currentPosition == Position.Hand)
            _dragAndDrop.OnMouseDownCard();
    }

    void OnMouseDrag()
    {
        if (currentPosition == Position.Hand && HandManager.Instance.CheckAndFreeSlots() == 0)
            _dragAndDrop.OnMouseDragCard();
    }

    private TransformAndRotation GetTransformAndRotationFor(TableID tableID)
    {
        string fieldName = char.ToLowerInvariant(tableID.ToString()[0])
                         + tableID.ToString().Substring(1);
        var fi = typeof(PositionAndRotation)
                 .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        return (TransformAndRotation)fi.GetValue(_positionAndRotation);
    }
    public enum Position
    {
        Spawn,
        Hand,
        Discard
    }
}
