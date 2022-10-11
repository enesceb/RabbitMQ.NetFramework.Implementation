using RabbitMQ.Client;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _RabbitMQ.Net_.Sample.Project
{
    public partial class Form : System.Windows.Forms.Form
    {
        private IConnection rabbitMqConnection;

        public Form()
        {
            InitializeComponent();
        }

        private void btnConnectRabbitmq_Click(object sender, EventArgs e)
        {
            var connection = ConfigurationManager.ConnectionStrings["RabbitMqConnection"].ConnectionString;
            var connectionFactory  = new ConnectionFactory();
            connectionFactory.Uri = new Uri(connection);
            connectionFactory.AutomaticRecoveryEnabled = true;
            connectionFactory.DispatchConsumersAsync = true;
            rabbitMqConnection = connectionFactory.CreateConnection("DemoAppClient");

        }

        private void btnCreateExchange_Click(object sender, EventArgs e)
        {
            using (var channel = rabbitMqConnection.CreateModel())
            {
                channel.ExchangeDeclare("CustomerNotification", ExchangeType.Direct ,true, false );
            } 
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateQueues_Click(object sender, EventArgs e)
        {
            using (var queue = rabbitMqConnection.CreateModel())
            {
                queue.QueueDeclare("Email", true, false, false);
                queue.QueueDeclare("Sms", true, false, false);

            }
        }

        private void btnBindQueues_Click(object sender, EventArgs e)
        {
            using (var queuebind = rabbitMqConnection.CreateModel())
            {
                queuebind.QueueBind("Email", "CustomerNotification", "email");
                queuebind.QueueBind("Sms", "CustomerNotification", "sms");

            }
        }
    }
}
