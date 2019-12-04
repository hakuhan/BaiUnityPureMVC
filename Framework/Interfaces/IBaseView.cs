#region Using

using System;

#endregion

namespace PureMVC
{
    public interface IBaseView
    {
        E_ViewType ViewName { get; set; }
        IMediator Mediator { get; set; }
        void Initialize();
        void Open();
        void Close();
        void OpenAnimation();
        void CloseAnimation();
        void HandleMsg(INotification _msg);
    }
}


