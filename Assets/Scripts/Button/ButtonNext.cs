using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNext : MonoBehaviour
{
    public Button nextButton;

    public void NextClient()
    {
        if (ClientManager.Instance != null)
        {
            // Llamar al m�todo TrySpawnClient (puedes agregar tu l�gica aqu�)
            ClientManager.Instance.TrySpawnClient();

            // Obtener la siguiente carta de las cartas restantes
            Card nextCard = DeckManager.instance.GetNextRemainingCard();

            if (nextCard != null)
            {
                // Mover la carta al siguiente slot disponible
                HandManager.Instance.MoveToNextSlot(nextCard);
            }
            else
            {
                Debug.Log("No hay cartas restantes.");
            }
        }
    }


}
