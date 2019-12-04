using System;
using System.Collections.Generic;
using UnityEngine;

namespace PureMVC
{
    [Serializable]
    class ExcelProxy : MonoBehaviour, IProxy
    {
        public List<PropItem> m_props = new List<PropItem>();

        public string ProxyName
        {
            get
            {
                return m_proxyName;
            }
        }

        public object Data { get { return m_data; } set { m_data = value; } }

        public void OnRegister()
        {
            
        }

        public void OnRemove()
        {
            
        }

        #region Members

        /// <summary>
        /// The name of the proxy
        /// </summary>
        protected string m_proxyName;

        /// <summary>
        /// The data object to be managed
        /// </summary>
        protected object m_data;

        #endregion
    }

    public enum E_excelType
    {
        Prop,
        Skill,
        Character,
    }

    [Serializable]
    public class PropItem
    {
        public int m_id;
        public int m_type;
        public int m_time;
        public int m_propDurability;
        public float m_limits;
        public bool m_superpose;
    }
}
