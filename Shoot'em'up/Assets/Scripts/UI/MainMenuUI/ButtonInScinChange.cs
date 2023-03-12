using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInScinChange : MonoBehaviour
{
    public DataSaver save;
    [SerializeField] private int scinPrice;
    [SerializeField] private bool isBuy = false;
    [SerializeField] private int scinNumber;
    [SerializeField] private Text text;
    [SerializeField] private GameObject cube;
    void Start()
    {
        isBuy = save.data.availableScins[scinNumber];
        text.text = scinPrice.ToString();
        
        if (isBuy)
        {
            text.text = "Set";
            cube.SetActive(false);
        }
    }

    public void BuyOrChange()
    {
        if (!isBuy)
        {
            if (save.data.scores >= scinPrice)
            {
                save.data.scores -= scinPrice;
                isBuy = true;
                text.text = "Set";
                save.data.availableScins[scinNumber] = true;
                cube.SetActive(false);
                save.Save();
                save.ChangeScores();
                return;
            }
        }

        if (isBuy)
        {
            save.data.currentScinNumber = scinNumber;
            save.Save();
        }
            
    }
}
