using System.Collections;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    IEnumerator Start()
    {
        Game.Singleton.GameState = GameState.AwaitingStart;
        _text.text = "3";
        yield return new WaitForSeconds(1f);
        _text.text = "2";
        yield return new WaitForSeconds(1f);
        _text.text = "1";
        yield return new WaitForSeconds(1f);
        _text.text = "GO!";
        yield return new WaitForSeconds(1f);
        Game.Singleton.StartRace();
        _text.gameObject.SetActive(false);
    }

}
