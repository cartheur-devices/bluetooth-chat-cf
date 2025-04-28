using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net;
using System.Windows.Forms;

namespace BluetoothChatPPC
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
        }

        //internal System.Windows.Forms.MainMenu MainMenu1;

        const int MAX_MESSAGE_SIZE = 128;
        const int MAX_TRIES = 3;

        private Guid ServiceName = new Guid("{E075D486-E23D-4887-8AF5-DAA1F6A5B172}");

        BluetoothClient btClient = new BluetoothClient();
        BluetoothListener btListener;

        private bool listening = true;

        //holds the incoming message
        string str;

        private void sendMessage(int NumRetries, byte[] Buffer, int BufferLen)
        {

            Stream stream = null;
            BluetoothClient client = null;
            int CurrentTries = 0;
            do
            {
                try
                {
                    client = new BluetoothClient();
                    client.Connect(new BluetoothEndPoint(((BluetoothDeviceInfo)cboDevices.SelectedItem).DeviceAddress, ServiceName));
                }
                catch (SocketException se)
                {
                    if ((CurrentTries >= NumRetries))
                    {
                        throw se;
                    }
                    client = null;
                }
                CurrentTries = CurrentTries + 1;
            }

            while (client == null & CurrentTries < NumRetries);

            if ((client == null))
            {
                //timeout occurred
                MessageBox.Show("Error establishing contact.");
                return;
            }
            try
            {
                stream = client.GetStream();
                stream.Write(Buffer, 0, BufferLen);
            }
            catch (Exception)
            {
                MessageBox.Show("Error sending.");
            }
            finally
            {
                if (((stream != null)))
                {
                    stream.Close();
                }
                if (((client != null)))
                {
                    client.Close();
                }
            }
        }

        private string receiveMessage(int BufferLen)
        {
            int bytesRead = 0;
            BluetoothClient client = null;
            System.IO.Stream stream = null;
            string Constants_vbCrLf = " ";
            byte[] Buffer = new byte[MAX_MESSAGE_SIZE + 1];

            try
            {
                client = btListener.AcceptBluetoothClient();
                // blocking call
                stream = client.GetStream();
                bytesRead = stream.Read(Buffer, 0, BufferLen);

                str = client.RemoteMachineName + " --> " + System.Text.Encoding.Unicode.GetString(Buffer, 0, bytesRead) + Constants_vbCrLf;
            }
            catch (Exception)
            {
                //dont display error if we are ending the listener
                if (listening)
                {
                    MessageBox.Show("Error listening to incoming message.");
                }
            }
            finally
            {
                if (((stream != null)))
                {
                    stream.Close();
                }
                if (((client != null)))
                {
                    client.Close();
                }
            }
            return str;
        }

        private void ChatForm_Load(object sender, System.EventArgs e)
        {
            //Dim s As New InTheHand.Windows.Forms.SelectBluetoothDeviceDialog()
            //s.ForceAuthentication = True
            //s.ShowAuthenticated = True
            //s.ShowRemembered = True
            //s.ShowUnknown = True
            //s.ShowDialog()

            System.Threading.Thread t1;
            t1 = new System.Threading.Thread(receiveLoop);
            t1.Start();

            btClient = new BluetoothClient();

            BluetoothDeviceInfo[] bdi = btClient.DiscoverDevices();

            cboDevices.DataSource = bdi;
            cboDevices.DisplayMember = "DeviceName";
            
        }

        public void receiveLoop()
        {
            string strReceived;
            btListener = new BluetoothListener(ServiceName);
            btListener.Start();

            strReceived = receiveMessage(MAX_MESSAGE_SIZE);
            while (listening)
            {
                //---keep on listening for new message
                if (strReceived != "")
                {
                    this.Invoke(new EventHandler(UpdateTextBox));

                    strReceived = receiveMessage(MAX_MESSAGE_SIZE);
                }
            }
        }

        private void UpdateTextBox(object sender, EventArgs e)
        {
            //---delegate to update the textbox control
            txtMessagesArchive.Text += str;
        }

        private void ChatForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //stop receive loop
            listening = false;
            //stop listening service
            btListener.Stop();
            Application.Exit();
        }

        private void mnuSend_Click(object sender, System.EventArgs e)
        {
            sendMessage(MAX_TRIES, System.Text.Encoding.Unicode.GetBytes(txtMessage.Text), txtMessage.Text.Length * 2);
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            //stop receive loop
            listening = false;
            //stop listening service
            btListener.Stop();
            this.Close();
            Application.Exit();
        }

        private void mnuSearch_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BluetoothDeviceInfo[] bdi = btClient.DiscoverDevices();
            cboDevices.DataSource = bdi;
            cboDevices.DisplayMember = "DeviceName";
            Cursor.Current = Cursors.Default;
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            mnuSend_Click(sender, e);
        }
    }
}
