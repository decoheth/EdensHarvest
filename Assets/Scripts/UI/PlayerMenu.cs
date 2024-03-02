using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject combatHud;

    // References
    MouseLook mouseLook;
    UIManager uIManager;
    BuildingManager buildingManager;

    void Awake()
    {
        mouseLook = GameObject.FindWithTag("Player").GetComponentInChildren<MouseLook>();
        uIManager = GetComponent<UIManager>();
        buildingManager = GameObject.Find("/Managers/Building Manager").GetComponent<BuildingManager>();

        playerMenu.SetActive(false);
    }

    void Update()
    {
        // Check if Tab press
        if(Input.GetKeyDown(KeyCode.Tab) && !pauseMenu.activeInHierarchy && combatHud.activeInHierarchy)
        {
            TogglePlayerMenu(!playerMenu.activeInHierarchy);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && playerMenu.activeInHierarchy)
        {
            TogglePlayerMenu(false);  
        }

        // If menu active, update values
    }

    public void TogglePlayerMenu(bool active)
    {
        playerMenu.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
        mouseLook.cursorHidden = !active;


    }
}
