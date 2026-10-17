using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public GameObject counter;

    public int VHSCount;


    void Start()
    {
        VHSCount = 0;
        
    }



    void Update()
    {
        counter.GetComponent<Text>().text = VHSCount + "/9";

    }
}
