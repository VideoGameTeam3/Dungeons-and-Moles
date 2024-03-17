using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTheStart : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the movement back to the starting point")]
    [SerializeField] string triggeringTag;
    public AudioSource audiosource;
    private Vector3 startPosition;
    private Vector3 startSize;
    private bool isReturning = false; 
    private Renderer otherRenderer; 
    private InputMover inputMover;
    private float initialSpeed;
    private GameObject[] potions;
    

    private void Start() {
        startPosition = transform.position;
        startSize = transform.localScale;
        inputMover = GetComponent<InputMover>();
        initialSpeed = inputMover.GetSpeed();
        potions = GameObject.FindGameObjectsWithTag("Potions");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled && !isReturning) {
            StartCoroutine(StopAndReturn(other.GetComponent<Renderer>(), this.GetComponent<InputMover>()));
            audiosource.Play();
        }
    }

    private IEnumerator StopAndReturn(Renderer renderer, InputMover Mover) {
        isReturning = true; // Set the flag to indicate that the object is returning
        renderer.enabled = true; // Enable the renderer of the other object
        Mover.enabled = false; // Disable the Mover of the character
        yield return new WaitForSeconds(0.5f); // Wait for 1 second
        ReturnToStart(); // Return to the starting position
        Mover.enabled = true; // Enable the Mover of the character
        renderer.enabled = false; // Disable the renderer of the other object
        isReturning = false; // Reset the flag
    }

    private void ReturnToStart() {
        transform.position = startPosition;
        transform.localScale = startSize;
        inputMover.SetSpeed(initialSpeed);
        foreach (var potion in potions)
            {
                if (!potion.activeSelf)
                    potion.SetActive(true);
            }
    }

    private void Update() {
    }
}
