using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void LoadSceneByName(string NameOfTheScene)
    {
        SceneManager.LoadScene(NameOfTheScene);
    }
}