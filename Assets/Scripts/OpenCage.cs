using System.Collections;
using UnityEngine;

public class OpenCage : MonoBehaviour
{
    public Transform door; // Reference to the door object

    private bool canOpen = false;

    void OnEnable()
    {
        StartCoroutine(EnableMovementAfterDelay(7f));
    }

    void Update()
    {
        if (canOpen)
        {
            // Set only the X rotation of the door to 90 degrees, relative to the cave's rotation
            door.rotation = Quaternion.Euler(90f, door.rotation.eulerAngles.y, door.rotation.eulerAngles.z);
        }
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canOpen = true;
    }
}
