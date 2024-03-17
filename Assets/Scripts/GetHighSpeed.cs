using UnityEngine;

public class GetHighSpeed : MonoBehaviour
{

    public AudioSource audiosource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mole"))
        {
            audiosource.Play();
            Debug.Log("GetHighSpeed triggered by Mole");
            HighSpeedEffect(other.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void HighSpeedEffect(GameObject mole)
    {
        InputMover inputMover = mole.GetComponent<InputMover>();

        if (inputMover != null)
        {
            inputMover.SetSpeed(inputMover.GetSpeed() * 2);
        }
        else
        {
            Debug.LogError("InputMover script not found on the Mole GameObject!");
        }
    }
}
