using UnityEngine;

public class GetSmaller : MonoBehaviour
{

    public AudioSource audiosource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mole"))
        {
            audiosource.Play();
            Debug.Log("GetBigger triggered by Mole");
            GetSmallerEffect(other.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void GetSmallerEffect(GameObject mole)
    {
        Vector3 newScale = new Vector3(mole.transform.localScale.x / 2f, mole.transform.localScale.y / 2f, mole.transform.localScale.z / 2f);

        mole.transform.localScale = newScale;    
    }
}
