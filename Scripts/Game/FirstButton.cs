using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace PSYHO
{

    public class FirstButton : MonoBehaviour
    {

        [Header("Прочее")]
        public LogicOfPrinting mainGame;
        public Text text;
        public string textString;
        public void click()
        {
            print("on click");
            print("mainGame.readinessToButtonPressed = " + mainGame.readinessToButtonPressed);
            print("mainGame.typeOfWorkGlobal = " + mainGame.typeOfWorkGlobal);
            if (!mainGame.readinessToButtonPressed)
            {
                switch (mainGame.typeOfWorkGlobal)
                {
                    case 0:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = true;
                        mainGame.buttonNumber = 1;
                        if(mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 1;
                        break;
                    case 1:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = true;
                        mainGame.buttonNumber = 1;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 1;
                        break;
                    case 2:
                        if (mainGame.inputField.text.Length > 0)
                        {
                            mainGame.readinessToButtonPressed = true;
                            mainGame.ButtonPressed = true;
                            mainGame.buttonNumber = 1;
                            if (mainGame.buttonMultiDialogNumber == 0)
                                mainGame.buttonMultiDialogNumber = 1;
                        }
                        break;
                    case 3:  
                        mainGame.readinessToButtonPressed = true;
                        mainGame.buttonNumber = 1;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 1;
                        break;
                    case 4:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.CheckPointLoad();
                        break;
                    case 6:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = true;
                        mainGame.buttonNumber = 1;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 1;
                        break;
                }

            }
        }
    }
}