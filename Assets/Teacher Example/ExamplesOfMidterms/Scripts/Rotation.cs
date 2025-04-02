using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationVal = 0;
    public float rotationSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Increasing the rotation value by the speed
        rotationVal += rotationSpeed * Time.deltaTime;

        // Setting the roation value
        transform.rotation = Quaternion.Euler(0, 0, rotationVal);
    }
}