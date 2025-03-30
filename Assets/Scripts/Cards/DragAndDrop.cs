using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop
{
    private Vector3    _offset;
    private float      _zCoord;
    private Camera     _cam;
    private bool       _isRotating;
    private Transform  _transform;
    private Quaternion _originalRotation;
    private Vector3    _customEulerRotation;
    private Vector3    _lastPosition;
    private Vector3    _spawn;
    private Vector3    _discardPile;
    private TransformDataPosition _transformData;

    public DragAndDrop(Transform transform, Vector3 customEulerRotation, Vector3 spawn, Vector3 discardPile, TransformDataPosition transformData)
    {
        _transform           = transform;
        _cam                 = Camera.main;
        _customEulerRotation = customEulerRotation;
        _spawn               = spawn;
        _discardPile         = discardPile;
        _transformData       = transformData;
       
        
    }

    /// <summary>
    /// metodo para cuando se hace clic en el objeto
    /// </summary>
    internal void OnMouseDown()
    {
        _zCoord           = _cam.WorldToScreenPoint(_transform.position).z; //guarda la Z
        _offset           = _transform.position - GetMouseWorldPos(); 
        _originalRotation = _transform.localRotation;
        _isRotating       = true;
    }

    /// <summary>
    /// metodo para cuando el mouse es arrastrado
    /// </summary>
    internal void OnMouseDrag()
    {
        _transform.position = GetMouseWorldPos() + _offset; // mueve el objeto sin hacer un salto
        bool isMoving = _transform.position != _lastPosition;

        if (_isRotating && _transform.position.y >= 15 && isMoving) 
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, Quaternion.Euler(_customEulerRotation), 300f * Time.deltaTime); // suaviza la rotacion

        _lastPosition = _transform.position;

    }

    /// <summary>
    /// metodo para cuando se suelta el mouse
    /// </summary>
    internal void OnMouseUp()
    {
        float spawnDistance         = Vector3.Distance(_spawn, _transform.position);
        float transformDataPosition = Vector3.Distance(_transformData.position, _transform.position);


        if (spawnDistance < transformDataPosition)
        {
            _transform.position = _spawn;
        }
        else 
        {
            _transform.position = _transformData.position;
            _transform.localRotation = _transformData.rotation;
        }

        _transform.localRotation  = _originalRotation;
        _isRotating               = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; //obtiene la posicion del mouse en la pantalla
        mousePoint.z = _zCoord; // mantiene la profundidad del objeto en el mundo
        return _cam.ScreenToWorldPoint(mousePoint); // convierte la posicion del mouse en coordenadas del mundo
    }
}
