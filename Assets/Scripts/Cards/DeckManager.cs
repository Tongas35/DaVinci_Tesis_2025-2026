using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    
    public List<Card> cards     = new List<Card>();
    private List<Card> remainingCards = new List<Card>();
    [SerializeField]
    private Vector3 minPosition = new Vector3(-5f, 1f, -5f);
    [SerializeField]
    private Vector3 maxPosition = new Vector3(5f, 1f, 5f);

    

    [SerializeField]
    private PositionAndRotation positionAndRotation;

    private void Awake()
    {
        HandManager.Initialize(positionAndRotation);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        List<Card> shuffledCards = RandomCard();
        Order(shuffledCards);
        PlaceCardsInHand(shuffledCards);
    }


    public List<Card> RandomCard()
    {
        if (cards.Count == 0)
        {
            Debug.LogWarning("no hay cartas en la lista");
            return null;
        }

        TransformAndRotationSpawn randomTransform;

        foreach (Card item in cards)
        {
            randomTransform         = TransformAndRotationSpawn.GetRandom(minPosition, maxPosition);
            item.transform.position = randomTransform.position;
            item.transform.rotation = Quaternion.Euler(randomTransform.rotation);
        }


        cards = cards.OrderBy(card => card.transform.position.y).ToList();

        return cards;
    }

    public void Order(List<Card> orderLayer)
    {
        for (int i = 0; i < orderLayer.Count; i++)
        {
            SpriteRenderer spriteRenderer = orderLayer[i].GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = i; 
            }
        }
    }

    // Modificado: ahora almacena las cartas restantes
    public void PlaceCardsInHand(List<Card> shuffledCards)
    {
        if (shuffledCards == null || shuffledCards.Count == 0)
        {
            return;
        }

        // Tomamos las primeras 5 cartas y las ponemos en la mano
        List<Card> cardsToPlace = shuffledCards.Take(5).ToList();
        remainingCards = shuffledCards.Skip(5).ToList();  // Las cartas restantes

        // Colocamos estas cartas en los primeros slots disponibles de la mano
        foreach (Card card in cardsToPlace)
        {
            HandManager.Instance.MoveToNextSlot(card);
        }
    }

    // Método para obtener la siguiente carta en la lista de cartas restantes
    public Card GetNextRemainingCard()
    {
        if (remainingCards.Count > 0)
        {
            Card nextCard = remainingCards[0];
            remainingCards.RemoveAt(0);  // Elimina la carta de la lista
            return nextCard;
        }
        return null;  // Retorna null si no hay cartas restantes
    }
}
