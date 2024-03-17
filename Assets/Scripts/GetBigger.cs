using UnityEngine;

public class GetBigger : MonoBehaviour
{

    public AudioSource audiosource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mole"))
        {
            audiosource.Play();
            Debug.Log("GetBigger triggered by Mole");
            GetBiggerEffect(other.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void GetBiggerEffect(GameObject mole)
    {
        Vector3 newScale = new Vector3(mole.transform.localScale.x * 2f, mole.transform.localScale.y * 2f, mole.transform.localScale.z * 2f);

        mole.transform.localScale = newScale;    
    }
}
