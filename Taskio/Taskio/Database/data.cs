using System;
using System.Collections.Generic;
using System.Text;
using Taskio.Models;
using System.Collections;
namespace Taskio.Database
{
   public class data
    {
        public List  <Items> Funiture = new List<Items>();
        public void add()
        {
            Funiture.Add(new Items
            {
                Name="table",Num=44,quantity=50
            });

            Funiture.Add(new Items
            {
                Name="Chair",Num=40,quantity=50
            });
            Funiture.Add(new Items
            {
                Name="Chair",Num=40,quantity=50
            });
            Funiture.Add(new Items
            {
                Name="Chair",Num=40,quantity=50
            });
            Funiture.Add(new Items
            {
                Name="Chair",Num=40,quantity=50
            });

            Funiture.Add(new Items
            {
                Name="Desk",Num=42,quantity=50
            });
            Funiture.Add(new Items
            {
                Name="Desk",Num=42,quantity=50
            });
            Funiture.Add(new Items
            {
                Name="Desk",Num=42,quantity=50
            });Funiture.Add(new Items
            {
                Name="Desk",Num=42,quantity=50
            });
            Funiture.Add(new Items
            {
                Name="Desk",Num=42,quantity=50
            });


        }
    }
}
