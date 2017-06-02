using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Transfer : MonoBehaviour
{

    public string path;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
            TransferTo();
    }

    void TransferTo()
    {
        Process p;
        ProcessStartInfo processInfo = new ProcessStartInfo(path);
        processInfo.UseShellExecute = true;
        processInfo.WorkingDirectory = path.Substring(0, path.LastIndexOf('\\'));

        try
        {
            p = Process.Start(processInfo);
        }
        catch(Exception e)
        {
            UnityEngine.Debug.Log(e.Message);
        }
    }
}
