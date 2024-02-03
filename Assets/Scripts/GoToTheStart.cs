using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTheStart : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the movement back to the starting point")]
    [SerializeField] string triggeringTag;

    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            ReturnToStart();
        }
    }

    private void ReturnToStart() {
        transform.position = startPosition;
    }

    private void Update() {
    }
}
