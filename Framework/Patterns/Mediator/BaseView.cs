using UnityEngine;
using System.Collections;

namespace PureMVC
{
    public class BaseView : MonoBehaviour, IBaseView
    {
        protected E_ViewType m_viewName;
        protected IMediator m_mediator;

        public E_ViewType ViewName
        {
            get
            {
                return m_viewName;
            }

            set
            {
                m_viewName = value;
            }
        }

        public IMediator Mediator
        {
            get
            {
                return m_mediator;
            }

            set
            {
                m_mediator = value;
            }
        }

        public virtual void Close()
        {

        }

        public virtual void CloseAnimation()
        {

        }

        public virtual void HandleMsg(INotification _msg)
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void Open()
        {

        }

        public virtual void OpenAnimation()
        {

        }
    }

}
