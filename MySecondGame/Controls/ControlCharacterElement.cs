using MySecondGame.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySecondGame.Controls
{
    public partial class ControlCharacterElement : UserControl
    {
        ControlCharacter ControlCharacter;
        public CharactersParameters CharactersParameters; 

        Color Color;
        public ControlCharacterElement(ControlCharacter ControlCharacter, CharactersParameters CharactersParameters)
        {
            InitializeComponent();
            this.ControlCharacter = ControlCharacter;
            this.CharactersParameters = CharactersParameters;
            Color = this.BackColor;
            label1.Text += CharactersParameters.CharactersName;
            label2.Text += CharactersParameters.CharactersLevels;
            label3.Text += CharactersParameters.CharactersSpeed + " dext:" + CharactersParameters.CharactersАgility + " int:" + CharactersParameters.CharactersIntelligence;
            label4.Text += CharactersParameters.RankPowerName;
            label5.Text += CharactersParameters.Power;
            label6.Text += CharactersParameters.NameImprovement;
            ShowPhoto();
        }
        string startupPath = Environment.CurrentDirectory;
        async void ShowPhoto()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Click += panel1_Click;
            panel2.Controls.Add(pictureBox);
            try
            {
                pictureBox.Image = Image.FromFile($@"{startupPath}\Photo\{CharactersParameters.CharactersPhoto}");
            }
            catch
            {
                pictureBox.Image = Image.FromFile($@"{startupPath}\Photo\Photo.jpg");
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Click();
        }
        public void Click()
        {
      
            if (ControlCharacter.This != null)
            {
                ControlCharacter.This.ThisBackColor(Selected.No);
            }

            ControlCharacter.This = this;
            ThisBackColor(Selected.Yes);
            ControlCharacter.ShowCharactersParameters();
        }
        public void ThisBackColor(Selected selected)
        {
            if (selected == Selected.Yes)
            {
                panel1.BackColor = Color.LightBlue;
            }
            else if (selected == Selected.No)
            {
                panel1.BackColor = this.Color;
            }

        }
        public enum Selected
        {
            Yes,
            No,
        }
    }
}
