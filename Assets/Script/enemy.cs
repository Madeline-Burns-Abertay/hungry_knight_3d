using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private GameObject cherry;
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("alive")) { 
            StartCoroutine(onDeath());
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    IEnumerator onDeath()
    {
        animator.SetBool("alive", false);
        Instantiate(cherry, transform.position + Vector3.up, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
