using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject myObj;
    [SerializeField] private string type;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(0, 999);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveAllObservers();
    }

    public void OnInteract()
    {
        this.myObj.SetActive(false);
    }

    public string getInteractableType()
    {
        return this.type;
    }
}
