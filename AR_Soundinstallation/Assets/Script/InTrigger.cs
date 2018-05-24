using UnityEngine;


public class InTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.PostEvent("Music", gameObject);

        Debug.Log("Enter Trigger"); 
        AkSoundEngine.SetState("Music_State", "In");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit Trigger");
        AkSoundEngine.SetState("Music_State", "Out");
    }
}
