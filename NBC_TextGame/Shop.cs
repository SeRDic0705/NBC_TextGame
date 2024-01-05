using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NBC_TextGame
{
    internal class Shop
    {
        public List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public void BuyItem(int index, Character player)
        {
            if (items[index].price >  player.gold)
            {
                Console.WriteLine("Gold가 부족합니다.");
            }
            else
            {
                player.gold -= items[index].price;
                player.AddInventory(items[index]);
                items.RemoveAt(index);
                SaveOptions();
            }
        }


        public void SaveOptions()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "/shop.json";
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public void LoadOptions()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "/shop.json";
            string json = File.ReadAllText(path);

            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);

            this.items = items;

        }
    }
}
