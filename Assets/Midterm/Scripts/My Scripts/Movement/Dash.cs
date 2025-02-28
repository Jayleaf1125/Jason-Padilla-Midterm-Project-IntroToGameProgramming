using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _vel2;
    private SpriteRenderer _sr;

    public float dashSpeed;
    public float dashDuration = 1.0f;
    public float dashCooldown = 1.0f;
    public bool isDashing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Dashing());
    }

    IEnumerator Dashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            GetComponent<Movement>().movementSpeed *= dashSpeed;
            _sr.color = Color.yellow;
            isDashing = true;

            yield return new WaitForSeconds(dashDuration);

            GetComponent<Movement>().movementSpeed /= dashSpeed;
            _sr.color = Color.white;
            StartCoroutine(DashCooldown());
        }
    }

    IEnumerator DashCooldown()
    {
        while (isDashing)
        {
            _sr.color = Color.red;
            yield return new WaitForSeconds(dashCooldown);
            _sr.color = Color.white;
            isDashing = false;
            break;
        }
    }
}
