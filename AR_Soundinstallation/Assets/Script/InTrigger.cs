using UnityEngine;


public class InTrigger : MonoBehaviour {
    private void Start()
    {
        AkSoundEngine.SetState("Music_State", "In");
        AkSoundEngine.PostEvent("Music", gameObject);
    }

    private void OnTriggerEnter()
    {
        AkSoundEngine.SetState("Music_State", "In");
        Debug.Log("Enter Trigger");
        
        //AkSoundEngine.PostEvent("test", gameObject);
    }

    private void OnTriggerExit()
    {
        Debug.Log("Exit Trigger");
        AkSoundEngine.SetState("Music_State", "Out");
    }
}
