using UnityEngine;
using UnityEngine.UI;

public class PrintingTheTextAboutLosing : MonoBehaviour
{
    [SerializeField] private Text TheTextAboutLosing;
    [SerializeField] private TransferringInformationBetweenScenes TransferringInformationBetweenScenes;

    private void Start()
    {
        string StringWithReason;
        if(TransferringInformationBetweenScenes.ZeroIfTheTankWasExploded == 0)
        {
            StringWithReason = "Your tank has been exploded.";
        }
        else
        {
            StringWithReason = "You have ended the game.";
        }
        TheTextAboutLosing.text = StringWithReason + "\n\nBefore that you had overcome " + TransferringInformationBetweenScenes.StringWithOvercomeDistance + " meters.";
    }
}