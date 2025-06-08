using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SaveInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficulty;
    [SerializeField] private TextMeshProUGUI maintext;

    public void LoadSceneByIndex()
    {
        My_Text.Difficult = difficulty.text;

        if (string.IsNullOrEmpty(My_Text.Difficult) || My_Text.side == -1)
        {
            maintext.text = "U didn't type date";
            maintext.fontSize = 12; 
            maintext.color = Color.red;
            return;
        }
        SceneManager.LoadScene(1);
    }

    public void SwitchToScene()
    {
        My_Text.Difficult = null;
        My_Text.side = -1;

        SceneManager.LoadScene(0);
    }
}
