using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleColor : MonoBehaviour {

    private Toggle toggle;
    private Color dimGrey = new Color(1F, 1F, 1F, .5F);

	// Use this for initialization
	void Start () {
        toggle = GetComponent<UnityEngine.UI.Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnToggleValueChanged(bool isOn)
    {
        ColorBlock cb = toggle.colors;
        if (isOn)
        {
            cb.normalColor = dimGrey;
            cb.highlightedColor = dimGrey;
        }
        else
        {
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
        }
        toggle.colors = cb;
    }
}
