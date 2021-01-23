using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_shutdown : MonoBehaviour
{
    private SpriteMask mask;
    // Start is called before the first frame update
    void Start()
    {
        mask = GetComponent<SpriteMask>();
        StartCoroutine(light());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator light()
    {
        float time = Random.Range(0.6f, 1.2f);
        yield return new WaitForSeconds(time);
        mask.enabled = !mask.enabled;
        StartCoroutine(light());
        yield return null;
    }
}
