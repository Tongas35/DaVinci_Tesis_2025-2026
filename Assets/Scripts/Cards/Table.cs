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



}
public enum TableID 
{ 
    TableOne, 
    TableTwo, 
    TableThree, 
    TableFour, 
    TableFive, 
    TableSix 
}
