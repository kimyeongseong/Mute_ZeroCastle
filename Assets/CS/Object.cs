using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public AudioClip Break_Audio;
    bool my_coroutine_is_running;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator ObjectTouch()
    {
        my_coroutine_is_running = true;
        transform.position = new Vector2(this.gameObject.transform.position.x + 0.01f, this.gameObject.transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(this.gameObject.transform.position.x - 0.01f, this.gameObject.transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(this.gameObject.transform.position.x + 0.01f, this.gameObject.transform.position.y);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector2(this.gameObject.transform.position.x - 0.01f, this.gameObject.transform.position.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        this.gameObject.GetComponent<Animator>().enabled = true;
        yield return null;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& !my_coroutine_is_running)
        {
            int rand;
            rand = Random.Range(0, 100);
            if (rand <= 30)
                StartCoroutine(ObjectTouch());
        }
        if (collision.tag == "hall")
        {
            gameObject.tag = "sound";
            GetComponent<AudioSource>().PlayOneShot(Break_Audio);
            GetComponent<Animator>().SetBool("Break", true);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.tag = "Untagged";
        }
    }
}
