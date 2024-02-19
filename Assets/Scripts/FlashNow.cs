using System.Collections;
using UnityEngine;

public class FlashNow : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float duration = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mole"))
        {
            Debug.Log("Flash triggered by Mole");

            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (var wall in walls)
            {
                StartCoroutine(FlashLight(wall));
            }
        }
    }

    private IEnumerator FlashLight(GameObject wall)
    {
        MeshRenderer wallMeshRenderer = wall.GetComponent<MeshRenderer>();
        if (wallMeshRenderer != null)
        {
            wallMeshRenderer.enabled = true;

            SpriteRenderer flashlightMeshRenderer = GetComponent<SpriteRenderer>();
            if (flashlightMeshRenderer != null)
            {
                flashlightMeshRenderer.enabled = false;
            }

            yield return new WaitForSeconds(duration);

            wallMeshRenderer.enabled = false;
            Destroy(gameObject);
        }
    }
}
