using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnJoin : MonoBehaviour
{
    [SerializeField]
    private InputField inputField_PlayerName;
    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnEvent()
    {
        playerName = inputField_PlayerName.text;
    }
}
