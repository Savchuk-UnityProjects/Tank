using UnityEngine;

public class OpeningLink : MonoBehaviour
{
    public void OpenTheLink(string URL)
    {
        Application.OpenURL(URL);
    }
}