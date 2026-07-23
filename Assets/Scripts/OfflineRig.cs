using Photon.Pun;
using Photon.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineRig : MonoBehaviour
{
    public GameObject[] offline;
    public GameObject[] online;

    public void Update()
    {
        if (PhotonNetwork.InRoom == false)
        {
            SetObjects(offline, true);
            SetObjects(online, false);
        }
        else
        {
            SetObjects(offline, false);
            SetObjects(online, true);
        }
    }

    void SetObjects(GameObject[] objects, bool state)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(state);
            }
        }
    }
}