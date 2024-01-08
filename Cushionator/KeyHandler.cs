using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cushionator
{
    public class KeyHandler
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public int key;
        private IntPtr hWnd;
        private int id;

        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (int)key/*key ^ hWnd.ToInt32()*/;
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, 0, key);
        }

        public bool Unregister()
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
    //Reference: https://stackoverflow.com/questions/18291448/how-do-i-detect-keypress-while-not-focused
}
