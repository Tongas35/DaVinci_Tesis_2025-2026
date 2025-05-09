using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Order
{
    private List<Image> _orders;
    private List<Image> _chaosimg;
    private Transform _transform;
    private Coroutine _coroutine;
    private MonoBehaviour _context;

    public Order(List<Image> orders, Transform transform, MonoBehaviour context, List<Image> chaosimg)
    {
        _orders = orders;
        _chaosimg = chaosimg;
        _transform = transform;
        _context = context;
    }

    public Image OrderList()
    {
        if (_orders != null && _orders.Count > 0)
        {
            int randomIndex = Random.Range(0, _orders.Count);
            return _orders[randomIndex];
        }
        return null;
    }
    public Image ChaosOne() 
    {
        return _chaosimg[0];
    }


    public bool OrderAction(Image orderActive, Card card, GameObject beer)
    {
        bool isCorrect = false;
        

        if (card.transform.rotation == Quaternion.identity) 
        {
            int result = orderActive.name switch
            {
                "cerveza carnelian" => (int)TypeDrink.roja,
                "colmillo dorado" => (int)TypeDrink.verde,
                "gin negro" => (int)TypeDrink.violeta,
                "neblina silvestre" => (int)TypeDrink.blanco,
                "desterrar alborotador" =>(int)TypeDrink.negro,
                _ => 5
            };

            isCorrect = result switch
            {
                (int)TypeDrink.roja when card._cardData.name == "Cerveza Carnelian" => true,
                (int)TypeDrink.verde when card._cardData.name == "Colmillo Dorado" => true,
                (int)TypeDrink.violeta when card._cardData.name == "Gin Negro" => true,
                (int)TypeDrink.blanco when card._cardData.name == "Neblina Silvestre" => true,
                (int)TypeDrink.negro when card._cardData.name == "Desterrar al Alborotador" => true,
                _ => false
            };

            Debug.LogError(isCorrect ? "<color=blue>Bebida CORRECTA!</color>" : "<color=red>Bebida INCORRECTA!</color>");

            // Mostrar/ocultar la cerveza
            beer.SetActive(card.gameObject.activeInHierarchy);

            _coroutine = _context.StartCoroutine(Used(card));
            card.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            
        }

        return isCorrect;

    }

    private IEnumerator Used(Card card)
    {
        yield return new WaitForSeconds(3);
        card.gameObject.SetActive(false);
    }

    private enum TypeDrink
    {
        roja,
        verde,
        violeta,
        blanco,
        negro
    }
}
