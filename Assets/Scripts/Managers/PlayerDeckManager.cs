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
    
    // Cantidad de cartas que roba el player cuando arranca el dia
    public int startingHandSize = 5;
    // Cantidad de cartas maxima en la mano
    public int maxHandSize = 8;

    // Lista del Mazo
    private List<Card> drawPile;
    // Lista del Mazo de descarte
    private List<Card> discardPile;
    // Mano
    public List<Card> hand { get; private set; }

    private void Awake()
    {
        // Setteo de mano
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    // Setteo de Mazo y Draw inicial
    public void InitializeDeck()
    {
        drawPile = new List<Card>(fullDeck);
        Shuffle(drawPile);
        discardPile = new List<Card>();
        hand = new List<Card>();
        for (int i = 0; i < startingHandSize; i++)
            DrawCard();
    }

    /// <summary>
    /// Metodo para toamr una carta del Mazo.
    /// Ignora si la mano esta llena.
    /// En caso de no tener mas cartas en el mazo principal, toma el mazo de descarte lo mezcla y suma al deck principal.
    /// En ultimo caso, toma una carta del mazo y la agrega a la mano.
    /// </summary>
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
        //HandManager.Instance.MoveToNextSlot(c);
    }

    // Retira cartas de la mano
    public void DiscardCard(Card c)
    {
        if (!hand.Remove(c)) return;
        discardPile.Add(c);
    }

    /// <summary>
    /// Funcion de mezclado automatico de listas. Usado para los Mazos.
    /// </summary> 
    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int r = Random.Range(i, list.Count);
            (list[i], list[r]) = (list[r], list[i]);
        }
    }
}