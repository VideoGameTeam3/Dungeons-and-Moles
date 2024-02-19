using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTheStart : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the movement back to the starting point")]
    [SerializeField] string triggeringTag;

    private Vector3 startPosition;
    private bool isReturning = false; 
    private Renderer otherRenderer; 
    private InputMover inputMover;

    private void Start() {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled && !isReturning) {
            StartCoroutine(StopAndReturn(other.GetComponent<Renderer>(), this.GetComponent<InputMover>()));
        }
    }

    private IEnumerator StopAndReturn(Renderer renderer, InputMover Mover) {
        isReturning = true; // Set the flag to indicate that the object is returning
        renderer.enabled = true; // Enable the renderer of the other object
        Mover.enabled = false;
        yield return new WaitForSeconds(0.5f); // Wait for 1 second
        ReturnToStart(); // Return to the starting position
        Mover.enabled = true;
        renderer.enabled = false; // Disable the renderer of the other object
        isReturning = false; // Reset the flag
    }

    private void ReturnToStart() {
        transform.position = startPosition;
    }

    private void Update() {
        // Your update logic here
    }
}
