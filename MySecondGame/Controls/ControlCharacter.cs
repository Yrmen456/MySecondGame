using MySecondGame.Data;
using Newtonsoft.Json;
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
    public partial class ControlCharacter : UserControl
    {
        public ControlCharacter()
        {
            InitializeComponent();
            foreach (var Panel in this.Controls.OfType<Panel>())
            {
                foreach (var NumericUpDown in Panel.Controls.OfType<NumericUpDown>())
                {
                    NumericUpDown.Controls[0].Visible = false;
                }
     
                //item.Controls[1].Dock =DockStyle.Fill;
                //item.Controls[0].BackColor = Color.Black;

                //item.Controls[1].Paint += NumericUpDown_Paint;
            }
            Bitmap = (Bitmap)pictureBox1.Image;
            SQLCharacter();
            SQLWeapon();
        }
        Bitmap Bitmap;
        public ControlCharacterElement This;
        public Character Character;
        public Weapon ComboBoxWeapon;

        public void ShowLabelCharacter()
        {
            
        }
        public async void SQLCharacter()
        {

            DataSet dataSet = new DataSet();
            await Task.Run(() =>
            {
                dataSet = SQL.Table($@"Select 
                Characters.ID AS CharactersID, Characters.Name AS CharactersName, Characters.Levels AS CharactersLevels,
                Characters.Speed AS CharactersSpeed, Characters.Аgility AS CharactersАgility, Characters.Intelligence AS CharactersIntelligence, Characters.Photo AS CharactersPhoto,
                Weapon.ID AS ID,  Weapon.Improvement AS Improvement,Weapon.Levels AS Levels, Weapon.Name AS Name, 
                Weapon.Damage AS Damage, Weapon.Type as TypeID, TypeWeapon.Name as TypeName, Weapon.Photo AS Photo,
                (0) as Power
                from Characters
                Left Join Weapon Weapon on Weapon.ID = Characters.Weapon
                Left Join TypeWeapon TypeWeapon on TypeWeapon.ID = Weapon.Type;");
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
            dataSet.Tables[0].TableName = "Characters";
            string json2 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Character = JsonConvert.DeserializeObject<Character>(json2, settings);
            await Task.Delay(100);
            ShowWeaponCharacter();
        }

        public async void SQLWeapon()
        {

            DataSet dataSet = new DataSet();
            await Task.Run(() =>
            {
                dataSet = SQL.Table($@"
                SELECT Weapon.ID AS ID,  Weapon.Improvement AS Improvement,Weapon.Levels AS Levels, Weapon.Name AS Name, 
                Weapon.Damage AS Damage, Weapon.Type as TypeID, TypeWeapon.Name as TypeName, Weapon.Photo AS Photo,
				Characters.ID as Characters
				FROM Weapon
                Left Join Characters Characters on Characters.Weapon = Weapon.ID
                Left Join TypeWeapon TypeWeapon on TypeWeapon.ID = Weapon.Type
                where Characters.ID is null and  Weapon.ID not in(0) Order By Weapon.ID;");
            });
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

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

            dataSet.Tables[0].TableName = "Weapons";
            string json1 = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            WeaponParameters weapon = new WeaponParameters();
            ComboBoxWeapon = JsonConvert.DeserializeObject<Weapon>(json1, settings);
            ComboBoxWeapon.Weapons = ComboBoxWeapon.Weapons.ToArray().Reverse().ToList();
            ComboBoxWeapon.Weapons.Add(weapon);
            ComboBoxWeapon.Weapons = ComboBoxWeapon.Weapons.ToArray().Reverse().ToList();
            comboBox1.DataSource = ComboBoxWeapon.Weapons;
            comboBox1.DisplayMember = "NameLvL";
            comboBox1.ValueMember = "ID";
        }

        public async void ShowWeaponCharacter()
        {
            List<ControlCharacterElement> ControlCharacterElementList = new List<ControlCharacterElement>();
            ControlCharacterElement[] ControlCharacterElementArr = { };

            await Task.Run(() => {
                for (int i = 0; i < Character.Characters.Count; i++)
                {
                    ControlCharacterElement ControlCharacterElement = new ControlCharacterElement(this, Character.Characters[i]);
                    ControlCharacterElement.Dock = DockStyle.Top;
                    ControlCharacterElement.Name = "ControlWeaponElement" + i;
                    if (This != null)
                    {
                        if (ControlCharacterElement.CharactersParameters.ID == This.CharactersParameters.ID)
                        {
                            This = ControlCharacterElement;
                        }
                    }
                    ControlCharacterElementList.Add(ControlCharacterElement);
                }
            });
            List.Visible = false;
            List.Controls.Clear();
            ControlCharacterElementArr = ControlCharacterElementList.ToArray();
            ControlCharacterElementArr = ControlCharacterElementArr.Reverse().ToArray(); ;
            List.Controls.AddRange(ControlCharacterElementArr.OrderBy(x => x.CharactersParameters.Power).ToArray()) ;
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

        private async void ControlCharacter_Paint(object sender, PaintEventArgs e)
        {
            NumericUpDown_Paint(e);

        }
        private void NumericUpDown_Paint(PaintEventArgs e)
        {
            foreach (var item in this.Controls.OfType<NumericUpDown>())
            {
                //item.Controls[0].Visible = false;
                item.Controls[0].Hide();
                //item.Controls[1].Dock =DockStyle.Fill;
                //item.Controls[0].BackColor = Color.Black;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                //g.DrawRectangle(p, new Rectangle(item.Controls[1].Location.X - variance, item.Controls[1].Location.Y - variance, item.Controls[1].Width + variance, item.Controls[1].Height + variance));

                //item.Controls[1].Paint += NumericUpDown_Paint;
            }

        }


        CharactersParameters TopCharacterPower(Character ThisCharacter)
        {
            if (ThisCharacter.Characters.Count < 1)
            {
                MessageBox.Show("Пусто");
                return null;
            }
            return ThisCharacter.Characters.OrderByDescending(x => x.Power).ToArray()[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CharactersParameters Top =  TopCharacterPower(Character);
            MessageBox.Show(Top.CharactersName + " Power:"+Top.Power.ToString());
        }

        string startupPath = Environment.CurrentDirectory;
        WeaponParameters weaponParameters;
        public void ShowCharactersParameters()
        {
            button2.Enabled = true;
            textBox1.Text = This.CharactersParameters.CharactersName;
            numericUpDown1.Value = This.CharactersParameters.CharactersLevels;
            numericUpDown2.Value = This.CharactersParameters.CharactersSpeed;
            numericUpDown3.Value = This.CharactersParameters.CharactersАgility;
            numericUpDown4.Value = This.CharactersParameters.CharactersIntelligence;
            label7.Text = This.CharactersParameters.RankPowerName;
            if (weaponParameters != null)
            {
                ComboBoxWeapon.Weapons = ComboBoxWeapon.Weapons.Where(x => x.ID != weaponParameters.ID).Select(x => x).ToList();
            }
            weaponParameters = (WeaponParameters)This.CharactersParameters;
            ComboBoxWeapon.Weapons = ComboBoxWeapon.Weapons.ToArray().Reverse().ToList();
            ComboBoxWeapon.Weapons.Add(weaponParameters);
            ComboBoxWeapon.Weapons = ComboBoxWeapon.Weapons.ToArray().Reverse().ToList();
            comboBox1.DataSource = ComboBoxWeapon.Weapons;

            try
            {
                pictureBox1.Image = Image.FromFile($@"{startupPath}\Photo\{This.CharactersParameters.CharactersPhoto}");
            }
            catch (Exception)
            {
                pictureBox1.Image = Bitmap;
            }
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
        bool BtClick = true;
        

        private void button1_Click(object sender, EventArgs e)
        {
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
            WeaponParameters items = (WeaponParameters)comboBox1.SelectedItem;
            string WeaponId = "NULL";
            if (items.ID !=0)
            {
                WeaponId = $"'{items.ID }'";
            }
            BtClick = false;
            Random random = new Random();
            string PhotoName = $"Photo{DateTime.Now.ToString("yyyy.MM.dd.HH_mm.ss_")}{random.Next(1, 100000)}.png";
            pictureBox1.Image.Save($@"{startupPath}\Photo\{PhotoName}", System.Drawing.Imaging.ImageFormat.Png);
            bool Result = SQL.Query($@"INSERT INTO [dbo].[Characters]
                   ([Name]
                   ,[Levels]
                   ,[Speed]
                   ,[Аgility]
                   ,[Intelligence]
                   ,[Weapon]
                   ,[Photo])
             VALUES
                   (N'{textBox1.Text}'
                   ,'{numericUpDown1.Value}'
                   ,'{numericUpDown2.Value}'
                   ,'{numericUpDown3.Value}'
                   ,'{numericUpDown4.Value}'
                   ,{WeaponId}
                   ,'{PhotoName}')");
            if (!Result)
            {
                MessageBox.Show("Что то пошло не так");
            }
            else
            {
                SQLCharacter();
            }
            BtClick = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                return;
            }
            WeaponParameters items = (WeaponParameters)comboBox1.SelectedItem;
            string WeaponId = "NULL";
            if (items.ID != 0)
            {
                WeaponId = $"'{items.ID }'";
            }
            BtClick = false;
            Random random = new Random();
            string PhotoName = $"Photo{DateTime.Now.ToString("yyyy.MM.dd.HH_mm.ss_")}{random.Next(1, 100000)}.png";
            pictureBox1.Image.Save($@"{startupPath}\Photo\{PhotoName}", System.Drawing.Imaging.ImageFormat.Png);
            bool Result = SQL.Query($@"UPDATE [dbo].[Characters]
               SET [Name] = N'{textBox1.Text}'
                  ,[Levels] = '{numericUpDown1.Value}'
                  ,[Speed] = '{numericUpDown2.Value}'
                  ,[Аgility] = '{numericUpDown3.Value}'
                  ,[Intelligence] = '{numericUpDown4.Value}'
                  ,[Weapon] = {WeaponId}
                  ,[Photo] = N'{PhotoName}'
             WHERE [Characters].ID = {This.CharactersParameters.CharactersID}");
            if (!Result)
            {
                MessageBox.Show("Что то пошло не так");
            }
            else
            {
                SQLCharacter();
            }

            BtClick = true;
        }
    }
}
