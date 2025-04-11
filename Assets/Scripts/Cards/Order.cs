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

    public void OrderAction(Image orderActive, Card posCard, GameObject beer) 
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
                Debug.LogError("Bebida CORRECTA!");

                
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else 
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else 
            {
                Debug.LogError("Bebida INCORRECTA!");

                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            }
        }
        else if(result == (int)TypeDrink.verde && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Colmillo Dorado")
            {
                Debug.LogError("Bebida CORRECTA!");
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                
                Debug.LogError("Bebida INCORRECTA!");
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }

        }
        else if(result == (int)TypeDrink.violeta && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Gin Negro")
            {
                Debug.LogError("Bebida CORRECTA!");
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                Debug.LogError("Bebida INCORRECTA!");
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
        else if(result == (int)TypeDrink.gris && posCard.transform.rotation == Quaternion.identity)
        {
            if (posCard._cardData.name == "Cerveza Doble Onix")
            {
                Debug.LogError("Bebida CORRECTA!");
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else
            {
                Debug.LogError("Bebida INCORRECTA!");
                if (!posCard.gameObject.activeInHierarchy)
                {
                    beer.SetActive(false);
                }
                else
                {
                    beer.SetActive(true);
                }
                _coroutine = _context.StartCoroutine(Used(posCard));
                posCard.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
