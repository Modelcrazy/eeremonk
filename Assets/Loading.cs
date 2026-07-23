using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    [Header("Scene")]
    public string sceneToLoad = "MainMenu";

    [Header("UI")]
    public TextMeshPro loadingText;

    [Header("Settings")]
    public float messageDelay = 3f;

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingText.text = "No internet, please restart";
            yield break;
        }

        loadingText.text = "Loading Player...";
        yield return new WaitForSeconds(messageDelay);

        loadingText.text = "Loading Account...";
        yield return new WaitForSeconds(messageDelay);

        loadingText.text = "Loading Servers...";
        yield return new WaitForSeconds(messageDelay);

        loadingText.text = "Loading PlayFab...";
        yield return new WaitForSeconds(messageDelay);

        loadingText.text = "setup complete yaysies";
        yield return new WaitForSeconds(messageDelay);

        SceneManager.LoadScene(sceneToLoad);
    }
}