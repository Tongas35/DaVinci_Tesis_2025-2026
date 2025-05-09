using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    public static ClientManager Instance;

    public List<ClientBase> clients = new List<ClientBase>(); // Lista original desde el Inspector
    private List<ClientBase> availableClients = new List<ClientBase>(); // Lista temporal para selección

    public Button buttonSpawn;
    private bool canSpawn = true;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ResetAvailableClients();
    }

    private void ResetAvailableClients()
    {
        availableClients = new List<ClientBase>(clients);
    }

    public ClientBase GetClient()
    {
        if (availableClients.Count == 0)
        {
            Debug.Log("Todos los clientes fueron activados. Reiniciando lista temporal.");
            ResetAvailableClients();
        }

        int index = Random.Range(0, availableClients.Count);
        ClientBase client = availableClients[index];
        availableClients.RemoveAt(index); // Eliminar solo de la lista temporal

        
        client.ActivateClient();
        return client;
    }

    public async void TrySpawnClient()
    {
        if (!canSpawn) return;

        buttonSpawn.interactable = false;
        canSpawn = false;

        GetClient();

        await Task.Delay(1000);

        canSpawn = true;
        buttonSpawn.interactable = true;
    }
}
