using System;
using System.Collections.Generic;
using System.Linq;
using csharp.GildedRoses.Domain.BusinessModels;
using csharp.GildedRoses.Domain.Services.Policies;

namespace csharp.GildedRoses.Infrastructure.Repositories
{
    public class ItemFactory
    {
        private static readonly IList<Policy> policies;
        
        private string name;
        private int sellIn;
        private Quality quality;
        private string policyName;

        static ItemFactory()
        {
            policies = new List<Policy>
            {
                Policy.Cold.AgedBrie,
                Policy.Cold.BackstagePasses,
                Policy.Cold.Sulfuras,
                Policy.Cold.StandardItem,
                
                Policy.Hot.AgedBrie,
                Policy.Hot.BackstagePasses,
                Policy.Hot.Sulfuras,
                Policy.Hot.StandardItem
            };
        }

        public static ItemFactory Create()
        {
            return new ItemFactory();
        }

        public Item Get()
        {
            var selectedPolicy = SelectPolicy();
            
            if (name.Equals("Aged Brie"))
            {
                if (policyName.Equals("Hot")) {
                    return new AgedBrie
                    {
                        Name = name,
                        SellIn = sellIn,
                        Quality = quality,
                        Policy = selectedPolicy
                    };
                } 
                if (policyName.Equals("Cold")) {
                    return new AgedBrie
                    {
                        Name = name,
                        SellIn = sellIn,
                        Quality = quality,
                        Policy = selectedPolicy
                    };
                } 
            }
            
            if (name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                if (policyName.Equals("Hot"))
                {
                    return new BackstagePasses
                    {
                        Name = name,
                        SellIn = sellIn,
                        Quality = quality,
                        Policy = selectedPolicy
                    };
                }
                if (policyName.Equals("Cold"))
                {
                    return new BackstagePasses
                    {
                        Name = name,
                        SellIn = sellIn,
                        Quality = quality,
                        Policy = selectedPolicy
                    };
                }
            }
            
            if (name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                return new Sulfuras
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality,
                    Policy = selectedPolicy
                };
            }

            if (policyName.Equals("Hot"))
            {
                return new StandardItem
                {
                    Name = name,
                    SellIn = sellIn,
                    Quality = quality,
                    Policy = selectedPolicy
                };
            }
            
            return new StandardItem
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality,
                Policy = selectedPolicy
            };
        }

        public ItemFactory WithName(string itemName)
        {
            name = itemName;
            return this;
        }

        public ItemFactory WithSellIn(int itemSellIn)
        {
            sellIn = itemSellIn;
            return this;
        }

        public ItemFactory WithQuality(int itemQuality)
        {
            quality = new Quality(itemQuality);
            return this;
        }

        public ItemFactory WithPolicy(string itemPolicyName)
        {
            policyName = itemPolicyName;
            return this;
        }

        private Policy SelectPolicy()
        {
            var selectedPolicy = policies.FirstOrDefault(policy => policy.isEligibleFor(name, policyName));
            if (policies == null)
            {
                throw new Exception("Cannot select the right policy for this item");
            }

            return selectedPolicy;
        }
    }
}