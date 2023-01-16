using UnityEngine;


[CreateAssetMenu(fileName = "InchangableValues", menuName = "ScriptableObjects/InchangableValues")]
public class InchangableValues : ScriptableObject
{
    [Header("Numbers of layers")]

    [SerializeField] private int _LayerOnlyWithTank;
    public int LayerOnlyWithTank { get => _LayerOnlyWithTank; }


    [Header("Names of virtual buttons in InputManager")]

    [SerializeField] private string _MovingForward;
    public string MovingForward { get => _MovingForward; }

    [SerializeField] private string _MovingBack;
    public string MovingBack { get => _MovingBack; }

    [SerializeField] private string _RotatingLeft;
    public string RotatingLeft { get => _RotatingLeft; }

    [SerializeField] private string _RotatingRight;
    public string RotatingRight { get => _RotatingRight; }

    [SerializeField] private string _Shooting;
    public string Shooting { get => _Shooting; }


    [Header("Names of scenes")]

    [SerializeField] private string _NameOfSceneForLosing;
    public string NameOfSceneForLosing { get => _NameOfSceneForLosing; }
}