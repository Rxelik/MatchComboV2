using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSorter : MonoBehaviour
{
    public static TileSorter Instance { get; private set; }
    public float TileMoveSpeed;
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
    //Magazine _mag;
    //private void Start()
    //{
    //    _mag = Magazine.Instance;

    //}

    //public bool StopAnim = false;
    //private void LateUpdate()
    //{
    //    //Change The Speed Depending if you won or not
    //    //if (!StopAnim)
    //        //StartCoroutine(SortMagazineCorutine(0.5f));
    //    //else
    //    //    SortMagazineCorutine(0.01f);


    //}


    //public IEnumerator SortMagazineCorutine(float duration)
    //{
    //    int count = 0;
       
    //    //Takes the SortedMagazine and automaticly change its position to the magSlot
    //    //Yes its EVERY Second trying to fix its position
    //    //ONE DAY IT WILL BE BETTER I SWEAR
    //    //I WILL LEARN HOW TO MAKE IT BETTER
    //    //SOMETIMES TO WIN A WAR YOU MUST LOOSE A FIGHT!
    //    float t = 0;
    //    yield return new WaitUntil(() => _mag.SortedMagazine[count].transform.position == _mag.SortedMagazine[count].transform.position);
    //    for (int i = 0; i < _mag.SortedMagazine.Count; i++)
    //    {
    //        t += Time.deltaTime;
    //        _mag.SortedMagazine[i].transform.position = Vector2.MoveTowards(_mag.SortedMagazine[i].transform.position, _mag.MagazineSlots[i].position, t / duration);
    //        count++;
    //    }
    //    count = 0;
    //}
}
