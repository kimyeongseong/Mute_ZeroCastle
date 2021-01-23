using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public string a;
    public GameObject[] pause;
    public AudioListener listener;
    public bool pause_state;
    public int sound_num;
    public AudioClip[] sound;
    public void Scene()
    {
        SceneManager.LoadScene(a);
            Time.timeScale = 1;
    }
    public void Sound()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(sound[sound_num]);
        sound_num++;
    }
    public void sound2()
    {
        GetComponent<AudioSource>().PlayOneShot(sound[sound_num]);
        sound_num++;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==3)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause_state)
            {
                pause[0].SetActive(!pause_state);
                pause_state = false;
                Time.timeScale = 1;
                listener.enabled = true;
            }
            else if (!pause_state)
            {
                pause[0].SetActive(!pause_state);
                pause_state = true;
                Time.timeScale = 0;
                listener.enabled = false;
            }
        }
    }
    public void continew()
    {
        if (pause_state)
        {
            pause[0].SetActive(!pause_state);
            pause_state = false;
            Time.timeScale = 1;
            listener.enabled = true;
        }
        else if (!pause_state)
        {
            pause[0].SetActive(!pause_state);
            pause_state = true;
            Time.timeScale = 0;
            listener.enabled = false;
        }
    }
}
