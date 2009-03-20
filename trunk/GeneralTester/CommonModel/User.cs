using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.CommonModel
{
    [SerializableAttribute]
    public class User
    {
        public User() { }
        public User(string strName, string strPass)
        {
            Username = strName;
            Password = strPass;
        }

        private string m_strUsername;
        private string m_strPassword;

        public string Username
        {
            get { return m_strUsername; }
            set { m_strUsername = value; }
        }

        public string Password
        {
            get { return m_strPassword; }
            set { m_strPassword = value; }
        }
    }
}
