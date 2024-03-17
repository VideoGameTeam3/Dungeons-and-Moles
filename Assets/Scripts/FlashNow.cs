using System.Collections;
using UnityEngine;
using TMPro;

public class FlashNow : MonoBehaviour
{
    [Tooltip("The number of seconds that the shield remains active")]
    [SerializeField] float duration = 2;
    [SerializeField] private TextMeshProUGUI Text;
    public AudioSource audiosource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mole"))
        {
            audiosource.Play();
            Text.gameObject.SetActive(false);
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (var wall in walls)
            {
                StartCoroutine(Flash(wall));
            }
        }
    }

    private IEnumerator Flash(GameObject wall)
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
