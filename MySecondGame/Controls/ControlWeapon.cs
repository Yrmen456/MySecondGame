using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySecondGame.Data;
namespace MySecondGame.Controls
{
    public partial class ControlWeapon : UserControl
    {
        public ControlWeapon()
        {
            InitializeComponent();
            comboBox2.GotFocus += OnFocus;
            comboBox2.LostFocus += OnDefocus;
            comboBox3.GotFocus += OnFocus;
            comboBox3.LostFocus += OnDefocus;
            Bitmap = (Bitmap)pictureBox1.Image;
        }
        Bitmap Bitmap;
        private async void ControlWeapon_Load(object sender, EventArgs e)
        {
            SQLTypeWeapon();
            SQLWeapon();
            
        }
        public ComboBox ThisComboBox;
        public ControlWeaponElement This;
        private Weapon _Weapon;
        public Weapon Weapon 
        {
            get => _Weapon;
            set
            {
                if (value != _Weapon)
                {
                    _Weapon = value;
                    ShowWeapon();
                }
            }
        }
        public async void SQLTypeWeapon()
        {

            DataSet dataSet = new DataSet();
            await Task.Run(() => {
                dataSet = SQL.Table($@"Select * from TypeWeapon");
            });


            if (dataSet.Tables.Count <= 0)
            {
                MessageBox.Show("F1");
                return;
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("F2");
                return;
            }
            dataSet.Tables[0].TableName = "TypeWeapons";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            TypeWeapon TypeWeapon = new TypeWeapon();
            TypeWeapon = JsonConvert.DeserializeObject<TypeWeapon>(json);
            comboBox1.DataSource = TypeWeapon.TypeWeapons;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
        }
        public async void SQLWeapon()
        {
          
            DataSet dataSet = new DataSet();
            await Task.Run(() => {
                dataSet = SQL.Table($@" SELECT Weapon.ID AS ID,  Weapon.Improvement AS Improvement,Weapon.Levels AS Levels, Weapon.Name AS Name, 
                Weapon.Damage AS Damage, Weapon.Type as TypeID, TypeWeapon.Name as TypeName, Weapon.Photo AS Photo,
				Characters.ID as Characters
				FROM Weapon
                Left Join Characters Characters on Characters.Weapon = Weapon.ID
                Left Join TypeWeapon TypeWeapon on TypeWeapon.ID = Weapon.Type
                where Weapon.ID not in(0) Order By Weapon.ID;");
            });

   
            if (dataSet.Tables.Count <= 0)
            {
                MessageBox.Show("F1");
                return;
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("F2");
                return;
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            dataSet.Tables[0].TableName = "Weapons";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Weapon = JsonConvert.DeserializeObject<Weapon>(json, settings);
            

        }

        async void ShowWeapon()
        {

            comboBox2.DataSource = Weapon.Weapons.Where(x => x.Characters == 0).Select(x => x).ToList();
            comboBox2.DisplayMember = "NameImprovement";
            comboBox2.ValueMember = "ID";
            comboBox3.DataSource = Weapon.Weapons.Where(x => x.Characters == 0).Select(x => x).ToList();
            comboBox3.DisplayMember = "NameImprovement";
            comboBox3.ValueMember = "ID";
            ComoBoxSelected(comboBox2);
            ComoBoxSelected(comboBox3);

            List<ControlWeaponElement> ControlWeaponElementList = new List<ControlWeaponElement>();
            ControlWeaponElement[] ControlWeaponElementArr = { };
            
            await Task.Run(() => {
                for (int i = 0; i < Weapon.Weapons.Count; i++)
                {
                    ControlWeaponElement ControlWeaponElement = new ControlWeaponElement(this, Weapon.Weapons[i]);
                    ControlWeaponElement.ControlIndex = i;
                    ControlWeaponElement.Dock = DockStyle.Top;
                    ControlWeaponElement.Name = "ControlWeaponElement" + i;
                    if (This != null)
                    {
                        if (ControlWeaponElement.WeaponParameters.ID == This.WeaponParameters.ID)
                        {
                            This = ControlWeaponElement;
                        }
                    }
                    ControlWeaponElementList.Add(ControlWeaponElement);
                }
            });
           
            List.Visible = false;
            List.Controls.Clear();
            ControlWeaponElementArr = ControlWeaponElementList.ToArray();
            ControlWeaponElementArr = ControlWeaponElementArr.Reverse().ToArray(); ;
            List.Controls.AddRange(ControlWeaponElementArr);
            List.AutoScroll = true;
            List.HorizontalScroll.Maximum = 0;
            List.AutoScroll = false;
            List.VerticalScroll.Maximum = 0;
            List.AutoScroll = true;
            await Task.Delay(10);
            List.Visible = true;
            if (This != null)
            {
                This.Click();
            }
        }
        string startupPath = Environment.CurrentDirectory;
        public void ShowWeaponParameters()
        {
            button1.Enabled = true;
            textBox1.Text = This.WeaponParameters.Name;
            numericUpDown1.Value = This.WeaponParameters.Levels;
            numericUpDown2.Value = This.WeaponParameters.Damage;
            comboBox1.SelectedValue = This.WeaponParameters.TypeID;
            label10.Text = This.WeaponParameters.ImprovementStar;
            try
            {
                pictureBox1.Image = Image.FromFile($@"{startupPath}\Photo\{This.WeaponParameters.Photo}");
            }
            catch (Exception)
            {
                pictureBox1.Image = Bitmap;
            }
        }
        bool BtClick = true;
        private async void button1_Click(object sender, EventArgs e)
        {

            //foreach (var item in List.Controls.OfType<ControlWeaponElement>())
            //{
            //    if (item.ControlIndex == 2)
            //    {
            //        item.ThisBackColor(ControlWeaponElement.Selected.Yes);
            //    }
            //}
            if (!BtClick)
            {
                return;
            }
            if (textBox1.Text.Length < 0)
            {

            }
            string Group = textBox1.Text;
            Group = System.Text.RegularExpressions.Regex.Replace(textBox1.Text, @"\s+", " ");

            if (Group.Length <= 0)
            {
                return;
            }
            if (Group[0] == ' ')
            {
                Group = Group.Remove(0, 1);
            }
            if (Group[Group.Length - 1] == ' ')
            {
                Group = Group.Remove(Group.Length - 1);
            }
            textBox1.Text = Group;
            if (Group.Length < 3)
            {
                MessageBox.Show("Имя слишком короткое");
                return;
            }
            TypeWeaponParameters items = (TypeWeaponParameters)comboBox1.SelectedItem;

            BtClick = false;
            Random random = new Random();
            string PhotoName = $"Photo{DateTime.Now.ToString("yyyy.MM.dd.HH_mm.ss_")}{random.Next(1, 100000)}.png";
            pictureBox1.Image.Save($@"{startupPath}\Photo\{PhotoName}", System.Drawing.Imaging.ImageFormat.Png);
            bool Result = SQL.Query($@"UPDATE [dbo].[Weapon]
               SET [Name] = N'{textBox1.Text}'
                  ,[Levels] ='{numericUpDown1.Value}'
                  ,[Damage] = '{numericUpDown2.Value}'
                  ,[Type] = '{This.WeaponParameters.TypeID}'
                  ,[Photo] = '{PhotoName}'
                  ,[Improvement] ='{This.WeaponParameters.Improvement}'
             WHERE [Weapon].ID = '{This.WeaponParameters.ID}'");
            if (!Result)
            {
                MessageBox.Show("Что то пошло не так");
            }
            else
            {
                SQLWeapon();
            }
     
            BtClick = true;
        }
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!BtClick)
            {
                return;
            }
            if (textBox1.Text.Length<0)
            {

            }
            string Group = textBox1.Text;
            Group = System.Text.RegularExpressions.Regex.Replace(textBox1.Text, @"\s+", " ");

            if (Group.Length <= 0)
            {
                return;
            }
            if (Group[0] == ' ')
            {
                Group = Group.Remove(0, 1);
            }
            if (Group[Group.Length-1] == ' ')
            {
                Group = Group.Remove(Group.Length - 1);
            }
            textBox1.Text = Group;
            if (Group.Length < 3)
            {
                MessageBox.Show("Имя слишком короткое");
                return;
            }
            TypeWeaponParameters items = (TypeWeaponParameters)comboBox1.SelectedItem;
      
            BtClick = false;
            Random random = new Random();
            string PhotoName = $"Photo{DateTime.Now.ToString("yyyy.MM.dd.HH_mm.ss_")}{random.Next(1,100000)}.png";
            pictureBox1.Image.Save($@"{startupPath}\Photo\{PhotoName}",System.Drawing.Imaging.ImageFormat.Png);
            bool Result = SQL.Query($@"INSERT INTO [dbo].[Weapon]
                   ([Name]
                   ,[Levels]
                   ,[Damage]
                   ,[Type]
                   ,[Photo])
             VALUES
                   (N'{textBox1.Text}'
                   ,'{numericUpDown1.Value}'
                   ,'{numericUpDown2.Value}'
                   ,'{items.ID}'
                   ,N'{PhotoName}')");
            if (!Result)
            {
                MessageBox.Show("Что то пошло не так");
            }
            else
            {
                SQLWeapon();
            }
            BtClick = true;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OnFocus(object sender, EventArgs e)
        {
            ThisComboBox = (ComboBox)sender;
            if (This != null)
            {
                This.ThisBackColor(ControlWeaponElement.Selected.No);
            }
            button1.Enabled = false;
        }

        private void OnDefocus(object sender, EventArgs e)
        {
            ThisComboBox = null;
            if (This  != null)
            {
                This.ThisBackColor(ControlWeaponElement.Selected.No);
            }

        }

        public void SelectedWeapon()
        {
            if (ThisComboBox == null)
            {
                return;
            }
            if (ThisComboBox == comboBox2)
            {
                WeaponParameters comboBoxitems = (WeaponParameters)comboBox3.SelectedItem;
                if (comboBoxitems.ID == This.WeaponParameters.ID)
                {
                    This.ThisBackColor(ControlWeaponElement.Selected.No);
                    MessageBox.Show("Уже используется в крафте");
                    return;
                }
            }
            if (ThisComboBox == comboBox3)
            {
                WeaponParameters comboBoxitems = (WeaponParameters)comboBox2.SelectedItem;
                if (comboBoxitems.ID == This.WeaponParameters.ID)
                {
                    This.ThisBackColor(ControlWeaponElement.Selected.No);
                    MessageBox.Show("Уже используется в крафте");
                    return;
                }
            }
            ThisComboBox.SelectedValue = This.WeaponParameters.ID;
            ComoBoxSelected(ThisComboBox);
        }


        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComoBoxSelected(comboBox);
        }

        void ComoBoxSelected(ComboBox comboBox)
        {
            WeaponParameters items = (WeaponParameters)comboBox.SelectedItem;
            if (comboBox2.Items.Count > 0 && comboBox3.Items.Count > 0)
            {
                if (comboBox == comboBox2)
                {
                    WeaponParameters comboBoxitems = (WeaponParameters)comboBox3.SelectedItem;
                    comboBox3.DataSource = Weapon.Weapons.Where(x => x.ID != items.ID &&  x.Characters == 0).ToList();
                    if (comboBoxitems.ID != items.ID)
                    {
                        comboBox3.SelectedValue = comboBoxitems.ID;
                    }
              
                }
                if (comboBox == comboBox3)
                {
                    WeaponParameters comboBoxitems = (WeaponParameters)comboBox2.SelectedItem;
                    comboBox2.DataSource = Weapon.Weapons.Where(x => x.ID != items.ID &&  x.Characters == 0).ToList();
                    if (comboBoxitems.ID != items.ID)
                    {
                        comboBox2.SelectedValue = comboBoxitems.ID;
                    }
                
                }

            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            WeaponParameters comboBox2items = (WeaponParameters)comboBox2.SelectedItem;
            WeaponParameters comboBox3items = (WeaponParameters)comboBox3.SelectedItem;
            if (comboBox2items.TypeID != comboBox3items.TypeID)
            {
                MessageBox.Show(
                "Типы оружий не совпадают",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            DataSet dataSet = new DataSet();
            await Task.Run(() => {
                dataSet = SQL.Table($@"EXEC NewWeapon {comboBox2items.ID}, {comboBox3items.ID};");
            });


            if (dataSet.Tables.Count < 2)
            {
                MessageBox.Show("Что то пошло не так");
                return;
            }
            if (dataSet.Tables[1].Rows.Count <= 0)
            {
                MessageBox.Show("Что то пошло не так");
                return;
            }
            dataSet.Tables[0].TableName = "Weapons";
            string json = JsonConvert.SerializeObject(dataSet.Tables[1], Formatting.Indented);
            json = json.Trim('[',']');
            SQLWeapon();
        }
        
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            pictureBox1.Image = Image.FromFile(filename);

        }
    }
}
