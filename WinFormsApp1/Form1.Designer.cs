namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            Mouse = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Mouse).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(553, 26);
            label1.Name = "label1";
            label1.Size = new Size(139, 25);
            label1.TabIndex = 0;
            label1.Text = "Попадание:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(553, 67);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 1;
            label2.Text = "Промахи:";
            // 
            // Mouse
            // 
            Mouse.BackColor = Color.Transparent;
            Mouse.Image = Properties.Resources.alive;
            Mouse.Location = new Point(79, 249);
            Mouse.Name = "Mouse";
            Mouse.Size = new Size(132, 144);
            Mouse.SizeMode = PictureBoxSizeMode.StretchImage;
            Mouse.TabIndex = 2;
            Mouse.TabStop = false;
            Mouse.Click += gotMouse;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1400;
            timer1.Tick += moveMouse;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ground;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 626);
            Controls.Add(Mouse);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Бей мышей ";
            ((System.ComponentModel.ISupportInitialize)Mouse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox Mouse;
        private System.Windows.Forms.Timer timer1;
    }
}
