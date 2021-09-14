using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private GameObject treat;
    [SerializeField] private GameObject treat1;
    [SerializeField] private GameObject treat2;
    [SerializeField] private GameObject treat3;
    [SerializeField] private GameObject treat4;
    [SerializeField] private GameObject treat5;
    [SerializeField] private GameObject treat6;
    [SerializeField] private GameObject treat7;
    [SerializeField] private GameObject treat8;
    [SerializeField] private GameObject treat9;
    [SerializeField] private GameObject treat10;
    [SerializeField] private GameObject treat11;
    [SerializeField] private GameObject treat12;
    [SerializeField] private GameObject treat13;
    [SerializeField] private GameObject treat14;
    [SerializeField] private GameObject treat15;
    [SerializeField] private GameObject treat16;
    [SerializeField] private GameObject treat17;
    [SerializeField] private GameObject treat18;
    [SerializeField] private GameObject treat19;
    [SerializeField] private GameObject treat20;
    [SerializeField] private GameObject treat21;
    [SerializeField] private GameObject treat22;
    [SerializeField] private GameObject treat23;
    [SerializeField] private GameObject treat24;
    [SerializeField] private GameObject treat25;
    [SerializeField] private GameObject treat26;
    [SerializeField] private GameObject treat27;
    [SerializeField] private GameObject treat28;
    [SerializeField] private GameObject treat29;
    [SerializeField] private GameObject treat30;
    [SerializeField] private GameObject treat31;
    [SerializeField] private GameObject treat32;
    [SerializeField] private GameObject treat33;
    [SerializeField] private GameObject treat34;
    [SerializeField] private GameObject treat35;
    [SerializeField] private GameObject treat36;
    [SerializeField] private GameObject treat37;
    [SerializeField] private GameObject treat38;
    [SerializeField] private GameObject treat39;
    [SerializeField] private GameObject treat40;

    [SerializeField]  private List<GameObject> treat_list;
    // Start is called before the first frame update
    void Start()
    {
        treat_list.Add(treat);
        treat_list.Add(treat1);
        treat_list.Add(treat2);
        treat_list.Add(treat3);
        treat_list.Add(treat4);
        treat_list.Add(treat5);
        treat_list.Add(treat6);
        treat_list.Add(treat7);
        treat_list.Add(treat8);
        treat_list.Add(treat9);
        treat_list.Add(treat10);
        treat_list.Add(treat11);
        treat_list.Add(treat12);
        treat_list.Add(treat13);
        treat_list.Add(treat14);
        treat_list.Add(treat15);
        treat_list.Add(treat16);
        treat_list.Add(treat17);
        treat_list.Add(treat18);
        treat_list.Add(treat19);
        treat_list.Add(treat20);
        treat_list.Add(treat21);
        treat_list.Add(treat22);
        treat_list.Add(treat23);
        treat_list.Add(treat24);
        treat_list.Add(treat25);
        treat_list.Add(treat26);
        treat_list.Add(treat27);
        treat_list.Add(treat28);
        treat_list.Add(treat29);
        treat_list.Add(treat30);
        treat_list.Add(treat31);
        treat_list.Add(treat32);
        treat_list.Add(treat33);
        treat_list.Add(treat34);
        treat_list.Add(treat35);
        treat_list.Add(treat36);
        treat_list.Add(treat37);
        treat_list.Add(treat38);
        treat_list.Add(treat39);
        treat_list.Add(treat40);

        EventBroadcaster.Instance.AddObserver(EventNames.JabubuEvents.TREAT_FOUND, this.SpawnRandom);
        
        SpawnRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandom()
    {
        int num = Random.Range(1, 41);

        GameObject rando = treat_list[num];

        rando.SetActive(true);
    }
}
