
using UnityEngine;

[CreateAssetMenu(fileName = "Position Rotation Card", menuName = "Position and rotation")]
public class PositionAndRotation : ScriptableObject
{
    [Header("Colocar los vectores segun la ubicacion del objeto en la UI")]
    [Space(10)]

    [SerializeField]
    [Tooltip("Posicion donde se encuentra el mazo de cartas.")]
    private TransformAndRotationSpawn spawnDeck;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation cardOne;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation cardTwo;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation cardThree;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation cardFour;
    [SerializeField]
    private TransformAndRotation tableOne;
    [SerializeField]
    private TransformAndRotation tableTwo;
    [SerializeField]
    private TransformAndRotation tableThree;
    [SerializeField]
    private TransformAndRotation tableFour;
    [SerializeField]
    private TransformAndRotation tableFive;
    [SerializeField]
    private TransformAndRotation tableSix;



    public TransformAndRotationSpawn SpawnDeck => spawnDeck;
    public TransformAndRotation CardOne => cardOne;
    public TransformAndRotation CardTwo => cardTwo;
    public TransformAndRotation CardThree => cardThree;
    public TransformAndRotation CardFour => cardFour;
    public TransformAndRotation TableOne => tableOne;
    public TransformAndRotation TableTwo => tableTwo;
    public TransformAndRotation TableThree => tableThree;
    public TransformAndRotation TableFour => tableFour;
    public TransformAndRotation TableFive => tableFive;
    public TransformAndRotation TableSix => tableSix;
}
