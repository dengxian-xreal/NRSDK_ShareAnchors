using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using NRKernal.NRExamples;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class UUIDManager : MonoBehaviourPun
{
    public static UUIDManager instance; // Singleton instance

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    public void ShareAnchorUUID(string uuid)
    {
        photonView.RPC("ReceiveAnchorUUID", RpcTarget.Others, uuid);
    }

    [PunRPC]
    public void ReceiveAnchorUUID(string uuid)
    {
        Debug.Log("Received UUID: " + uuid);
        // Process the received UUID here.
        Debug.Log("ReceiveAnchorUUID:"+uuid);
        GameObject localMapDemo = GameObject.Find("LocalMapDemo");

        if (localMapDemo != null)
        {
            LocalMapExample localMapExample = localMapDemo.GetComponent<LocalMapExample>();
            if (localMapExample != null)
            {
                localMapExample.CloudLoad(uuid);
                Debug.Log("CloudLoad:"+uuid);
            }
            else
            {
                Debug.LogError("LocalMapExample component not found");
            }
        }
        else
        {
            Debug.LogError("LocalMapDemo GameObject not found");
        }
    }


}
