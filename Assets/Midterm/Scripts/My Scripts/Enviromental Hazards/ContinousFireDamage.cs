using UnityEngine;
using System.Collections;

public class ContinousFireDamage : MonoBehaviour
{
    public float initialDamage;
    public float overTimeDamage;

    private bool _isContinousDamageActive = false;
    private Collider2D _playerGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _playerGameObject = collision.collider;

        if (_playerGameObject.CompareTag("Player"))
        {
            _playerGameObject.GetComponent<HealthSystem>().TakeDamage(initialDamage);
            _playerGameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _playerGameObject = collision.collider;
        _playerGameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
