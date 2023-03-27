using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MySecondGame.Data
{
    class Data
    {
    }



    public class Character
    {
        public List<CharactersParameters> Characters { get; set; }
    }
    public class CharactersParameters : WeaponParameters
    {

        public CharactersParameters()
        {
            RankPowerID = 0;
            RankPowerName = "Просто чел";
            CharactersName = "Безымянный персонаж";
            CharactersLevels = 1;
            CharactersSpeed = 1;
            CharactersАgility = 1;
            CharactersIntelligence = 100;
        }
        public int CharactersID { get; set; }
        public string CharactersName  { get; set; }
        public int CharactersLevels { get; set; }
        public int CharactersSpeed { get; set; }
        public int CharactersАgility { get; set; }
        public int CharactersIntelligence { get; set; }
        public string CharactersPhoto { get; set; }
        private int _Power;
        public int RankPowerID;
        public string RankPowerName;
        public int Power
        {
            get => _Power;
            set
            {
               
                value = ((CharactersSpeed + CharactersАgility + CharactersIntelligence) * CharactersLevels) +(Levels * Damage);
                RankPower(TypeID, ((CharactersSpeed + CharactersАgility + CharactersIntelligence) * CharactersLevels) + (Levels * Damage));

                if (value != _Power)
                {
                    _Power = value;
                  
                }
            }
        }

        async void RankPower(int type, int power)
        {
            RankPowerID = 0;
            RankPowerName = "Просто чел1";

            int _type = type;
            int _power = power;
            DataSet dataSet = new DataSet();
            await Task.Run(() => {
                dataSet = SQL.Table($@" ThisRankPower {_type},{_power};");
            });


            if (dataSet.Tables.Count <= 0)
            {
                RankPowerID = 0;
                RankPowerName = "Просто чел2";
                return;
            }
            if (dataSet.Tables[0].Rows.Count <= 0)
            {
                RankPowerID = 0;
                RankPowerName = "Просто чел3";
                return;
            }
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            dataSet.Tables[0].TableName = "TypeWeaponParameters";
            string json = JsonConvert.SerializeObject(dataSet.Tables[0], Formatting.Indented);
            json = json.Trim('[',']');
            TypeWeaponParameters TypeWeaponParameters = new TypeWeaponParameters();
            TypeWeaponParameters = JsonConvert.DeserializeObject<TypeWeaponParameters>(json, settings);
            RankPowerID = TypeWeaponParameters.ID;
            RankPowerName = TypeWeaponParameters.Name;

        }
    }

    public class Weapon
    {
        public List<WeaponParameters> Weapons { get; set; }
    }
    public class WeaponParameters  
    {
        public WeaponParameters()
        {
            this.Levels = 1;
            this.Name = "Безымянный щит (DEFOLT)";
            this.Damage = 10;
            this.TypeID = 3;
            this.TypeName = "Щит";
        }
        public string NameLvL { get; set; }
        private int _ID;
        public int ID 
        {
            get => _ID;
            set
            {
                if (value != _ID)
                {
                    _ID = value;
                }
            }
        }
        public int Levels { get; set; }
        public int Damage { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Photo { get; set; }        
        public int Characters { get; set; }
     

        private int _Improvement { get; set; }
        public int Improvement
        {
            get => _Improvement;
            set
            {
                if (value != _Improvement)
                {
                    _Improvement = value;
                    StarList starList = (StarList)_Improvement;
                    switch (starList)
                    {
                        case StarList.WorseGarbage:
                            RareColor = MyColors.WorseGarbage;
                            break;
                        case StarList.Garbage:
                            RareColor = MyColors.Garbage;
                            break;
                        case StarList.Common:
                            RareColor = MyColors.Common;
                            break;
                        case StarList.Uncommon:
                            RareColor = MyColors.Uncommon;
                            break;
                        case StarList.Rare:
                            RareColor = MyColors.Rare;
                            break;
                        case StarList.Exceedingly_Rare:
                            RareColor = MyColors.Exceedingly_Rare;
                            break;
                        case StarList.Mythical:
                            RareColor = MyColors.Mythical;
                            break;
                        case StarList.Legendary:
                            RareColor = MyColors.Legendary;
                            break;
                        case StarList.Ancient:
                            RareColor = MyColors.Ancient;
                            break;
                        case StarList.Immortal:
                            RareColor = MyColors.Immortal;
                            break;
                        case StarList.Divine:
                            RareColor = MyColors.Divine;
                            break;
                    }
                }
            }

        }

        public string NameImprovement { get; set; }
        public string ImprovementStar { get; set; }
        public Color RareColor { get; set; }
        private string _Name;
        public string Name 
        {
            get => _Name;
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    NameImprovement = value;
                    for (int i = 0; i < Improvement; i++)
                    {
                        NameImprovement += "★";
                        ImprovementStar += "★";
                    }

                    NameLvL  = $"{Name} LVL-{Levels}";
                }
            }
        }


       
    }


    public class TypeWeapon
    {
        public List<TypeWeaponParameters> TypeWeapons { get; set; }
    }
    public class TypeWeaponParameters
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

    public enum NewWeapon
    {
        Defolt,
        Custom,
    }

}
