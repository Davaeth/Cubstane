using UnityEngine.UI;
using UnityEngine;

public class hpUI : MonoBehaviour {

    public Text hp;

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " +  GameManager.GetHp().ToString();
    }
}
