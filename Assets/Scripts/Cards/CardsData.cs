using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardsData : ScriptableObject
{
    public string cardName;
    public int cardShopCost;
    public CardType cardType;
    public string cardDescription;
    public Sprite cardImage;

    public enum CardType
    {
        Action, 
        Recipe
    }
}
