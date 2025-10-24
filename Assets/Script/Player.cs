using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player settings")]

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int hangry;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float couldown;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 direction;
    [SerializeField] private float timerCouldown;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //All function
        Move();

        // Timer for the could down
        timerCouldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (timerCouldown <= 0)
            {
                StartCoroutine(Attack());
            }
        }

        //else if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}
    }

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //derection plalayer and move
        direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        //Rotation player
        transform.Rotate(new Vector3(0, 30 * horizontal, 0) * speed * Time.deltaTime);

        //Enable animation walk
        animator.SetBool("Walk", direction.magnitude > 0.1f);
    }

    IEnumerator Attack()
    {
        float speedPlayer = speed;
        speed = 0;

        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("Attack", false);
        timerCouldown = couldown;

        speed = speedPlayer;
    }

    //public void Jump()
    //{
    //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //}

}
