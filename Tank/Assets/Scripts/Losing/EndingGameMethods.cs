using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGameMethods : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextWithDistance;
    [SerializeField] private TransferringInformationBetweenScenes TransferringInformationBetweenScenes;
    [SerializeField] private InchangableValues CatalogOfInchangableValues;

    public void EndGame()
    {
        TransferringInformationBetweenScenes.StringWithOvercomeDistance = TextWithDistance.text;
        SceneManager.LoadScene(CatalogOfInchangableValues.NameOfSceneForLosing);
    }

    private void SaveZeroIfTheTankWasExploded(bool WasTheTankExploded)
    {
        TransferringInformationBetweenScenes.ZeroIfTheTankWasExploded = WasTheTankExploded ? 0 : 1;
    }
    public void SendThatTheTankWasExploded() => SaveZeroIfTheTankWasExploded(true);
    public void SendThatTheTankWasNotExploded() => SaveZeroIfTheTankWasExploded(false);
}