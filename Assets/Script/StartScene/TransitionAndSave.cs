using UnityEngine;
using TMPro;

public class SaveInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficulty;
    [SerializeField] private TextMeshProUGUI maintext;

    private string previousDifficulty = "";

    void Update()
    {
        string currentDifficulty = difficulty.text;

        if (currentDifficulty != previousDifficulty)
        {
            previousDifficulty = currentDifficulty;
            Debug.Log("Difficulty changed to: " + currentDifficulty);

            My_Text.Difficult = currentDifficulty;

            // Знайти всі MazeCellGenerator на сцені
            MazeCellGenerator[] generators = FindObjectsOfType<MazeCellGenerator>();

            foreach (var generator in generators)
            {
                // Видалити стару сітку (опціонально, якщо потрібно очищення)
                foreach (Transform child in generator.transform)
                {
                    Destroy(child.gameObject);
                }

                generator.CreateGrid();
                generator.CreateMaze();
            }
        }
    }

    public void LoadGame()
    {
        if (string.IsNullOrEmpty(My_Text.Difficult) || My_Text.side == -1)
        {
            maintext.text = "U didn't type date";
            maintext.fontSize = 12;
            maintext.color = Color.red;
            return;
        }
    }

    public void LeaveGame()
    {
        My_Text.side = -1;
    }
}
