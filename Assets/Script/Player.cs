using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player settings")]
    public float hungry;
    public float maxHungry;

    [SerializeField] private float hungryAwayTime;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float couldown;
    [SerializeField] private float couldownDush;

    [Header("Player UI Componets")]

    [SerializeField] private Image hungryBar;
    [SerializeField] private TMP_Text textHungry;

    private Rigidbody rb;
    private Animator animator;
    private Vector3 direction;
    private float timerCouldown, timerHungry, timerDush;
    private float horizontal, vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //All function
        MovmentPlaye();
        UpdateCharacteristic();
        TakeAwayHungry();
        DieCheckingOrHungryNull();

        // Timer for the could down
        timerCouldown -= Time.deltaTime;
        timerDush -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z)) {
            if (timerCouldown <= 0)
            {
                StartCoroutine(Attack());
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Dash();
        }

        //else if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}
    }


    public void MovmentPlaye()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //derection plalayer and move
        direction = new Vector3(horizontal, 0, vertical);
        transform.Translate(direction * speed * Time.deltaTime);

        //Rotation player
        transform.Rotate(new Vector3(0, 30 * horizontal, 0) * speed * Time.deltaTime);

        //Enable animation walk
        animator.SetBool("Walk", direction.magnitude > 0.1f);
    }

    public void Dash()
    {
        if (timerDush <= 0)
        {
            transform.Translate(new Vector3(200, 0, 0) * speed * Time.deltaTime);
            timerDush = couldownDush;
        }
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

    public void UpdateCharacteristic()
    {
        hungryBar.fillAmount = hungry / maxHungry; //Update HungryBar image 
        textHungry.text = $"{maxHungry}/{hungry}";  //Update text in hungryBar

    }
    public void TakeDownhungry(int damage) 
    { 
        hungry -= damage;
    }
    public void TakeAwayHungry()
    {
        timerHungry -= Time.deltaTime;
        if(timerHungry <= 0f)
        {
            hungry -= 1;
            timerHungry = 1;
        }
        
    }

    public void DieCheckingOrHungryNull()
    {
        if (hungry <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
