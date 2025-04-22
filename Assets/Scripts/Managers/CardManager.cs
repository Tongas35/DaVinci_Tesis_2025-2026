using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManger : MonoBehaviour
{
    /*
     Ahora cada carta lleva un CardsData con su informacion y configuracion visual.
     Usa DragAndDrop y TableOnHand para la interaccion y posicionamiento.
     En OnMouseUp(), si se suelta sobre un cliente (Physics.Raycast), llama a OrderManager.ProcessOrder(this, cliente).
    */

    public CardsDataVariation CardDataVariation;
    public Position currentPosition = Position.Spawn;

    private DragAndDrop _dragAndDrop;
    private TableOnHand _tableOnHand;

    void Start()
    {
        _dragAndDrop = new DragAndDrop(transform, CardDataVariation.CustomRotation, CardDataVariation.PositionConfig);
        _tableOnHand = new TableOnHand(this, CardDataVariation.AllSlotPositions);
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

    void OnMouseUp()
    {
        if (currentPosition == Position.Hand)
        {
            var (pos, rot) = _tableOnHand.FindNearestSlot();
            transform.position = pos;
            transform.rotation = Quaternion.Euler(rot);
            currentPosition = Position.Spawn;

            // Si se soltó sobre un cliente:
            var hit = Physics.Raycast(transform.position, Vector3.down, out RaycastHit info, 1f);
            if (hit && info.collider.TryGetComponent<Client>(out var cust))
            {
                OrderManager.Instance.ProcessOrder(this, cust);
            }
        }
    }

    public enum Position { Spawn, Hand, Discard }
}