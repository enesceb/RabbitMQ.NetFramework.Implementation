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
using RabbitMQ.Client.Events;

namespace _RabbitMQ.Net_.Sample.Project
{
    public partial class Form : System.Windows.Forms.Form
    {
        private IConnection rabbitMqConnection;
        private IModel emailChannel;
        private IModel smsChannel;

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

        private void btnPublishEmail_Click(object sender, EventArgs e)
        { 
            using (var channel = rabbitMqConnection.CreateModel())
            {
                var message = txtPublishEmail.Text;
                var props = channel.CreateBasicProperties();
                props.DeliveryMode = 2;
                channel.BasicPublish("CustomerNotification", "email", props, Encoding.UTF8.GetBytes(message));
            }
        }

        private void btnPublishSms_Click(object sender, EventArgs e)
        {
            using (var channel = rabbitMqConnection.CreateModel())
            {
                var message = txtPublishSms.Text;
                var props = channel.CreateBasicProperties();
                props.DeliveryMode = 2;
                channel.BasicPublish("CustomerNotification", "sms", props, Encoding.UTF8.GetBytes(message));
            }
        }

        private void btnSubscribeEmailQueue_Click(object sender, EventArgs e)
        {
            emailChannel = rabbitMqConnection.CreateModel();
            emailChannel.BasicQos(0,1,false);
            var emailChannelConsumer = new AsyncEventingBasicConsumer(emailChannel);
            emailChannelConsumer.Received += EmailChannelConsumer_Received;
            emailChannel.BasicConsume("Email", false, emailChannelConsumer);
        }

        private async Task EmailChannelConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            lstEmailMessages.Invoke((MethodInvoker)(() => lstEmailMessages.Items.Add(message)));
            emailChannel.BasicAck(e.DeliveryTag, false);
        }

        private void btnSubscribeSmsQueue_Click(object sender, EventArgs e)
        {
            smsChannel = rabbitMqConnection.CreateModel();
            smsChannel.BasicQos(0, 1, false);
            var SmsChannelConsumer = new AsyncEventingBasicConsumer(smsChannel);
            SmsChannelConsumer.Received += SmsChannelConsumer_Received;
            smsChannel.BasicConsume("Sms", false, SmsChannelConsumer);
        }

        private async Task SmsChannelConsumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            lstSmsMessages.Invoke((MethodInvoker)(() => lstSmsMessages.Items.Add(message)));
            smsChannel.BasicAck(e.DeliveryTag, false);
        }
    }
}
