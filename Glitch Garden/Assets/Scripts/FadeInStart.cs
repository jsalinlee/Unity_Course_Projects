using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInStart : MonoBehaviour {

    float fadeInTime = 2.0f;
    Image image;
    Text title;
    float imageAlpha;

	void Start () {
	    image = gameObject.GetComponent<Image>();
        title = gameObject.GetComponentInChildren<Text>();
	}

    void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime) {
            Color fade = image.color;
            float alphaChange = Time.deltaTime / fadeInTime;
            fade.a -= alphaChange;
            image.color = fade;
            title.color = fade;
        } else {
            gameObject.SetActive(false);
        }
    }
}
