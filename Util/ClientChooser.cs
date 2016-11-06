using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tibia.Objects;

namespace Tibia.Util
{
    public partial class ClientChooser : Form
    {
        private static ClientChooser newClientChooser;
        private static Client client;

        private ClientChooserOptions options;

        public ClientChooser()
        {
            InitializeComponent();
            client = null;
        }

        /// <summary>
        /// Opens a box to pick a client.
        /// </summary>
        /// <returns></returns>
        public static Client ShowBox()
        {
            return ShowBox(new ClientChooserOptions());
        }

        /// <summary>
        /// Open a box to pick a client with the desired options.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Client ShowBox(ClientChooserOptions options)
        {
            List<Client> clients = Client.GetClients(options.Version, options.OfflineOnly);

            if (clients != null &&
                clients.Count == 1)
            {
                return clients[0];
            }
            else
            {
                newClientChooser = new ClientChooser();
                newClientChooser.Text = String.IsNullOrEmpty(options.Title) ? "Choose a client." : options.Title;

                foreach (Client c in clients)
                {
                    newClientChooser.uxClients.Items.Add(c);
                }

                newClientChooser.uxClients.SelectedIndex = 0;

                newClientChooser.options = options;
                newClientChooser.TopMost = options.Topmost;
                newClientChooser.ShowDialog();
                return client;
            }
        }

        private void uxChoose_Click(object sender, EventArgs e)
        {
            ChooseClient();
        }

        private void ChooseClient()
        {
            client = (Client)uxClients.SelectedItem;

            if (client != null)
                Version.Set(client.Version, client.Process);

            newClientChooser.Dispose();
        }

        private void CommonKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChooseClient();
            }
        }
    }
}
