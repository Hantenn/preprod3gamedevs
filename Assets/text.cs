using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class text1 : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public int counter = 10;
    public bool stop = false;

    public void Start()
    {
        StartCoroutine(Temps());
    }
    public void Update()
    {
        counterText.text = counter.ToString();
    }

    private IEnumerator Temps()
    {
        yield return new WaitForSeconds(1);
        counter -= 1;
        if (counter < 0)
        {
            stop = true;
        }
        else
        {
            StartCoroutine(Temps());
        }
    }
}
