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
    [SerializeField] 
    private Vector3 cardSpawn;
    [SerializeField] 
    private TransformAndRotation cardTransformSelect;
    [SerializeField]
    private TransformAndRotation discardPile;

    public string CardName => cardName;
    public int CardShopCost => cardShopCost;
    public CardType CardTypeProperty => cardType;
    public string CardDescription => cardDescription;
    public Sprite CardImage => cardImage;
    public Vector3 CardSpawn => cardSpawn;
    public TransformAndRotation DiscardPile => discardPile;
    public TransformAndRotation CardTransformSelect => cardTransformSelect;

    public enum CardType
    {
        Action, 
        Recipe
    }
}
