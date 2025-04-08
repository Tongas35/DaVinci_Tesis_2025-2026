using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client : MonoBehaviour
{
    public Image globe;
    private Order _order;
    private Distance<Card> _distance;
    Card _card;
 

    [SerializeField]
    List<Image> _orders;

    private Image img;

  
    private Vector3 rotat;

    
    private void Start()
    {
       
        _order = new Order(_orders, transform);
        _distance = new Distance<Card>(DeckManager.instance.cards, transform);
        img = _order.OrderList();

        img.gameObject.SetActive(true);
        _card = _distance.SlotsCards();
        


    }
    private void Update()
    {
        _card = _distance.SlotsCards();
        //_card = _onHand?.GoObjetive(); //no tengo al referencia de onHand
        globe.transform.position = transform.position + new Vector3(5, 12, 0);
        globe.transform.LookAt(Camera.main.transform);
        globe.transform.Rotate(0, 180, 0);
        _order.OrderAction(img, _card); //necesito buscar la carta mas cercana



    }



}
