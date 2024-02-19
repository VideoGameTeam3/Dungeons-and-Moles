using UnityEngine;

public class GetHighSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mole"))
        {
            Debug.Log("GetHighSpeed triggered by Mole");
            HighSpeedEffect(other.gameObject);
            Destroy(gameObject);
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
