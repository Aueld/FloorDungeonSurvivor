using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIButtonNavigation : MonoBehaviour
{
    public Button GameStart;
    public Button[] LevelUpSelectAbilityButtons; // UI 버튼 배열
    private int selectedIndex = 0;

    private void LateUpdate()
    {
        if (GameManager.inst.startPanel.activeSelf)
        {
            //var gamepad = Gamepad.current;
            //if (gamepad != null)
            //{
            //    if (gamepad.dpad.down.wasPressedThisFrame)
            //        GameStart.Select();
            //}
            //else
            //{
                if (Keyboard.current.anyKey.wasPressedThisFrame)
                    GameStart.Select();
            //}
        }
        else
        {
            // Input System을 통해 UI 버튼을 위아래로 이동
            var gamepad = Gamepad.current;
            if (gamepad != null)
            {
                if (gamepad.dpad.up.wasPressedThisFrame)
                    MoveSelectionUp();
                else if (gamepad.dpad.down.wasPressedThisFrame)
                    MoveSelectionDown();
            }
            else
            {
                // 키보드 사용
                if (Keyboard.current.wKey.wasPressedThisFrame)
                    MoveSelectionUp();
                else if (Keyboard.current.sKey.wasPressedThisFrame)
                    MoveSelectionDown();
            }
        }
    }

    public void SelectButton()
    {
        if (LevelUpSelectAbilityButtons.Length > 0)
        {
            LevelUpSelectAbilityButtons[selectedIndex].Select();
        }
    }

    private void MoveSelectionUp()
    {
        selectedIndex = (selectedIndex - 1 + LevelUpSelectAbilityButtons.Length) % LevelUpSelectAbilityButtons.Length;
        LevelUpSelectAbilityButtons[selectedIndex].Select();
    }

    private void MoveSelectionDown()
    {
        selectedIndex = (selectedIndex + 1) % LevelUpSelectAbilityButtons.Length;
        LevelUpSelectAbilityButtons[selectedIndex].Select();
    }
}