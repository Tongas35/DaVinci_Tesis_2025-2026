using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager instance;

    
    public List<Card> cards    = new List<Card>();
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
        Order(RandomCard()); 
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
}
