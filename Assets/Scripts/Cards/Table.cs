using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private PositionAndRotation data;
    [SerializeField] private TableID _tableID;

    TablePosition tablePosition;

    private void Start()
    {
        tablePosition = new TablePosition(data, _tableID, transform);
        tablePosition.AddPosition();
        
        
    }
    public bool IsOccupied { get; private set; }

    public void Assign()
    {
        IsOccupied = true;
    }

    public void Release()
    {
        IsOccupied = false;
    }


}
public enum TableID 
{ 
    TableOne, 
    TableTwo, 
    TableThree, 
    TableFour, 
    TableFive, 
    TableSix,
    TableSeven,
    TableEight,
    TableNine
}
