using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public static TableManager instance;
    public List<Table> tables;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public Table GetRandomAvailableTable()
    {
        List<Table> available = new List<Table>();

        foreach (var table in tables)
        {
            if (!table.IsOccupied)
                available.Add(table);
        }

        if (available.Count == 0) return null;

        int index = Random.Range(0, available.Count);
        Table chosen = available[index];
        chosen.Assign();
        return chosen;
    }

    public Table GetClosestAvailableTable(Vector3 position)
    {
        Table closest = null;
        float shortestDistance = float.MaxValue;

        foreach (var table in tables)
        {
            if (table.IsOccupied) continue;

            float distance = Vector3.Distance(position, table.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = table;
            }
        }

        if (closest != null)
            closest.Assign();

        return closest;
    }
}
