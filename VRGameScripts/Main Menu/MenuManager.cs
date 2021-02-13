using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool gripValue;
    private InputDevice device;

    public Panel currPanel = null;

    private List<Panel> panelHistory = new List<Panel>();

    private void Start()
    {
        SetupPanels();
    }

    private void SetupPanels()
    {
        Panel[] panels = GetComponentsInChildren<Panel>();

        foreach (Panel panel in panels)
        {
            panel.Setup(this);
        }

        currPanel.Show();
    }

    private void Update()
    {
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out gripValue) && gripValue)
        {
            GoToPrevious();
        }
    }

    public void GoToPrevious()
    {
        if (panelHistory.Count == 0)
        {
            return;
        }

        int lastIndex = panelHistory.Count - 1;
        SetCurr(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrWithHist(Panel newPanel)
    {
        panelHistory.Add(currPanel);
        SetCurr(newPanel);
    }

    public void SetCurr(Panel newPanel)
    {
        currPanel.Hide();
        currPanel = newPanel;
        currPanel.Show();
    }

    public void GoToDuckHunt()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToArchery()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
