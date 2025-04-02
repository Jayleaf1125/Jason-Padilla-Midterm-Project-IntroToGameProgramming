using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _vel2;
    private SpriteRenderer _sr;
    private Animator _animator;
    public bool isFacingRight = true;

    public float movementSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _vel2.x = Input.GetAxisRaw("Horizontal");
        FlipCharacterSprite();
        this.transform.Rotate(0, 0, 0);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _vel2 * movementSpeed * Time.fixedDeltaTime);

        float xVel = Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"));
        if (xVel > 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    private void FlipCharacterSprite()
    {
        if (_vel2.x == -1 && isFacingRight)
        {
            isFacingRight = false;
            transform.Rotate(0, 180, 0);
            return;
        }

        if (_vel2.x == 1 && !isFacingRight)
        {
            isFacingRight = true;
            transform.Rotate(0, 180, 0);
            return;
        }

    }
}
