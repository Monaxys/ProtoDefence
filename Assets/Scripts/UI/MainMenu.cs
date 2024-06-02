using UnityEngine;
using Defence.UI;

///<summary>
/// Contains all panels in main menu and their behaviour
///</summary>
public class MainMenu : UIPanel
{
    [Header("Panels")]
    [SerializeField]
    private UIPanel _mainPanel;
    [SerializeField]
    private UIPanel _homePanel;
    [SerializeField]
    private UIPanel _upgradePanel;

    private void Start() {
        HideAll();
        _mainPanel.Show();
    }

    private void HideAll() {
        _mainPanel.Hide();
        _homePanel.Hide();
        _upgradePanel.Hide();
    }
}
