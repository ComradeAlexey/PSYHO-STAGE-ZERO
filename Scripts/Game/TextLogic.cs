using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextLogic : MonoBehaviour {
    private string localPrintingText;
    private string printingMainText;
    private bool isFinalPrintingText;
    private bool isFinalDeletingText;
    private LogicOfPrinting mainLogic;
    public TextLogic(LogicOfPrinting thisLogicOfPrinting, string printingMainText, string printingAnswerOneText, string printingAnswerTwoText)
    {
        LocalPrintingText = "";
        MainLogic = thisLogicOfPrinting;
        PrintingMainText = printingMainText;
        IsFinalPrintingText = false;
        IsFinalDeletingText = false;
    }

    private void MainTextPrinting()
    {
        if (LocalPrintingText.Length < PrintingMainText.Length)
        {
            LocalPrintingText += PrintingMainText[LocalPrintingText.Length];
        }
        else
        {
            IsFinalPrintingText = true;
        }
    }

    private void MainTextDeleting()
    {
        LocalPrintingText = "";
        IsFinalDeletingText = true;
    }

    private void SetVarInMainLogic()
    {
        MainLogic.mainText.text = LocalPrintingText;
    }

    private void DeletingOrPrinting()
    {
        if (MainLogic.readinessToButtonPressed)
        {
            MainTextDeleting();
        }
        else
        {
            MainTextPrinting();
        }
    }

    private void EnableDefaultButtons()
    {
        if (isFinalPrintingText)
        {
            MainLogic.buttonOptionOne.SetActive(true);
            MainLogic.buttonOptionTwo.SetActive(true);
        }
    }

    public void UpdateStandart()
    {
        DeletingOrPrinting();
        EnableDefaultButtons();
        SetVarInMainLogic();
    }
    public string LocalPrintingText
    {
        get
        {
            return localPrintingText;
        }
        set
        {
            localPrintingText = value;
        }
    }
    public string PrintingMainText
    {
        get
        {
            return printingMainText;
        }

        set
        {
            printingMainText = value;
        }
    }
    public bool IsFinalPrintingText
    {
        get
        {
            return isFinalPrintingText;
        }

        set
        {
            isFinalPrintingText = value;
        }
    }
    public bool IsFinalDeletingText
    {
        get
        {
            return isFinalDeletingText;
        }

        set
        {
            isFinalDeletingText = value;
        }
    }
    public LogicOfPrinting MainLogic
    {
        get
        {
            return mainLogic;
        }

        set
        {
            mainLogic = value;
        }
    }


}
