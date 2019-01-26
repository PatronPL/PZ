namespace Czołgi_v0_5
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tank1timer = new System.Windows.Forms.Timer(this.components);
            this.bulletTimer = new System.Windows.Forms.Timer(this.components);
            this.tank2timer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.socketButton = new System.Windows.Forms.Button();
            this.buttonHost = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.timerHost = new System.Windows.Forms.Timer(this.components);
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tank1timer
            // 
            this.tank1timer.Enabled = true;
            this.tank1timer.Interval = 16;
            this.tank1timer.Tick += new System.EventHandler(this.tank1timer_Tick);
            // 
            // bulletTimer
            // 
            this.bulletTimer.Enabled = true;
            this.bulletTimer.Interval = 16;
            this.bulletTimer.Tick += new System.EventHandler(this.bulletstimer_Tick);
            // 
            // tank2timer
            // 
            this.tank2timer.Enabled = true;
            this.tank2timer.Interval = 16;
            this.tank2timer.Tick += new System.EventHandler(this.tank2timer_Tick);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.startButton.Location = new System.Drawing.Point(291, 21);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 100);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start Local";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.loadButton.Location = new System.Drawing.Point(447, 21);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(150, 50);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // socketButton
            // 
            this.socketButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.socketButton.Location = new System.Drawing.Point(447, 77);
            this.socketButton.Name = "socketButton";
            this.socketButton.Size = new System.Drawing.Size(112, 74);
            this.socketButton.TabIndex = 2;
            this.socketButton.Text = "Start Online";
            this.socketButton.UseVisualStyleBackColor = false;
            this.socketButton.Click += new System.EventHandler(this.socketButton_Click);
            // 
            // buttonHost
            // 
            this.buttonHost.Enabled = false;
            this.buttonHost.Location = new System.Drawing.Point(208, 241);
            this.buttonHost.Name = "buttonHost";
            this.buttonHost.Size = new System.Drawing.Size(90, 30);
            this.buttonHost.TabIndex = 3;
            this.buttonHost.Text = "buttonHost";
            this.buttonHost.UseVisualStyleBackColor = true;
            this.buttonHost.Visible = false;
            this.buttonHost.Click += new System.EventHandler(this.buttonHost_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.Enabled = false;
            this.buttonClient.Location = new System.Drawing.Point(304, 241);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(90, 30);
            this.buttonClient.TabIndex = 4;
            this.buttonClient.Text = "buttonClient";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Visible = false;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // timerHost
            // 
            this.timerHost.Interval = 8;
            this.timerHost.Tag = "Host";
            this.timerHost.Tick += new System.EventHandler(this.timerHost_Tick);
            // 
            // timerSend
            // 
            this.timerSend.Interval = 8;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.exit.Location = new System.Drawing.Point(199, 21);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 5;
            this.exit.Text = "button1";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 531);
            this.ControlBox = false;
            this.Controls.Add(this.exit);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonHost);
            this.Controls.Add(this.socketButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(625, 547);
            this.Name = "Form1";
            this.Text = "Czołgi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer bulletTimer;
        public System.Windows.Forms.Timer tank1timer;
        public System.Windows.Forms.Timer tank2timer;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button socketButton;
        private System.Windows.Forms.Timer timerHost;
        private System.Windows.Forms.Timer timerSend;
        public System.Windows.Forms.Button startButton;
        public System.Windows.Forms.Button buttonHost;
        public System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button exit;
    }
}

