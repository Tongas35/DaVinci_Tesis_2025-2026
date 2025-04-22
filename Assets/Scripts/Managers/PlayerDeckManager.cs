using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeckManager : MonoBehaviour
{
    /*
    Se encarga solo de la logica del mazo:
    - drawPile, discardPile y la mano lógica (hand).
    - Metodos InitializeDeck(), DrawCard() (con limite de mano) y DiscardCard().
    Cada vez que roba, invoca HandManager.Instance.MoveToNextSlot(card) para la colocación visual.
    */

    public static PlayerDeckManager Instance { get; private set; }

    [Header("Configuración de Mazo")]
    public List<Card> fullDeck;
    public int startingHandSize = 5;
    public int maxHandSize = 8;

    private List<Card> drawPile;
    private List<Card> discardPile;
    public List<Card> hand { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public void InitializeDeck()
    {
        drawPile = new List<Card>(fullDeck);
        Shuffle(drawPile);
        discardPile = new List<Card>();
        hand = new List<Card>();
        for (int i = 0; i < startingHandSize; i++)
            DrawCard();
    }

    public void DrawCard()
    {
        if (hand.Count >= maxHandSize) return;
        if (drawPile.Count == 0)
        {
            drawPile.AddRange(discardPile);
            discardPile.Clear();
            Shuffle(drawPile);
        }
        if (drawPile.Count == 0) return;
        Card c = drawPile[0];
        drawPile.RemoveAt(0);
        hand.Add(c);
        HandManager.Instance.MoveToNextSlot(c);
    }

    public void DiscardCard(Card c)
    {
        if (!hand.Remove(c)) return;
        discardPile.Add(c);
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            (list[i], list[r]) = (list[r], list[i]);
        }
    }
}