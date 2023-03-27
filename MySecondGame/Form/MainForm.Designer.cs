
namespace MySecondGame
{
    partial class MainForm
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
            this.ControlContener = new System.Windows.Forms.Panel();
            this.ButtonShowControlWeapon = new System.Windows.Forms.Button();
            this.ButtonShowControlCharacter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ControlContener
            // 
            this.ControlContener.Location = new System.Drawing.Point(12, 89);
            this.ControlContener.Name = "ControlContener";
            this.ControlContener.Size = new System.Drawing.Size(776, 505);
            this.ControlContener.TabIndex = 6;
            // 
            // ButtonShowControlWeapon
            // 
            this.ButtonShowControlWeapon.Font = new System.Drawing.Font("Comic Sans MS", 14.25F);
            this.ButtonShowControlWeapon.Location = new System.Drawing.Point(13, 46);
            this.ButtonShowControlWeapon.Name = "ButtonShowControlWeapon";
            this.ButtonShowControlWeapon.Size = new System.Drawing.Size(131, 37);
            this.ButtonShowControlWeapon.TabIndex = 7;
            this.ButtonShowControlWeapon.Text = "Оружие";
            this.ButtonShowControlWeapon.UseVisualStyleBackColor = true;
            this.ButtonShowControlWeapon.Click += new System.EventHandler(this.ButtonShowControlWeapon_Click);
            // 
            // ButtonShowControlCharacter
            // 
            this.ButtonShowControlCharacter.Font = new System.Drawing.Font("Comic Sans MS", 14.25F);
            this.ButtonShowControlCharacter.Location = new System.Drawing.Point(150, 46);
            this.ButtonShowControlCharacter.Name = "ButtonShowControlCharacter";
            this.ButtonShowControlCharacter.Size = new System.Drawing.Size(131, 37);
            this.ButtonShowControlCharacter.TabIndex = 8;
            this.ButtonShowControlCharacter.Text = "Персонажи";
            this.ButtonShowControlCharacter.UseVisualStyleBackColor = true;
            this.ButtonShowControlCharacter.Click += new System.EventHandler(this.ButtonShowControlCharacter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.ButtonShowControlCharacter);
            this.Controls.Add(this.ButtonShowControlWeapon);
            this.Controls.Add(this.ControlContener);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Controls.SetChildIndex(this.ControlContener, 0);
            this.Controls.SetChildIndex(this.ButtonShowControlWeapon, 0);
            this.Controls.SetChildIndex(this.ButtonShowControlCharacter, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlContener;
        private System.Windows.Forms.Button ButtonShowControlWeapon;
        private System.Windows.Forms.Button ButtonShowControlCharacter;
    }
}