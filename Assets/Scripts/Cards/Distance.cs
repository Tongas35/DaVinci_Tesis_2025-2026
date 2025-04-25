using System.Collections.Generic;
using UnityEngine;

public class Distance<T> where T : Component
{

    List<T> _distances;
    List<T> _table;
    Transform _transform;


    public Distance(List<T> distances, Transform transform)
    {
        _distances = distances;
        _transform = transform;
        
    }

    public Distance(List<T> table)
    {
        _table = table;
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




    public List<T> TableFull() 
    {
        List<T> shuffledTable = new List<T>(_table); 
        int n = shuffledTable.Count;

        for (int i = 0; i < n; i++)
        {
            int j = Random.Range(i, n);
            // Intercambia elementos i y j
            T temp = shuffledTable[i];
            shuffledTable[i] = shuffledTable[j];
            shuffledTable[j] = temp;
        }

        return shuffledTable;
    }
}
