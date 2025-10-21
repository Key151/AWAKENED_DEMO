using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    private bool isWaiting;
    private Vector2 toMove;
    Animator anim;

    void Start()
    {
        toMove = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.IsGamePaused || isWaiting)
        {
            return;
        }

        MoveFoward();
    }

    void MoveFoward()
    {
        Vector2 target = toMove;

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Vector2 direction = target - (Vector2)transform.position;

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            StartCoroutine(Wait());
        }
        else
        {
            anim.SetBool("Walk", true);
            if(direction.x > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
    }

    IEnumerator Wait()
    {
        anim.SetBool("Walk", false);
        isWaiting = true;
        
        yield return new WaitForSeconds(waitTime);

        if (Random.Range(0, 2) == 0)
        {
            toMove += new Vector2(Random.Range(-3.5f,3.5f), 0);
        }
        else
        {
            toMove += new Vector2(0, Random.Range(-3.5f, 3.5f));
        }

        isWaiting = false;
    }

}
