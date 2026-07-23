using UnityEngine;

public class Kick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandTag"))
        {
            Debug.Log("Get the fuck out of here fucking cunty twat");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}