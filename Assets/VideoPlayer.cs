using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour {

    public string moviePath;

	// Use this for initialization
	
    public WWW wwwData;
    public MovieTexture m;
    public Renderer sphere;

    void Start()
    {
        StartCoroutine(LoadVideo());
        
    }

    IEnumerator LoadVideo()
    {
        Debug.Log("file:///" + Application.streamingAssetsPath + moviePath);
        wwwData = new WWW("file:///" + Application.streamingAssetsPath + moviePath);
        m = wwwData.GetMovieTexture();
        while (!m.isReadyToPlay)
            yield return new WaitForSeconds(1);
        sphere.material.mainTexture = m;
        m.loop = true;
        m.Play();
    }

    void Update()
    {
       

    }
}
