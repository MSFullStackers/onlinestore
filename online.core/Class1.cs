using System;
using System.Collections.Generic;

namespace online.core
{
    public interface IItems
    {
        List<Item> Get();
    }

    [DiComponent]
    public class Items : IItems
    {
        public List<Item> Get()
        {
            return new List<Item>(){ new Item{ Id = "1"  , Name ="Rice" } , new Item{ Id = "2"  , Name ="Beans" } };
        }
    }

    public class Item 
    {
        public string Id {get;set;}
        public string Name {get;set;}
    }
}
