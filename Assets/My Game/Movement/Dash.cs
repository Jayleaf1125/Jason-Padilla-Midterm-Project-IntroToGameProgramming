using UnityEngine;
using System.Collections;
using static UnityEngine.ParticleSystem;

public class Dash : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _vel2;
    private SpriteRenderer _sr;
    private Animator _animator;

    public float dashSpeed;
    public float dashDuration = 1.0f;
    public float dashCooldown = 1.0f;
    public bool isDashing = false;

    public ParticleSystem particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        particles.Stop();
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
            _animator.SetBool("isDashing", true);
            isDashing = true;
            particles.Play();

            yield return new WaitForSeconds(dashDuration);

            particles.Stop();
            _animator.SetBool("isDashing", false);
            GetComponent<Movement>().movementSpeed /= dashSpeed;
            StartCoroutine(DashCooldown());
        }
    }

    IEnumerator DashCooldown()
    {
        while (isDashing)
        {
            _sr.color = Color.cyan;
            yield return new WaitForSeconds(dashCooldown);
            _sr.color = Color.white;
            isDashing = false;
            break;
        }
    }
}
