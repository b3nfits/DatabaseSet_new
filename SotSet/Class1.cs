using SotSet.Login;
using SotSet.Reg;
using SotSet.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotSet
{
    internal class Class1
    {
        private static RegPage _regPage;

        private static PanelPage _panelPage;

        public static RegPage RegPage
        {
            get
            {
                if (_regPage == null)
                {
                    _regPage = new RegPage();
                }
                return _regPage;
            }
        }
        public static PanelPage ProfilePage
        {
            get
            {
                if (_panelPage == null)
                {
                    _panelPage = new PanelPage();
                }
                return _panelPage;
            }
        }
    }
}
