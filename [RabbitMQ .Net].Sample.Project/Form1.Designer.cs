namespace _RabbitMQ.Net_.Sample.Project
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnectRabbitmq = new System.Windows.Forms.Button();
            this.btnCreateExchange = new System.Windows.Forms.Button();
            this.btnCreateQueues = new System.Windows.Forms.Button();
            this.btnBindQueues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnectRabbitmq
            // 
            this.btnConnectRabbitmq.Location = new System.Drawing.Point(12, 12);
            this.btnConnectRabbitmq.Name = "btnConnectRabbitmq";
            this.btnConnectRabbitmq.Size = new System.Drawing.Size(128, 35);
            this.btnConnectRabbitmq.TabIndex = 0;
            this.btnConnectRabbitmq.Text = "Connect RabbitMQ";
            this.btnConnectRabbitmq.UseVisualStyleBackColor = true;
            this.btnConnectRabbitmq.Click += new System.EventHandler(this.btnConnectRabbitmq_Click);
            // 
            // btnCreateExchange
            // 
            this.btnCreateExchange.Location = new System.Drawing.Point(12, 53);
            this.btnCreateExchange.Name = "btnCreateExchange";
            this.btnCreateExchange.Size = new System.Drawing.Size(128, 35);
            this.btnCreateExchange.TabIndex = 1;
            this.btnCreateExchange.Text = "Create Exchange\r\n";
            this.btnCreateExchange.UseVisualStyleBackColor = true;
            this.btnCreateExchange.Click += new System.EventHandler(this.btnCreateExchange_Click);
            // 
            // btnCreateQueues
            // 
            this.btnCreateQueues.Location = new System.Drawing.Point(12, 94);
            this.btnCreateQueues.Name = "btnCreateQueues";
            this.btnCreateQueues.Size = new System.Drawing.Size(128, 35);
            this.btnCreateQueues.TabIndex = 2;
            this.btnCreateQueues.Text = "Create Queues";
            this.btnCreateQueues.UseVisualStyleBackColor = true;
            this.btnCreateQueues.Click += new System.EventHandler(this.btnCreateQueues_Click);
            // 
            // btnBindQueues
            // 
            this.btnBindQueues.Location = new System.Drawing.Point(12, 135);
            this.btnBindQueues.Name = "btnBindQueues";
            this.btnBindQueues.Size = new System.Drawing.Size(128, 35);
            this.btnBindQueues.TabIndex = 3;
            this.btnBindQueues.Text = "Bind Queues";
            this.btnBindQueues.UseVisualStyleBackColor = true;
            this.btnBindQueues.Click += new System.EventHandler(this.btnBindQueues_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBindQueues);
            this.Controls.Add(this.btnCreateQueues);
            this.Controls.Add(this.btnCreateExchange);
            this.Controls.Add(this.btnConnectRabbitmq);
            this.Name = "Form";
            this.Text = " [RabbitMQ .Net] C#";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectRabbitmq;
        private System.Windows.Forms.Button btnCreateExchange;
        private System.Windows.Forms.Button btnCreateQueues;
        private System.Windows.Forms.Button btnBindQueues;
    }
}

