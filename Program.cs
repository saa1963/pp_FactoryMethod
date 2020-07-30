using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pp_FactoryMethod
{
    interface Button
    {
        void Click();
    }
    class WindowsButton: Button
    {
        public void Click()
        {
            Console.WriteLine("Click Windows Button");
        }
    }
    class MacButton : Button
    {
        public void Click()
        {
            Console.WriteLine("Click Mac Button");
        }
    }
    abstract class Dialog
    {
        public Dialog()
        {
            button = createButton();
        }
        public Button button { get; set; }
        public abstract Button createButton();
    }
    class WindowsDialog: Dialog
    {
        public override Button createButton()
        {
            return new WindowsButton();
        }
    }
    class MacDialog : Dialog
    {
        public override Button createButton()
        {
            return new MacButton();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int p = 2;
            Dialog dialog;
            switch (p)
            {
                case 1:
                    dialog = new WindowsDialog();
                    break;
                case 2:
                    dialog = new MacDialog();
                    break;
                default:
                    Console.WriteLine("Неверный параметр");
                    return;
            }
            dialog.button.Click();
        }
    }
}