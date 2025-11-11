using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour
{
    [SerializeField] List<GameObject> food;
    Animator anim;
    bool isPatrolling;
    float patrolRadius = 6f;
    Vector3 destination;
    const float epsilon = 0.01f;
    [SerializeField] float speed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPatrolling)
        {
            Vector2 randomPoint = Random.insideUnitCircle * patrolRadius; // pick a point, any point
            destination = new Vector3(transform.position.x + randomPoint.x, 0, transform.position.z + randomPoint.y); // turn that point into a point in the game world
            //Debug.Log(destination);
            transform.LookAt(destination);
            isPatrolling = true; // set off
        }
        if (Vector3.Distance(transform.position, destination) <= epsilon)
        {
            isPatrolling = false; // stop
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        Debug.Log("Is patrolling? " + isPatrolling.ToString() + "; Distance: " + Vector3.Distance(transform.position, destination) + "; Direction: " + transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<Player>().TakeDownhungry(999);
        } 
        else if (other.CompareTag("Sword"))
        {
            this.enabled = false;
            StartCoroutine(die());
        }
    }

    IEnumerator die()
    {
        Instantiate(food[Random.Range(0, food.Count)], transform.position + (Vector3.up * 0.1f), Quaternion.identity);
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
