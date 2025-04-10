using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order 
{
    List<Image> _orders;
    Transform _transform;
    Card _card;
    Coroutine _coroutine;
    MonoBehaviour _context;
    public Order(List<Image> orders, Transform transform, Card posCard, MonoBehaviour context)
    {
        _orders = orders;
        _transform = transform;
        _card = posCard;
        _context = context;
    }

    public Image OrderList() 
    {
        Image selectedImage = null;
        if (_orders != null && _orders.Count > 0)
        {
            int randomIndex = Random.Range(0, _orders.Count); 
            selectedImage = _orders[randomIndex];       
            Debug.Log("imagen seleccionada: " + selectedImage.name);
        }
        return selectedImage;
    }

    public void OrderAction(Image orderActive, Card posCard) 
    {

        int result = orderActive.name switch
        {
            "cerveza carnelian" => (int)TypeDrink.roja,
            "colmillo dorado" => (int)TypeDrink.verde,
            "gin negro" => (int)TypeDrink.violeta,
            "cerveza doble onix" => (int)TypeDrink.gris,
            _ => 5
        };
        
        if (result == (int)TypeDrink.roja && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Cerveza Carnelian")
            {
                Debug.Log("Bebida CORRECTA!");

                _coroutine = _context.StartCoroutine(Used(posCard));
            }
            else 
            {
                Debug.Log("Bebida INCORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));

            }
        }
        else if(result == (int)TypeDrink.verde && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Colmillo Dorado")
            {
                Debug.Log("Bebida CORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));
            }
            else
            {
                
                Debug.Log("Bebida INCORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));
            }

        }
        else if(result == (int)TypeDrink.violeta && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Gin Negro")
            {
                Debug.Log("Bebida CORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));
            }
            else
            {
                Debug.Log("Bebida INCORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));
            }
        }
        else if(result == (int)TypeDrink.gris && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Cerveza Doble Onix")
            {
                Debug.Log("Bebida CORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));
            }
            else
            {
                Debug.Log("Bebida INCORRECTA!");
                _coroutine = _context.StartCoroutine(Used(posCard));
            }
        }

    }

    public enum TypeDrink
    {
        roja,
        verde,
        violeta,
        gris


    }

    IEnumerator Used(Card card) 
    {

        yield return new WaitForSeconds(3);
        card.gameObject.SetActive(false);
    }


}
