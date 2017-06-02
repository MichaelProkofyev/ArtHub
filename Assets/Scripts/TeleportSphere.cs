using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class TeleportSphere : VRTK_InteractableObject
{
    [SerializeField]
    private string sceneName;

    Vector3 startPosition;

    bool returningToStart;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        InteractableObjectUngrabbed += ReturnToStart;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ReturnToStart(object sender, InteractableObjectEventArgs e)
    {
        //    returningToStart = true;
        transform.position = startPosition;
    }

    public string GetSceneName()
    { return sceneName; }
}
