using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float turnSpeed = 300;
    private float moveSpeed = 1000;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);

        if (Input.GetAxis("Vertical") > 0 && Mathf.Abs(rb.linearVelocity.magnitude) < 7.5f)
        {
            rb.AddForce(transform.up * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        }
    }
}
