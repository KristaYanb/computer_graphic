namespace LABA3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Radius = new System.Windows.Forms.TextBox();
            this.number = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Fi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.Standart = new System.Windows.Forms.Button();
            this.munisT = new System.Windows.Forms.Button();
            this.plusT = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Teta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Radius
            // 
            this.Radius.Location = new System.Drawing.Point(51, 20);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(51, 22);
            this.Radius.TabIndex = 0;
            this.Radius.TextChanged += new System.EventHandler(this.Radius_TextChanged);
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(175, 23);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(51, 22);
            this.number.TabIndex = 1;
            this.number.TextChanged += new System.EventHandler(this.number_TextChanged);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(105, 119);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(57, 26);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "r =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "n =";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(111, 60);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(51, 22);
            this.height.TabIndex = 5;
            this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "h =";
            // 
            // Fi
            // 
            this.Fi.Location = new System.Drawing.Point(63, 157);
            this.Fi.Name = "Fi";
            this.Fi.Size = new System.Drawing.Size(51, 22);
            this.Fi.TabIndex = 7;
            this.Fi.TextChanged += new System.EventHandler(this.Fi_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "φ =";
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(92, 186);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(21, 23);
            this.plus.TabIndex = 9;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(63, 186);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(21, 23);
            this.minus.TabIndex = 10;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // Standart
            // 
            this.Standart.Location = new System.Drawing.Point(77, 88);
            this.Standart.Name = "Standart";
            this.Standart.Size = new System.Drawing.Size(110, 25);
            this.Standart.TabIndex = 11;
            this.Standart.Text = "Стандартные";
            this.Standart.UseVisualStyleBackColor = true;
            this.Standart.Click += new System.EventHandler(this.Standart_Click);
            // 
            // munisT
            // 
            this.munisT.Location = new System.Drawing.Point(175, 186);
            this.munisT.Name = "munisT";
            this.munisT.Size = new System.Drawing.Size(21, 23);
            this.munisT.TabIndex = 15;
            this.munisT.Text = "-";
            this.munisT.UseVisualStyleBackColor = true;
            this.munisT.Click += new System.EventHandler(this.munisT_Click);
            // 
            // plusT
            // 
            this.plusT.Location = new System.Drawing.Point(204, 186);
            this.plusT.Name = "plusT";
            this.plusT.Size = new System.Drawing.Size(21, 23);
            this.plusT.TabIndex = 14;
            this.plusT.Text = "+";
            this.plusT.UseVisualStyleBackColor = true;
            this.plusT.Click += new System.EventHandler(this.plusT_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "teta =";
            // 
            // Teta
            // 
            this.Teta.Location = new System.Drawing.Point(175, 157);
            this.Teta.Name = "Teta";
            this.Teta.Size = new System.Drawing.Size(51, 22);
            this.Teta.TabIndex = 12;
            this.Teta.TextChanged += new System.EventHandler(this.Teta_TextChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 439);
            this.Controls.Add(this.munisT);
            this.Controls.Add(this.plusT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Teta);
            this.Controls.Add(this.Standart);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Fi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.height);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.number);
            this.Controls.Add(this.Radius);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Л/р №3 (параллельная)";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox Radius;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Fi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button Standart;
        private System.Windows.Forms.Button munisT;
        private System.Windows.Forms.Button plusT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Teta;
    }
}

