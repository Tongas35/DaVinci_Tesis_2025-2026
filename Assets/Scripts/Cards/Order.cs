using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Order
{
    private List<Image> _orders;
    private Transform _transform;
    private Coroutine _coroutine;
    private MonoBehaviour _context;

    public Order(List<Image> orders, Transform transform, MonoBehaviour context)
    {
        _orders = orders;
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


    public void OrderAction(Image orderActive, Card card, GameObject beer)
    {
        //if (orderActive == null || card == null || card._cardData == null)
        //{
        //    Debug.LogError("null");
        //    return;
        //}

        int result = orderActive.name switch
        {
            "cerveza carnelian" => (int)TypeDrink.roja,
            "colmillo dorado" => (int)TypeDrink.verde,
            "gin negro" => (int)TypeDrink.violeta,
            "cerveza doble onix" => (int)TypeDrink.gris,
            _ => 5
        };

        bool isCorrect = result switch
        {
            (int)TypeDrink.roja when card._cardData.name == "Cerveza Carnelian" => true,
            (int)TypeDrink.verde when card._cardData.name == "Colmillo Dorado" => true,
            (int)TypeDrink.violeta when card._cardData.name == "Gin Negro" => true,
            (int)TypeDrink.gris when card._cardData.name == "Cerveza Doble Onix" => true,
            _ => false
        };

        Debug.LogError(isCorrect ? "<color=blue>Bebida CORRECTA!</color>" : "<color=red>Bebida INCORRECTA!</color>");

        // Mostrar/ocultar la cerveza
        beer.SetActive(card.gameObject.activeInHierarchy);

        _coroutine = _context.StartCoroutine(Used(card));
        card.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
        gris
    }
}
