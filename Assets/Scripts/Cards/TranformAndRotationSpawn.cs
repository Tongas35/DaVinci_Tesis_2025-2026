using UnityEngine;

public struct TransformAndRotationSpawn
{
    public Vector3 position;
    public Vector3 rotation; 

   
    private static readonly Vector3 DefaultRotation = new Vector3(-75f, 180, 0);

    public TransformAndRotationSpawn(Vector3 position)
    {
        this.position = position;
        this.rotation = DefaultRotation; 
    }

    public static TransformAndRotationSpawn GetRandom(Vector3 minPosition, Vector3 maxPosition)
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );

        return new TransformAndRotationSpawn(randomPosition);
    }
}