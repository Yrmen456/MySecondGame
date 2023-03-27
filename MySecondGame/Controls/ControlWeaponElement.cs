using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySecondGame.Data;

namespace MySecondGame.Controls
{
    public partial class ControlWeaponElement : UserControl
    {
        public WeaponParameters WeaponParameters;
        ControlWeapon ControlWeapon;
        Color Color;
        public int ControlIndex;
        public ControlWeaponElement(ControlWeapon ControlWeapon, WeaponParameters WeaponParameters)
        {
            InitializeComponent();
            Color = panel1.BackColor;
            this.WeaponParameters = WeaponParameters;
            this.ControlWeapon = ControlWeapon;
            ShowPhoto();
            label1.Text += WeaponParameters.NameImprovement;
            label2.Text += WeaponParameters.TypeName;
            label3.Text += WeaponParameters.Levels;
            label4.Text += WeaponParameters.Damage;

        }
        public void Click()
        {
            if (ControlWeapon.This != null)
            {
                ControlWeapon.This.ThisBackColor(Selected.No);
            }
            ControlWeapon.This = this;
            ThisBackColor(Selected.Yes);
            if (ControlWeapon.ThisComboBox != null)
            {
                if (WeaponParameters.Characters != 0)
                {
                    MessageBox.Show("Оружие в руках персонажа");
                    return;
                }

                ControlWeapon.SelectedWeapon();
                return;
            }

            ControlWeapon.ShowWeaponParameters();
        }
        private void ControlWeaponElement_Click(object sender, EventArgs e)
        {
            Click();
        }
        private void ControlWeaponElement_DoubleClick(object sender, EventArgs e)
        {
            //ControlWeapon.Weapon.Weapons.RemoveAt(ControlIndex);
            //this.Dispose();

        }

        public void ThisBackColor(Selected selected)
        {
  
            if (selected == Selected.Yes)
            {
                _panel1.BackColor = Color.LightBlue;
            }
            else if (selected == Selected.No)
            {
                _panel1.BackColor = this.Color;
            }
            
        }

        public Panel _panel1
        {
            get { return panel1; }
            set { panel1 = value; }
        }
        string startupPath = Environment.CurrentDirectory;
        async void ShowPhoto()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Padding = new Padding(5);
            panel.BackColor = WeaponParameters.RareColor;
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Fill;
            panel.Click += ControlWeaponElement_Click;
            pictureBox.Click += ControlWeaponElement_Click;
            panel.Controls.Add(pictureBox);
            panel2.Controls.Add(panel);
            try
            {
                pictureBox.Image = Image.FromFile($@"{startupPath}\Photo\{WeaponParameters.Photo}");
            }
            catch
            {
                pictureBox.Image = Image.FromFile($@"{startupPath}\Photo\Photo.jpg");
            }
        }
        public enum Selected
        {
            Yes,
            No,
        }
    }
}
