using UnityEngine;

public class Card : MonoBehaviour
{
    DragAndDrop dragAndDrop;

    [SerializeField]
    private Vector3 customRotation = new Vector3(45,40,180);

    [SerializeField]
    private CardsData _card;

    void Start()
    {
        dragAndDrop = new DragAndDrop(this.transform, customRotation, _card.CardSpawn, _card.DiscardPile, _card.CardTransformSelect);
    }

    void OnMouseUp() => dragAndDrop.OnMouseUp();
    void OnMouseDown() => dragAndDrop.OnMouseDown();

    void OnMouseDrag() => dragAndDrop.OnMouseDrag();

}
