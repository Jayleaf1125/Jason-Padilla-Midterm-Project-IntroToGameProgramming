using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    // public Transform target;
    public float cameraFixedPosition;
    private Quaternion cameraRotation;

    public Transform player;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraRotation = this.transform.rotation;
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, cameraFixedPosition, transform.position.z);
        this.transform.rotation = cameraRotation;
    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
