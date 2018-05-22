using UnityEngine;

public class InTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Trigger");
    }
}
