using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    [Header("Proudly made by ModelCrazy")]

    [Header("Objects to Enable")]
    public GameObject[] objectsToEnable;

    [Header("Objects to Disable")]
    public GameObject[] objectsToDisable;

    [Header("Tag Settings")]
    public string playerTag = "Player";

    [Header("Save Settings")]
    public bool saveState = true;
    public string saveKey = "EnableDisableState";

    void Start()
    {
        if (saveState)
        {
            bool savedState = PlayerPrefs.GetInt(saveKey, 0) == 1;

            if (savedState)
            {
                EnableObjects();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            EnableObjects();
        }
    }

    public void EnableObjects()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        SaveState();
    }

    void SaveState()
    {
        if (saveState)
        {
            PlayerPrefs.SetInt(saveKey, 1);
            PlayerPrefs.Save();
        }
    }
}