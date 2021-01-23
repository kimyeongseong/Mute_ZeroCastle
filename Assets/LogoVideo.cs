using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class LogoVideo : MonoBehaviour
{
    public VideoPlayer video;
    public float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1.5f)
        {
            if (!video.isPlaying)
            {
                SceneManager.LoadScene("Logo");
            }
        }
    }
}
