
using UnityEngine;

[CreateAssetMenu(fileName = "Position Rotation Card", menuName = "Position and rotation")]
public class PositionAndRotation : ScriptableObject
{
    [Header("Colocar los vectores segun la ubicacion del objeto en la UI")]
    [Space(10)]

    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation handOne;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation handTwo;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation handThree;
    [SerializeField]
    [Tooltip("Posicion en la mano del jugador.")]
    private TransformAndRotation handFour;
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
    [SerializeField]
    private TransformAndRotation tableSeven;
    [SerializeField]
    private TransformAndRotation tableEight;
    [SerializeField]
    private TransformAndRotation tableNine;


    public TransformAndRotation HandOne => handOne;
    public TransformAndRotation HandTwo => handTwo;
    public TransformAndRotation HandThree => handThree;
    public TransformAndRotation HandFour => handFour;
    public TransformAndRotation TableOne => tableOne;
    public TransformAndRotation TableTwo => tableTwo;
    public TransformAndRotation TableThree => tableThree;
    public TransformAndRotation TableFour => tableFour;
    public TransformAndRotation TableFive => tableFive;
    public TransformAndRotation TableSix => tableSix;
    public TransformAndRotation TableSeven => tableSeven;
    public TransformAndRotation TableEight => tableEight;
    public TransformAndRotation TableNine => tableNine;
}
