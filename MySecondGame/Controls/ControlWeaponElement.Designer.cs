
namespace MySecondGame.Controls
{
    partial class ControlWeaponElement
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 152);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.panel1.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(185, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.panel2.Size = new System.Drawing.Size(130, 150);
            this.panel2.TabIndex = 9;
            this.panel2.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.panel2.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel3.Size = new System.Drawing.Size(185, 150);
            this.panel3.TabIndex = 8;
            this.panel3.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.panel3.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Урон:";
            this.label4.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.label4.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Уровень:";
            this.label3.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.label3.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Тип оружия:";
            this.label2.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.label2.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Имя:";
            this.label1.Click += new System.EventHandler(this.ControlWeaponElement_Click);
            this.label1.DoubleClick += new System.EventHandler(this.ControlWeaponElement_DoubleClick);
            // 
            // ControlWeaponElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ControlWeaponElement";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Size = new System.Drawing.Size(325, 160);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
