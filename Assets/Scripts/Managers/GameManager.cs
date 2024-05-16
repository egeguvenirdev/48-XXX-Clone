using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    [Header("PlayerPrefs")]
    [SerializeField] private bool clearPlayerPrefs;

    private UpdateManager updateManager;
    private CamManager camManager;
    private UIManager uIManager;
    private ObjectPooler pooler;
    private AudioManager audioManager;

    void Start()
    {
        if (clearPlayerPrefs) PlayerPrefs.DeleteAll();

        uIManager = UIManager.Instance;
        pooler = ObjectPooler.Instance;
        updateManager = FindObjectOfType<UpdateManager>();
        camManager = FindObjectOfType<CamManager>();
        audioManager = FindObjectOfType<AudioManager>();

        SetInits();
    }

    private void SetInits()
    {
        uIManager.Init();
        updateManager.Init();
        audioManager.Init();
        camManager.Init();
    }

    private void DeInits()
    {
        uIManager.DeInit();
        updateManager.DeInit();
        camManager.DeInit();
        pooler.DeInit();
        audioManager.DeInit();
    }

    public void OnStartTheGame()
    {
        ActionManager.GameStart?.Invoke();
    }

    public void OnLevelSucceed()
    {
        DeInits();
        SetInits();
    }

    public void OnLevelFailed()
    {
        DeInits();
        SetInits();
    }

    public void FinishTheGame(bool check)
    {
        ActionManager.GameEnd?.Invoke(check);
    }
}
