using UnityEngine;

[CreateAssetMenu(fileName = "TransferringInformationBetweenScenes", menuName = "ScriptableObjects/TransferringInformationBetweenScenes")]
public class TransferringInformationBetweenScenes : ScriptableObject
{
    public int ZeroIfTheTankWasExploded;
    public string StringWithOvercomeDistance;
}