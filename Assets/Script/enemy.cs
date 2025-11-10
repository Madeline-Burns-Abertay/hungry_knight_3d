using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour
{
    [SerializeField] List<GameObject> food;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
