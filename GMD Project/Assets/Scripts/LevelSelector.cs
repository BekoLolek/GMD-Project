using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public LevelDataSO[] levels;
    public Image levelImage;
    public TMP_Text levelNameText;
    public TMP_Text levelBPMText;
    public int currentIndex = 0;

    void Start()
    {
        ShowLevel(currentIndex);
    }

    public void NextLevel()
    {
        currentIndex = (currentIndex + 1) % levels.Length;
        ShowLevel(currentIndex);
    }

    public void PreviousLevel()
    {
        currentIndex = (currentIndex - 1 + levels.Length) % levels.Length;
        ShowLevel(currentIndex);
    }

    public void PlaySelectedLevel()
    {
        LevelManager.Instance.SetSelectedLevel(levels[currentIndex]);
    }

    void ShowLevel(int index)
    {
        levelNameText.text = levels[index].levelName;
        levelImage.sprite = levels[index].levelPreview;
        levelBPMText.text = levels[index].bpm.ToString() + "BPM";
    }
}
