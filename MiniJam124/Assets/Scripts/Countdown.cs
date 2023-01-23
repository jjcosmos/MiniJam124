using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AudioSource _src;
    [SerializeField] private AudioClip _beep;
    [SerializeField] private AudioClip _go;
    IEnumerator Start()
    {
        Game.Singleton.GameState = GameState.AwaitingStart;
        _text.text = "3";
        _src.PlayOneShot(_beep);
        yield return new WaitForSeconds(1f);
        _text.text = "2";
        _src.PlayOneShot(_beep);
        yield return new WaitForSeconds(1f);
        _text.text = "1";
        _src.PlayOneShot(_beep);
        yield return new WaitForSeconds(1f);
        _text.text = "GO!";
        _src.PlayOneShot(_go);
        Game.Singleton.StartRace();
        yield return new WaitForSeconds(1f);
        _text.gameObject.SetActive(false);
    }

}
