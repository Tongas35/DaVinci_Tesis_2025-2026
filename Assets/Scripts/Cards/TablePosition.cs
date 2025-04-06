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

        Vector3 direccion = (_transform.position - cam.transform.position).normalized;


        float distancia = 45f;

      
        Vector3 nuevaPosicion = cam.transform.position + direccion * distancia;

        switch (_tableID)
        {
            case TableID.TableOne:
                _data.TableOne.position = nuevaPosicion;
                break;
            case TableID.TableTwo:
                _data.TableTwo.position = nuevaPosicion;
                break;
            case TableID.TableThree:
                _data.TableThree.position = nuevaPosicion;
                break;
            case TableID.TableFour:
                _data.TableFour.position = nuevaPosicion;
                break;
            case TableID.TableFive:
                _data.TableFive.position = nuevaPosicion;
                break;
            case TableID.TableSix:
                _data.TableSix.position = nuevaPosicion;
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
            _ => throw new System.ArgumentOutOfRangeException(nameof(_tableID), _tableID, "valor de tableID no soportado")
        };

            _storedPosition = config.position;
            _storedRotation = config.rotation;

        return (_storedPosition, _storedRotation);
    }

}
