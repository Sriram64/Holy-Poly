using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddToScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int score;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
}
