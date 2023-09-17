namespace Lab3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            gameBall = new PictureBox();
            points = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            speed = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gameBall).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(37, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(15, 81);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Black;
            pictureBox2.Location = new Point(830, 125);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(15, 81);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // gameBall
            // 
            gameBall.Image = (Image)resources.GetObject("gameBall.Image");
            gameBall.Location = new Point(315, 144);
            gameBall.Name = "gameBall";
            gameBall.Size = new Size(28, 28);
            gameBall.SizeMode = PictureBoxSizeMode.Zoom;
            gameBall.TabIndex = 2;
            gameBall.TabStop = false;
            // 
            // points
            // 
            points.AutoSize = true;
            points.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            points.Location = new Point(419, -7);
            points.Name = "points";
            points.Size = new Size(57, 38);
            points.TabIndex = 3;
            points.Text = "0:0";
            // 
            // timer1
            // 
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // speed
            // 
            speed.AutoSize = true;
            speed.Location = new Point(404, 381);
            speed.Name = "speed";
            speed.Size = new Size(0, 20);
            speed.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 410);
            Controls.Add(speed);
            Controls.Add(points);
            Controls.Add(gameBall);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gameBall).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox gameBall;
        private Label points;
        private System.Windows.Forms.Timer timer1;
        private Label speed;
    }
}