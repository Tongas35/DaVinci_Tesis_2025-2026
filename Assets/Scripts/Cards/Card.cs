using UnityEngine;
using UnityEngine.XR;

public class Card : MonoBehaviour
{
    DragAndDrop dragAndDrop;

    [SerializeField]
    private Vector3 customRotation = new Vector3(0, 0, 0);

    TransformAndRotation[] pos;

    [SerializeField]
    private PositionAndRotation _transformAndRotationHand;

    public Position currentPosition = Position.Spawn;

    void Start()
    {
        pos = new[]
        {
            _transformAndRotationHand.CardOne,
            _transformAndRotationHand.CardTwo,
            _transformAndRotationHand.CardThree,
            _transformAndRotationHand.CardFour
        };

       
        HandManager.Initialize(_transformAndRotationHand);

        dragAndDrop = new DragAndDrop(transform, customRotation, _transformAndRotationHand, _transformAndRotationHand);
    }

    void OnMouseUp()
    {
        if (currentPosition == Position.Hand)
        {
            dragAndDrop.OnMouseUpCard();
        }
        else if (currentPosition == Position.Spawn)
        {
            
            HandManager.Instance.MoveToNextSlot(this);
     
           
        }

    }

    void OnMouseDown() 
    {
        if (currentPosition == Position.Hand) 
        {
            dragAndDrop.OnMouseDownCard(); 
        }
    }


    void OnMouseDrag()
    {
        if (currentPosition == Position.Hand)
        {
            dragAndDrop.OnMouseDragCard();
        }
    }


    public enum Position
    {
        Spawn,
        Hand,
        Discart
    }
}