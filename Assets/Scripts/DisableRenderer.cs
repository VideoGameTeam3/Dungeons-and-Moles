using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRendererAfterDelay : MonoBehaviour {
    [SerializeField] float delay = 7f;
    private MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();

        Invoke("DisableRenderer", delay);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered by: " + other.name);
    }

    private void DisableRenderer() {

        if (meshRenderer != null) {
            meshRenderer.enabled = false;
        }
    }
}
