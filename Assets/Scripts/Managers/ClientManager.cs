using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ClientManager : MonoBehaviour
{
    public static ClientManager Instance;

    public List<ClientBase> clients =  new List<ClientBase>();

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
    }

    public ClientBase GetClient() 
    {
        if (clients.Count == 0)
        {
            Debug.LogWarning("No hay clientes disponibles");
            return null;
        }
        int index = Random.Range(0, clients.Count);
        ClientBase client = clients[index];
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
