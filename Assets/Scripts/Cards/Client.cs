using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public Image globe;
    private Order _order;
    Card _card;
    private TableOnHand _onHand;

    [SerializeField]
    List<Image> _orders;

    private Image img;

    
    private void Start()
    {
       
        _order = new Order(_orders, transform, _card);
        img = _order.OrderList();

        img.gameObject.SetActive(true);

        


    }
    private void Update()
    {

        _card = _onHand?.GoObjetive(); //no tengo al referencia de onHand
        globe.transform.position = transform.position + new Vector3(5, 12, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);
        _order?.OrderAction(img); //necesito buscar la carta mas cercana



    }



}
