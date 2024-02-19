using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class newMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveVertical = new InputAction(type: InputActionType.Button);

    private bool canMove = false;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    void OnEnable()
    {
        moveHorizontal.Enable();
        moveVertical.Enable();
        StartCoroutine(EnableMovementAfterDelay(7f));
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    void Update()
    {
        if (canMove)
        {
            float horizontal = moveHorizontal.ReadValue<float>();
            float vertical = moveVertical.ReadValue<float>();

            Vector2 movementDirection = new Vector2 (horizontal, vertical);
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();

            transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

            if (movementDirection != Vector2.zero){
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500f * Time.deltaTime);
        }
        }
    
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
