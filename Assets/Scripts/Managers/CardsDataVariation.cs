using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardsDataVariation : ScriptableObject
{
    /*
     Expone campos adicionales CustomRotation y PositionConfig para el DragAndDrop.
     AllSlotPositions para que TableOnHand ubique la carta correctamente.
     Mantiene el enum CardType para categorizar la carta (ligera, fuerte, exotica, comida, accion).
    */

    public string cardName;
    public int shopCost;
    public CardType CardTypeProperty;
    public bool isExotic;
    public string cardDescription;
    public Sprite cardImage;

    [Header("Visual Config")]
    public Vector3 CustomRotation;
    public PositionAndRotation PositionConfig;

    public List<TransformAndRotation> AllSlotPositions;

    public enum CardType { Action, LightDrink, StrongDrink, Meal }
}