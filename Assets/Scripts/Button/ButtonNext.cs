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
            // Llamar al método TrySpawnClient (puedes agregar tu lógica aquí)
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
