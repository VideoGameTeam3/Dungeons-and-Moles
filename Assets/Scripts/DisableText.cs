using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisableTextAfterDelay : MonoBehaviour {
    [SerializeField] float delay = 7f;
    private TextMeshProUGUI textRenderer;

    private void Start() {
        textRenderer = GetComponent<TextMeshProUGUI>();

        Invoke("DisableRenderer", delay);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered by: " + other.name);
    }

    private void DisableRenderer() {

        if (textRenderer != null) {
            textRenderer.enabled = false;
        }
    }
}
