using Gma.UserActivityMonitor;
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

        Socket? socket = null;

        public RetroRemoteForm()
        {
            InitializeComponent();

            //HookManager.MouseDown += MouseDownHandler;
            //HookManager.MouseMoveExt += MouseMoveExHandler;
            HookManager.MouseUp += MouseUpHandler;
            HookManager.KeyDown += KeyDownHandler;
            HookManager.KeyUp += KeyUpHandler;
            //HookManager.MouseClickExt += MouseClickExtHandler;
            //HookManager.MouseWheel += MouseWheelHandler;

            MonitorSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize;

            TransparentOverlay = new TransparentOverlay();


        }

        private void MouseWheelHandler(object? sender, MouseEventArgs e)
        {
            if (!capturing) return;

            Println($"MW;b:{e.Delta}");
        }

        private void MouseClickExtHandler(object? sender, MouseEventExtArgs e)
        {
            if (!capturing) return;

            //Println($"MC;b:{e.Button};");
            e.Handled = true;
        }

        private void MouseUpHandler(object? sender, MouseEventArgs e)
        {
            if (!capturing) return;

            Println($"MU;b:{e.Button};");
        }

        private void MouseMoveExHandler(object? sender, MouseEventExtArgs e)
        {
            if (!capturing) return;

            Println($"MM;x:{e.X};y:{e.Y};w:{MonitorSize.Width};h:{MonitorSize.Height};");
        }

        private void MouseDownHandler(object? sender, MouseEventArgs e)
        {
            if (!capturing) return;

            Println($"MD;b:{e.Button};");
        }

        private void KeyUpHandler(object? sender, KeyEventArgs e)
        {
            if (!capturing) return;


            Println($"KU;c:{e.KeyCode};v:{e.KeyValue};");

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

        private void KeyDownHandler(object? sender, KeyEventArgs e)
        {
            if (!capturing) return;

            Println($"KD;c:{e.KeyCode};v:{e.KeyValue};");
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

        private void btCapture_Click(object sender, EventArgs e)
        {
            InitializeCapture();
        }

        private void InitializeCapture()
        {
            //Println("Initializing capture...");

            //IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
            //IPAddress ipAddress = host.AddressList[0];
            //IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 9999);

            //Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //listener.Bind(localEndPoint);
            //listener.Listen(10);
            //socket = listener.Accept();


            btCapture.Enabled = false;
            btCapture.Text = "Capturing";

            capturing = true;

            Cursor.Hide();

            toolStripStatus.Text = "Press Ctrl+Alt+F10 to stop...";

            /*
            TransparentOverlay.Show();
            TransparentOverlay.Size = MonitorSize;
            TransparentOverlay.Location = new Point(0, 0);
            */

        }


        private void StopCapture()
        {
            Println("Capture cancelled.");

            btCapture.Text = "Capture Inputs...";
            btCapture.Enabled = true;
            toolStripStatus.Text = "Ready.";

            capturing = false;

            Cursor.Show();

            /*
            TransparentOverlay.Hide();
            */

        }


        private void Println(String message)
        {
            string text = "{" + message + "}" + Environment.NewLine;
            //if (socket != null)
            //{
            //    socket.Send(Encoding.ASCII.GetBytes(text));
            //}

            txtConsole.AppendText(text);
        }

        private void btCancelCapture_Click(object sender, EventArgs e)
        {
            StopCapture();
        }
    }
}
