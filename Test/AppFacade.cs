using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC;
using ResourceLoader;

public class AppFacade : Facade, IFacade
{
    private static AppFacade _instance;
    public static AppFacade getInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new AppFacade();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Intialize Controller
    /// </summary>
    protected override void InitializeController()
    {
        base.InitializeController();


        // Init GameCommand
        RegisterCommand(NoticeConst.InitGame, typeof(InitCommand));
    }
}

public class InitCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        base.Execute(notification);

        Debug.Log("Init Game Command");

        // Init all needed Command 


        // Load Asset bundles
        ResourceManager.Instance.LoadAllAssetBundle(() =>
        {
            Debug.Log("LoadOver");
        });


        // Test load Resource
        GameObject _preb = ResourceManager.Instance.LoadResource<GameObject>("Prefabs/CubePrefab", true);
        GameObject.Instantiate(_preb);

        // Test Mediator
        SendNotification("HideButton");

        TheDispatcher.Dispatcher.Instance.Brocast("ajsdfpioj");

    }
}
