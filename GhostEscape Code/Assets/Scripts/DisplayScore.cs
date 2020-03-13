using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = PlayerPrefs.GetFloat("levelScore").ToString();
    }

    // Update is called once per frame
}
