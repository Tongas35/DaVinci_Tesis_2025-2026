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
            ClientManager.Instance.TrySpawnClient();
        }
    }


}
