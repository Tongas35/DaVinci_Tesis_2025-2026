using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardsData : ScriptableObject
{
    [SerializeField] 
    private string cardName;
    [SerializeField] 
    private int cardShopCost;
    [SerializeField] 
    private CardType cardType;
    [SerializeField] 
    private string cardDescription;
    [SerializeField] 
    private Sprite cardImage;


    public string CardName => cardName;
    public int CardShopCost => cardShopCost;
    public CardType CardTypeProperty => cardType;
    public string CardDescription => cardDescription;
    public Sprite CardImage => cardImage;


    public enum CardType
    {
        Action, 
        Recipe
    }

}
