using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _vel2;
    private SpriteRenderer _sr;

    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _vel2.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _vel2 * movementSpeed * Time.fixedDeltaTime);
    }
}
