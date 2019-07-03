using System;
using System.Collections.Generic;
using System.Text;

namespace Taskio.Models
{
    public class  ItemForSideNav
    {
        private List<string> items = new List<string>();
        public ItemForSideNav()
        {
            addItem();
        }
        public List<string> GetItems()
        {
            return items;
        }
        private void addItem()
        {
            for (int i = 0; i < 6; i++)
            {
                string item = $"Pick {i}";
                items.Add(item);
            }
        }     
    }
}
