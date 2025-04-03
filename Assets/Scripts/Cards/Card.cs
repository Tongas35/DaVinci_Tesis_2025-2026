using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Card : MonoBehaviour
{
    DragAndDrop _dragAndDrop;
    TableOnHand _tableOnHand;

    [SerializeField]
    private Vector3 customRotation = new Vector3(0, 0, 0);

    //TransformAndRotation[] pos;

    [SerializeField]
    private PositionAndRotation _positionAndRotation;

    public Position currentPosition = Position.Spawn;

    void Start()
    {
        List<TransformAndRotation> slotPositions = new List<TransformAndRotation>
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






        _dragAndDrop = new DragAndDrop(transform, customRotation, /*_transformAndRotationHand,*/ _positionAndRotation);
        _tableOnHand = new TableOnHand(this, slotPositions);
    }

    void OnMouseUp()
    {
        if (currentPosition == Position.Hand)
        {
            //dragAndDrop.OnMouseUpCard();  NO SIRVE
            _tableOnHand.Objetive();
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
            _dragAndDrop.OnMouseDownCard(); 
        }
    }


    void OnMouseDrag()
    {
        if (currentPosition == Position.Hand)
        {
            _dragAndDrop.OnMouseDragCard();
        }
    }


    public enum Position
    {
        Spawn,
        Hand,
        Discart
    }
}