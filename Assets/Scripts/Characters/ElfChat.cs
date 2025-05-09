using TMPro;
using UnityEngine;

public class ElfChat : MonoBehaviour
{
     public TextMeshProUGUI text;



    public string Chat()
    {
        text.transform.position = transform.position + new Vector3(1.5f, 3, 0);
        text.transform.LookAt(Camera.main.transform);
        text.transform.Rotate(0, 180, 0);
        return text.text = "Me llamo Rafael.";

    }
}
