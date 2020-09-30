using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMusic : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/1DayEvening/SadPart");
        _audio.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        while(_audio.volume > 0)
        {
            _audio.volume -= 0.01f;
            yield return new WaitForFixedUpdate();
        }
        _audio.clip = Resources.Load<AudioClip>($"DB/Dropbox/Mortal Fate/Sound/1DayEvening/RomanticPart");
        _audio.Play();
        while (_audio.volume < 0.15f)
        {
            _audio.volume += 0.01f;
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }
}
