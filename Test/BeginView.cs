using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC;
using ResourceLoader;
using TheDispatcher;
using System;
using StateMachine;


public class BeginView : MonoBehaviour, IMediator {
    public string MediatorName
    {
        get
        {
            return m_mediatorName;
        }
    }

    public IBaseView GetViewComponent()
    {
        return m_viewComponent;
    }

    public void SetViewComponent(IBaseView value)
    {
        m_viewComponent = value;
    }

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        AppFacade.getInstance.RegisterMediator(this);

        TheDispatcher.Dispatcher.Instance.AddListener("ajsdfpioj", OnTest);
	}

    void OnTest(IMessage msg)
    {
        Debug.Log("测试监听");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCLickStartGameBtn()
    {
        AppFacade.getInstance.SendNotification(NoticeConst.InitGame);
    }

    public IList<string> ListNotificationInterests()
    {
        List<string> _notices = new List<string>(){
            //NoticeConst.HideButton,
        };

        return _notices;
    }

    public void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            //case NoticeConst.HideButton:
            //    Debug.Log("HideButton");
            //    break;

            default:

                break;
        }
    }

    public void OnRegister()
    {
        Debug.Log("Registed BeginView");
    }

    public void OnRemove()
    {
        
    }

    #region Members

    /// <summary>
    /// The mediator name
    /// </summary>
    protected string m_mediatorName = "BeginView";

    /// <summary>
    /// The view component being mediated
    /// </summary>
    protected IBaseView m_viewComponent;

    #endregion
}


public class GameFSM : FSM
{
    State m_idleState;

    State m_dieState;

    BeginView m_ctr;

    public void InitFsm(BeginView _ctr)
    {
        m_ctr = _ctr;
    }

    new void Start()
    {
        base.Start();

        m_idleState = new State("IdleStaet", BeginIdle, UpdateIdle, EndIdle);

        SwichState(m_idleState);
    }

    void BeginIdle()
    {
        // 设置动画
    }

    void UpdateIdle()
    {
        // 判断进入结束
        if (true)
            SwichState(m_dieState);
    }

    void EndIdle()
    {
        // 清除数据
    }


}
