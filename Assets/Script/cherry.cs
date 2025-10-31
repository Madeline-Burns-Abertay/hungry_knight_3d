using UnityEngine;

public class cherry : MonoBehaviour
{
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, Time.deltaTime, 0);
    }


}
