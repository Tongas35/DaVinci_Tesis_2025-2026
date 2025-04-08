using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableOnHand
{
    public Vector3 targetScale = new Vector3(0.2f, 0.2f, 0.2f);

    private List<TransformAndRotation> _slotPositions;
    Card _card;
    public TableOnHand(Card card, List<TransformAndRotation> slotPositions)
    {

        _card = card;
        _slotPositions = slotPositions;
    }

    private (Vector3 position, Vector3 rotation )Slots()
    {
        float dist = Mathf.Infinity;
        Vector3 positionSlot = Vector3.zero;
        Vector3 rotationSlot = Vector3.zero;

        foreach (TransformAndRotation t in _slotPositions)
        {
            float distanceSlot = Vector3.Distance(t.position, _card.transform.position);
            if (distanceSlot < dist)
            {
                dist = distanceSlot;
                positionSlot = t.position;
                rotationSlot = t.rotation;
            }
        }
        return (positionSlot, rotationSlot);
    }

    public Card GoObjetive() 
    {
        (Vector3 position, Vector3 rotation) slotObjetive = Slots();

        _card.transform.position = slotObjetive.position;
        _card.transform.rotation = Quaternion.Euler(slotObjetive.rotation);


        
        return _card;

    }

    public IEnumerator TransformCard(Card card) 
    {

        if (card.transform.position.y >= 17) 
        {
            _card.transform.LookAt(Camera.main.transform);
            _card.transform.localScale = Vector3.Lerp(_card.transform.localScale, targetScale, Time.deltaTime * 3);
            yield return new WaitForSeconds(1);
        }
    } 
}
