using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenereset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void hello()
    {
        PlayerPrefs.DeleteAll();
         SceneManager.LoadScene(1);
    }
}
