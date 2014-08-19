namespace EV3Controller
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnFoward = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.BtnRight = new System.Windows.Forms.Button();
            this.BtnBackward = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnFoward
            // 
            this.BtnFoward.Location = new System.Drawing.Point(270, 15);
            this.BtnFoward.Name = "BtnFoward";
            this.BtnFoward.Size = new System.Drawing.Size(25, 23);
            this.BtnFoward.TabIndex = 0;
            this.BtnFoward.Text = "^";
            this.BtnFoward.UseVisualStyleBackColor = true;
            this.BtnFoward.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnLeft
            // 
            this.BtnLeft.Location = new System.Drawing.Point(246, 44);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(25, 23);
            this.BtnLeft.TabIndex = 1;
            this.BtnLeft.Text = "<";
            this.BtnLeft.UseVisualStyleBackColor = true;
            this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // BtnRight
            // 
            this.BtnRight.Location = new System.Drawing.Point(291, 44);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(25, 23);
            this.BtnRight.TabIndex = 2;
            this.BtnRight.Text = ">";
            this.BtnRight.UseVisualStyleBackColor = true;
            this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // BtnBackward
            // 
            this.BtnBackward.Location = new System.Drawing.Point(270, 73);
            this.BtnBackward.Name = "BtnBackward";
            this.BtnBackward.Size = new System.Drawing.Size(25, 23);
            this.BtnBackward.TabIndex = 3;
            this.BtnBackward.Text = "V";
            this.BtnBackward.UseVisualStyleBackColor = true;
            this.BtnBackward.Click += new System.EventHandler(this.BtnBackward_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 226);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(319, 24);
            this.progressBar1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Niveaux de lumière :";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(10, 181);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(319, 24);
            this.progressBar2.TabIndex = 6;
            this.progressBar2.Value = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Distance avant collision :";
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(10, 138);
            this.progressBar3.Maximum = 3366;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(319, 24);
            this.progressBar3.TabIndex = 8;
            this.progressBar3.Value = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Collision :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Distance effectué :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Magenta;
            this.label5.Location = new System.Drawing.Point(115, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vitesse Moteur :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Magenta;
            this.label7.Location = new System.Drawing.Point(101, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "100";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "^";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(165, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "v";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 20);
            this.button3.TabIndex = 16;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(246, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Coded by Davic";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 270);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnBackward);
            this.Controls.Add(this.BtnRight);
            this.Controls.Add(this.BtnLeft);
            this.Controls.Add(this.BtnFoward);
            this.Name = "Form1";
            this.Text = "EV3 Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnFoward;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnBackward;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;

    }
}

