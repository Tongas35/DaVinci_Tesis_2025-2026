using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public Image globe;
    private Order _order;
    Card _card;

    [SerializeField]
    List<Image> _orders;

    
    private void Start()
    {
        
        _order = new Order(_orders, transform, _card);
        var asds = _order.OrderList();

        asds.gameObject.SetActive(true);

        
    }
    private void Update()
    {
        globe.transform.position = transform.position + new Vector3(5, 12, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);
    }



}
