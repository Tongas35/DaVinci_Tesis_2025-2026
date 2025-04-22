using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    /*
     Nuevo manager central para procesar cualquier pedido de cliente.
     ProcessOrder(card, customer):
     Compara el CardType de la carta con el OrderType del cliente.
     Otorga recompensas o penalizaciones a través de EconomyManager.
     Descarta la carta logica y destruye su GameObject.
    */

    public static OrderManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    /// <summary>
    /// Procesa un pedido: compara tipo, otorga recursos y descarta carta.
    /// </summary>
    public void ProcessOrder(Card card, Client customer)
    {
        /*bool success = (card.CardData.CardTypeProperty == customer.OrderType);
        if (success)
        {
            // Ejemplo: +gold y +reputation, valores a ajustar
            EconomyManager.Instance.AddGold(card.CardData.ShopCost);
            EconomyManager.Instance.AddReputation(5);
        }
        else
        {
            EconomyManager.Instance.AddReputation(-10);
        }*/
        // Descarta la carta
        PlayerDeckManager.Instance.DiscardCard(card);
        Destroy(card.gameObject);
    }
}