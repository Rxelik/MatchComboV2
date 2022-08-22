using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : MonoBehaviour
{
    public static PlayState Instance { get; private set; }
    public int emptySpaces;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    Magazine mag;
    public int currentScene = 0;


    private void Start()
    {
        mag = Magazine.Instance;
        EventManager.Instance.CheckLostEvent += LostEvent;
        //EventManager.Instance.CheckWinEvent += WinEvent;
    }
    private void Update()
    {
        emptySpaces = mag.MagazineSlots.Count - mag.SortedMagazine.Count;
        if (BoardManager.Instance.TilesInBoard.Count <= emptySpaces && !CheckedIfWon)
        {
            StartCoroutine(WinEvent());
        }
    }
    private void LostEvent(object sender, EventArgs e)
    {
        if (true)
        {
            if (mag.SortedMagazine.Count == mag.mSize
                && mag._NumberOfones < 3
                && mag._NumberOftwos < 3
                && mag._NumberOfthrees < 3
                && mag._NumberOffours < 3
                && mag._NumberOffives < 3
                && mag._NumberOfsix < 3
                && mag._NumberOfSeven < 3
                && mag._NumberOfEight < 3
                && mag.NumberOfNine < 3
                )
            {
                mag.UI.SetActive(true);
            }
        }

    }

    bool CheckedIfWon = false;
    private IEnumerator WinEvent()
    {
        EventManager.Instance.CorutineStarter?.Invoke(this, EventArgs.Empty);
        CheckedIfWon = true;
        print("You Win!!!!");


        // Version 1 // 

        foreach (var item in BoardManager.Instance.TilesInBoard)
        {
            yield return new WaitForSeconds(0.2f);
            item.GetComponent<Tile>().input.TileSelected();
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(item.GetComponent<Tile>().input.DestoryTile());
        }

        //  Version 2 //

        //foreach (var item in BoardManager.Instance.TilesInBoard)
        //{
        //    yield return new WaitForSeconds(0.4f);
        //    item.GetComponent<Tile>().input.TileSelected();
        //}
        //yield return new WaitForSeconds(0.3f);
        //EventManager.Instance.BurnClipEvent?.Invoke(this, EventArgs.Empty);
    }
}
