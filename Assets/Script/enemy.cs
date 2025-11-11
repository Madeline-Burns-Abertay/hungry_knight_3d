using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<GameObject> Food;
    Animator Anim;
    bool IsPatrolling;
    float PatrolRadius = 6f;
    Vector3 Target;
    const float EPSILON = 0.01f;
    [SerializeField] float speed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPatrolling)
        {
            Vector2 randomPoint = Random.insideUnitCircle * PatrolRadius; // pick a point, any point
            Target = new Vector3(transform.position.x + randomPoint.x, 0, transform.position.z + randomPoint.y); // turn that point into a point in the game world
            //Debug.Log(destination);
            transform.LookAt(Target);
            IsPatrolling = true; // set off
        }
        if (Vector3.Distance(transform.position, Target) <= EPSILON)
        {
            IsPatrolling = false; // stop
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
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
        Instantiate(Food[Random.Range(0, Food.Count)], transform.position + (Vector3.up * 0.1f), Quaternion.identity);
        Anim.SetBool("dead", true);
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
