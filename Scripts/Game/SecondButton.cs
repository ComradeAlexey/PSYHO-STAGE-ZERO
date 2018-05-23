using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace PSYHO
{

    public class SecondButton : MonoBehaviour
    {
        [Header("Прочее")]
        public LogicOfPrinting mainGame;
        public Text text;
        public string textString;
        public void click()
        {
            if (!mainGame.readinessToButtonPressed)
            {
                switch (mainGame.typeOfWorkGlobal)
                {
                    case 0:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = false;
                        mainGame.buttonNumber = 2;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 2;
                        break;
                    case 1:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = false;
                        mainGame.buttonNumber = 2;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 2;
                        break;
                    case 2:
                        if (mainGame.inputField.text.Length > 0)
                        {
                            mainGame.readinessToButtonPressed = true;
                            mainGame.ButtonPressed = false;
                            mainGame.buttonNumber = 2;
                            if (mainGame.buttonMultiDialogNumber == 0)
                                mainGame.buttonMultiDialogNumber = 2;
                        }
                        break;
                    case 3:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.buttonNumber = 2;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 2;
                        break;
                    case 4:
                        mainGame.LoadMainMenuNotSave();
                        break;
                    case 6:
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = true;
                        mainGame.buttonNumber = 2;
                        if (mainGame.buttonMultiDialogNumber == 0)
                            mainGame.buttonMultiDialogNumber = 2;
                        break;
                }
            }
        }
    }
}