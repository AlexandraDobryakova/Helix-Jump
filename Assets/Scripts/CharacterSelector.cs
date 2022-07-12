using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public static int selectedCharacter = 0;
    public Button[] buttons;

    public Material outline;
    public Material withoutOutline;

    void Start()
    {
        foreach(GameObject character in characters)
            character.SetActive(false);

        foreach (Button button in buttons)
            button.image.material = withoutOutline;

        buttons[selectedCharacter].image.material = outline;
        characters[selectedCharacter].SetActive(true);
    }

    public void ChangeCharacter(int newCharacter)
    {
        buttons[selectedCharacter].image.material = withoutOutline;
        characters[selectedCharacter].SetActive(false);
        buttons[newCharacter].image.material = outline;
        characters[newCharacter].SetActive(true);
        selectedCharacter = newCharacter;
    }
}
