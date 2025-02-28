using UnityEngine;

    public class Jump : MonoBehaviour
    {
        public bool isJumping = false;
        public float jumpHeight;

        private Rigidbody2D _rb;
        private Vector2 _vel2;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Jumping();
        }

        void Jumping()
        {
            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                _rb.AddForce(new Vector2(_rb.position.x, jumpHeight));
                _rb.linearVelocity = _vel2;
                _rb.linearVelocity = new Vector2(_vel2.x, _rb.linearVelocity.y);
                isJumping = true;
            }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}