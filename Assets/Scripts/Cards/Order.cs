using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order 
{
    List<Image> _orders;
    Card _card;
    Transform _transform;

    public Order(List<Image> orders, Transform transform, Card card)
    {
        _orders = orders;
        _transform = transform;
        _card = card;
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

    public void OrderAction(Image orderActive) 
    {

        int result = orderActive.name switch
        {
            "cerveza carnelian" => (int)TypeDrink.roja,
            "colmillo dorado" => (int)TypeDrink.verde,
            "gin negro" => (int)TypeDrink.violeta,
            "cerveza doble onix" => (int)TypeDrink.gris,
            _ => 5
        };

        if (result == (int)TypeDrink.roja && _card.transform.rotation == Quaternion.Euler(0,0,0))
        {
            if (_card._cardData.name == "cerveza carnelian")
            {
                Debug.Log("Bebida CORRECTA!");
            }
            else 
            {
                Debug.Log("Bebida INCORRECTA!");
            }
        }
        else if(result == (int)TypeDrink.verde && _card.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            if (_card._cardData.name == "colmillo dorado")
            {
                Debug.Log("Bebida CORRECTA!");
            }
            else
            {
                Debug.Log("Bebida INCORRECTA!");
            }

        }
        else if(result == (int)TypeDrink.violeta && _card.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            if (_card._cardData.name == "gin negro")
            {
                Debug.Log("Bebida CORRECTA!");
            }
            else
            {
                Debug.Log("Bebida INCORRECTA!");
            }
        }
        else if(result == (int)TypeDrink.gris && _card.transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            if (_card._cardData.name == "cerveza doble onix")
            {
                Debug.Log("Bebida CORRECTA!");
            }
            else
            {
                Debug.Log("Bebida INCORRECTA!");
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

}
