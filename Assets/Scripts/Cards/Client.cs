using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{


    
    public Image globe;

    private void Update()
    {
        globe.transform.position = transform.position + new Vector3(5, 12, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);
    }



}
