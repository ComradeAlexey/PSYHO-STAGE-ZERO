using UnityEngine;

public class ButtonNNA : MonoBehaviour
{
    public LogicOfPrinting mainGame;
    public void Click()
    {
        if (!mainGame.readinessToButtonPressed)
        {
            switch (mainGame.typeOfWorkGlobal)
            {
                case 0:
                    mainGame.readinessToButtonPressed = true;
                    mainGame.ButtonPressed = true;
                    break;
                case 1:
                    mainGame.readinessToButtonPressed = true;
                    mainGame.ButtonPressed = true;
                    break;
                case 2:
                    if (mainGame.inputField.text.Length > 0)
                    {
                        mainGame.readinessToButtonPressed = true;
                        mainGame.ButtonPressed = true;
                    }
                    break;
                case 3:
                    mainGame.readinessToButtonPressed = true;
                    break;
                case 4:
                    mainGame.readinessToButtonPressed = true;
                    mainGame.Load();
                    break;
            }

        }
    }
}