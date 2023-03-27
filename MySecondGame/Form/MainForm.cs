using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySecondGame.Controls;
using MySecondGame.Data;
namespace MySecondGame
{
    public partial class MainForm : PatternForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void ButtonShowControlWeapon_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            ControlWeapon ControlWeapon = new ControlWeapon();
            ControlWeapon.Dock = DockStyle.Fill;
            ControlContener.Visible = false;
            ControlContener.Controls.Add(ControlWeapon);
            await Task.Delay(10);
            ControlContener.Visible = true;
        }

        private async void ButtonShowControlCharacter_Click(object sender, EventArgs e)
        {
            ControlContener.Controls.Clear();
            ControlCharacter ControlCharacter = new ControlCharacter();
            ControlCharacter.Dock = DockStyle.Fill;
            ControlContener.Visible = false;
            ControlContener.Controls.Add(ControlCharacter);
            await Task.Delay(10);
            ControlContener.Visible = true;
        }
    }
}
