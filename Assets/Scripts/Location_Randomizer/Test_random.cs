using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_random : MonoBehaviour
{
    [SerializeField] private GameObject treat;

    [SerializeField] private List<GameObject> treat_list;

    // Start is called before the first frame update
    void Start()
    {
        treat_list.Add(treat);
        print(treat_list.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
