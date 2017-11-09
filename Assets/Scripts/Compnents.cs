using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compnents : MonoBehaviour {

    public int hp = 3;
    public int kupa = 3;
    public bool nande = false;

    // Update is called once per frame
    void FixedUpdate() {

        //Debug.Log(hp);
            DontDestroyOnLoad(gameObject);
            kupa--;
            PlayerPrefs.SetInt("hp", kupa);
            Debug.Log(hp);

        Graphics.activeTier.ToString();
        }
	}
