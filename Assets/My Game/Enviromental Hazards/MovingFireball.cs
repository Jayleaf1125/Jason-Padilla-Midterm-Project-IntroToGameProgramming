using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class MovingFireball : MonoBehaviour
{
    public float fireballSpeed;
    public float fireballDistance;

    private Vector2 _intialPos;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _intialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(FireBallMovement());
        transform.position = new Vector2(_intialPos.x, Mathf.Sin(Time.time * fireballSpeed) * fireballDistance + _intialPos.y);
    }

    IEnumerator FireBallMovement()
    {
        _rb.AddForceY(fireballSpeed);
        yield return new WaitForSeconds(fireballDistance);
        //_rb.linearVelocityY = 0;
        _rb.AddForceY(-fireballSpeed);

    }

    /*


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("FirePit"))
        {
            StartCoroutine(FireBallMovement());
        }
    }
    */
}
