using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDrop
{
    private Vector3              _offset;
    private float                _zCoord;
    private Camera               _cam;
    private bool                 _isRotating;
    private Transform            _transform;
    private Quaternion           _originalRotation;
    private Vector3              _customEulerRotation;
    private Vector3              _lastPosition;
    //private PositionAndRotation  _hand;
    private PositionAndRotation  _transformData;
    

    public DragAndDrop(Transform transform, Vector3 customEulerRotation, /*PositionAndRotation hand,*/ PositionAndRotation transformData)
    {
        _transform           = transform;
        _cam                 = Camera.main;
        _customEulerRotation = customEulerRotation;
        //_hand                = hand;
        _transformData       = transformData;
       
        
    }

    /// <summary>
    /// metodo para cuando se hace clic en el objeto
    /// </summary>
    internal void OnMouseDownCard()
    {
            _zCoord = _cam.WorldToScreenPoint(_transform.position).z; //guarda la Z
            _offset = _transform.position - GetMouseWorldPos();
            _originalRotation = _transform.localRotation;
            _isRotating = true;


    }

    /// <summary>
    /// metodo para cuando el mouse es arrastrado
    /// </summary>
    internal void OnMouseDragCard()
    {
            _transform.position = GetMouseWorldPos() + _offset; // mueve el objeto sin hacer un salto
            bool isMoving = _transform.position != _lastPosition;

            if (_isRotating && _transform.position.y >= 0 && isMoving)  
                _transform.rotation = Quaternion.RotateTowards(_transform.rotation, Quaternion.Euler(_customEulerRotation), 300f * Time.deltaTime); // suaviza la rotacion

            _lastPosition = _transform.position;

    }

    /// <summary>
    /// metodo para cuando se suelta el mouse
    /// </summary>
    //internal void OnMouseUpCard()
    //{
    //    float spawnDistance         = Vector3.Distance(_hand.CardOne.position, _transform.position);
    //    float transformDataPosition = Vector3.Distance(_transformData.CardOne.position, _transform.position);


    //    if (spawnDistance < transformDataPosition)
    //    {
    //        _transform.position      = _hand.CardOne.position;
    //        _transform.localRotation = _originalRotation;
    //    }
    //    else 
    //    {
    //        _transform.position      = _transformData.CardOne.position;
    //        _transform.localRotation = Quaternion.Euler(_transformData.CardOne.rotation);

    //    }

        
    //    _isRotating = false;
    //}

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; //obtiene la posicion del mouse en la pantalla
        mousePoint.z = _zCoord; // mantiene la profundidad del objeto en el mundo
        return _cam.ScreenToWorldPoint(mousePoint); // convierte la posicion del mouse en coordenadas del mundo
    }


}
