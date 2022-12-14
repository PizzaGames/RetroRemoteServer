using Gma.HookManager;
using Microsoft.VisualBasic.Devices;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace RetroRemoteServer
{
    public partial class RetroRemoteForm : Form
    {
        private bool controlPressed;
        private bool altPressed;
        private bool f10Pressed;

        private bool capturing = false;
        private Size MonitorSize;
        private TransparentOverlay TransparentOverlay;
        private Point lastCursorPos = new Point();

        private ServerSocket? server = null;

        private bool ServerStarted = false;

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern long GetCursorPos(ref Point pos);

        public RetroRemoteForm()
        {
            InitializeComponent();

            HookManager.MouseDown += MouseDownHandler;
            HookManager.MouseMoveExt += MouseMoveExHandler;
            HookManager.MouseUp += MouseUpHandler;
            HookManager.KeyDown += KeyDownHandler;
            HookManager.KeyUp += KeyUpHandler;
            HookManager.MouseClickExt += MouseClickExtHandler;
            HookManager.MouseWheel += MouseWheelHandler;

            MonitorSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;

            TransparentOverlay = new TransparentOverlay();


        }

        private void KeyDownHandler(object? sender, KeyEventArgs e)
        {
            if (!capturing) return;

            SendEventMsg($"a:1,k:{e.KeyValue}");
            if (!controlPressed && e.KeyCode == Keys.LControlKey)
            {
                controlPressed = true;
            }
            if (!altPressed && e.KeyCode == Keys.LMenu)
            {
                altPressed = true;
            }

            f10Pressed = e.KeyCode == Keys.F10;

            if (controlPressed && altPressed && f10Pressed)
            {
                StopCapture();
            }

            e.Handled = true;

        }
        private void KeyUpHandler(object? sender, KeyEventArgs e)
        {
            if (!capturing) return;


            SendEventMsg($"a:2,k:{e.KeyValue}");

            if (controlPressed && e.KeyCode == Keys.LControlKey)
            {
                controlPressed = false;
            }
            if (altPressed && e.KeyCode == Keys.LMenu)
            {
                altPressed = false;
            }

            e.Handled = true;

        }
        private void MouseClickExtHandler(object? sender, MouseEventExtArgs e)
        {
            if (!capturing) return;
            //SendEventMsg($"a:7,b:{GetButton(e)};");
            e.Handled = true;
        }


        private void MouseMoveExHandler(object? sender, MouseEventExtArgs e)
        {
            if (!capturing) return;

            SendEventMsg($"a:3,x:{e.X},y:{e.Y}");

            SetCursorPos(0, 0);

            e.Handled = true;
        }

        
        private void MouseDownHandler(object? sender, MouseEventArgs e)
        {
            if (!capturing) return;

            SendEventMsg($"a:4,b:{GetButton(e)}");
        }
        

        private static int GetButton(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left: return 1;
                case MouseButtons.Right: return 2;
                case MouseButtons.Middle: return 3;
                default: return -1;
            }
        }

        
        private void MouseUpHandler(object? sender, MouseEventArgs e)
        {
            if (!capturing) return;

            SendEventMsg($"a:5,b:{GetButton(e)}");
        }
        

        private void MouseWheelHandler(object? sender, MouseEventArgs e)
        {
            if (!capturing) return;
            SendEventMsg($"a:6,d:{e.Delta}");
        }


        private void btCapture_Click(object sender, EventArgs e)
        {
            InitializeCapture();
        }

        private void btCancelCapture_Click(object sender, EventArgs e)
        {
            StopCapture();
        }
        private void SendEventMsg(String message)
        {
            string retroEvent = "{" + message + "}";
            AppendConsoleText(retroEvent);

            if (server == null) return;
            server.SendMessage(retroEvent);
        }
        private void InitializeCapture()
        {
            AppendConsoleText("Initializing capture...");
            AppendConsoleText("To  cancel capture, press Ctrl+Alt+F10");
            btCapture.Enabled = false;
            btCapture.Text = "Capturing";

            capturing = true;

            toolStripStatus.Text = "Press Ctrl+Alt+F10 to stop...";

            /*
            TransparentOverlay.Show();
            TransparentOverlay.Size = MonitorSize;
            TransparentOverlay.Location = new Point(0, 0);
            */

            GetCursorPos(ref lastCursorPos);
        }
        private void StopCapture()
        {
            AppendConsoleText("Capture cancelled.");

            btCapture.Text = "Capture Inputs...";
            btCapture.Enabled = true;
            toolStripStatus.Text = "Ready.";

            capturing = false;

            /*
            TransparentOverlay.Hide();
            */

            SetCursorPos(lastCursorPos.X, lastCursorPos.Y);
        }
        private void AppendConsoleText(String text) {
            txtConsole.AppendText($"{text}{Environment.NewLine}");

        }

        private void btStartServer_Click(object sender, EventArgs e)
        {
            SwitchServer();
        }

        

        private void SwitchServer()
        {
            if (!ServerStarted)
            {
                StartServer();
            } else
            {
                StopServer();
            }
            
        }

        private void StartServer()
        {
            AppendConsoleText("Initializing server.");
            AppendConsoleText("Waiting for connection.");

            server = new ServerSocket(txtIP.Text, Int32.Parse(txtPort.Text));
            server.Accept();
            

            btCapture.Enabled = true;

            AppendConsoleText("To start input capture, click on capture inputs button.");
            btStartServer.Text = "Stop server";

            ServerStarted = true;
        }

        private void StopServer()
        {
            AppendConsoleText("Stopping server.");

            if (capturing)
            {
                GetCursorPos(ref lastCursorPos);
                StopCapture();
            }

            btCapture.Enabled = false;
            btStartServer.Text = "Start server";

            ServerStarted = false;

            if (server == null) return;
            server.Close();

        }
    }
}
