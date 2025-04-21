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
}
