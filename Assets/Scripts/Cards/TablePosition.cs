using UnityEngine;

public class TablePosition 
{
  
    private Vector3 _storedPosition;
    private Vector3 _storedRotation; 
    private TableID _tableID;
    private PositionAndRotation _data;
    private Transform _transform;

    public TablePosition(PositionAndRotation data, TableID tableID, Transform transform)
    {
        _data = data;
        _tableID = tableID;
        _transform = transform; 
    }

    public void AddPosition() 
    {
        Camera cam = Camera.main;

        Vector3 direction = (_transform.position - cam.transform.position).normalized;


        float distance = 45f;

      
        Vector3 newPosition = cam.transform.position + direction * distance;

        switch (_tableID)
        {
            case TableID.TableOne:
                _data.TableOne.position = newPosition;
                break;
            case TableID.TableTwo:
                _data.TableTwo.position = newPosition;
                break;
            case TableID.TableThree:
                _data.TableThree.position = newPosition;
                break;
            case TableID.TableFour:
                _data.TableFour.position = newPosition;
                break;
            case TableID.TableFive:
                _data.TableFive.position = newPosition;
                break;
            case TableID.TableSix:
                _data.TableSix.position = newPosition;
                break;
            case TableID.TableSeven:
                _data.TableSeven.position = newPosition;
                break;
            case TableID.TableEight:
                _data.TableEight.position = newPosition;
                break;
            case TableID.TableNine:
                _data.TableNine.position = newPosition;
                break;
        }

        

    }

    public (Vector3, Vector3) DetectPosition() 
    {


        TransformAndRotation config = _tableID switch
        {
            TableID.TableOne => _data.TableOne,
            TableID.TableTwo => _data.TableTwo,
            TableID.TableThree => _data.TableThree,
            TableID.TableFour => _data.TableFour,
            TableID.TableFive => _data.TableFive,
            TableID.TableSix => _data.TableSix,
            TableID.TableSeven => _data.TableSeven,
            TableID.TableEight => _data.TableEight,
            TableID.TableNine => _data.TableNine,
            _ => throw new System.ArgumentOutOfRangeException(nameof(_tableID), _tableID, "valor de tableID no soportado")
        };

            _storedPosition = config.position;
            _storedRotation = config.rotation;

        return (_storedPosition, _storedRotation);
    }

}
