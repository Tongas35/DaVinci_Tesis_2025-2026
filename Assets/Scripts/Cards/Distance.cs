using System.Collections.Generic;
using UnityEngine;

public class Distance<T> where T : Component
{

    List<T> _distances;
    Transform _transform;


    public Distance(List<T> distances, Transform transform)
    {
        _distances = distances;
        _transform = transform;
    }

    public T SlotsCards()
    {
        float minDist = Mathf.Infinity;
        T closest = null;

        foreach (T item in _distances)
        {
            float distance = Vector3.Distance(item.transform.position, _transform.position);
            if (distance < minDist)
            {
                minDist = distance;
                closest = item;
            }
        }

        return closest;
    }
}
