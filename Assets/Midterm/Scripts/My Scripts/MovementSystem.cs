using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _vel2;
    private SpriteRenderer _sr;

    public float movementSpeed;

    public float dashSpeed;
    public bool isDashing = false;

    public bool isJumping = false;
    public float jumpHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _vel2.x = Input.GetAxisRaw("Horizontal");
        StartCoroutine(Dash());
        Jumping();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _vel2 * movementSpeed * Time.fixedDeltaTime);
    }

    IEnumerator Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            movementSpeed *= dashSpeed;
            _sr.color = Color.yellow;

            yield return new WaitForSeconds(0.3f);

            movementSpeed /= dashSpeed;
            _sr.color = Color.white;
        }
    }

    void Jumping()
    {
        if(Input.GetButtonDown("Jump") )
        {
            _rb.AddForce(new Vector2(_rb.position.x, jumpHeight));
            isJumping = true;
        }
        isJumping = false;
    }


}
