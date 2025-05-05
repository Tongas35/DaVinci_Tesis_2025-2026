using UnityEngine;
using System.Reflection;

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
        float distance = 15f;
        Vector3 newPosition = cam.transform.position + direction * distance;

        // Usamos reflection
        TransformAndRotation config = GetFieldValue();
        config.position = newPosition;
        SetFieldValue(config);
    }

    public (Vector3, Vector3) DetectPosition()
    {
        TransformAndRotation config = GetFieldValue();
        _storedPosition = config.position;
        _storedRotation = config.rotation;
        return (_storedPosition, _storedRotation);
    }

    private TransformAndRotation GetFieldValue()
    {
        string fieldName = char.ToLowerInvariant(_tableID.ToString()[0]) + _tableID.ToString().Substring(1);
        FieldInfo fieldInfo = typeof(PositionAndRotation).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo == null)
        {
            throw new System.Exception($"No se encontro el campo '{fieldName}' en PositionAndRotation.");
        }

        return (TransformAndRotation)fieldInfo.GetValue(_data);
    }

    private void SetFieldValue(TransformAndRotation newValue)
    {
        string fieldName = char.ToLowerInvariant(_tableID.ToString()[0]) + _tableID.ToString().Substring(1);
        FieldInfo fieldInfo = typeof(PositionAndRotation).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo == null)
        {
            throw new System.Exception($"No se encontro el campo '{fieldName}' en PositionAndRotation.");
        }

        fieldInfo.SetValue(_data, newValue);
    }
}
