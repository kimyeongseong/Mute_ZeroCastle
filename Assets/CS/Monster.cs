using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    public AudioSource idle;
    public AudioSource trace;
    public AudioSource run;
    public AudioSource attack;
    private Animator Monster_Ani;
    bool walk;
    int state;
    bool tracing;
    private void Start()
    {
        Monster_Ani = GetComponent<Animator>();
        StartCoroutine(Walk());
    }
    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        if (!Monster_Ani.GetBool("Run"))
            transform.Translate((Vector3.left * state * Time.smoothDeltaTime) / 2);
    }
    public IEnumerator Walk()
    {
        if (!Monster_Ani.GetBool("Run"))
        {
            if (!trace.isPlaying)
                trace.Play();
            state = Random.Range(-1, 2);
            if (state == 0)
            {
                Monster_Ani.SetBool("Idle", true);
                Monster_Ani.SetBool("Walk", false);
            }
            else if (state == 1)
            {
                Monster_Ani.SetBool("Walk", true);
                Monster_Ani.SetBool("Idle", false);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (state == -1)
            {
                Monster_Ani.SetBool("Walk", true);
                Monster_Ani.SetBool("Idle", false);
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        float time = Random.Range(1.0f, 2.0f);
        yield return new WaitForSeconds(time);
        StartCoroutine(Walk());
        yield return null;
    }
    public void MoveToTarget()
    {
        direction = (target.position - transform.position).normalized;
        velocity = (velocity + accelaration * Time.deltaTime);
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= 1.5f)
        {
            if (target.gameObject.tag == "Player" &&target.GetComponent<Charater>().inside)
            {
                return;
            }
            state = 0;
            walk = false;
            Monster_Ani.SetBool("Idle", false);
            Monster_Ani.SetBool("Walk", false);
            Monster_Ani.SetBool("Run", true);
            if (idle.isPlaying)
                idle.Stop();
            if (!run.isPlaying)
                run.Play();
            if (direction.x <= -0.1f)
                GetComponent<SpriteRenderer>().flipX = false;
            else
                GetComponent<SpriteRenderer>().flipX = true;
            this.transform.position = new Vector3(transform.position.x + (direction.x * 0.5f * Time.smoothDeltaTime), transform.position.y, transform.position.z);
        }
        else
        {
            velocity = 0.0f;
            Monster_Ani.SetBool("Idle", false);
            Monster_Ani.SetBool("Walk", false);
            Monster_Ani.SetBool("Run", false);
            if (run.isPlaying)
                run.Stop();
            if (!idle.isPlaying)
                idle.Play();
        }
    }
}