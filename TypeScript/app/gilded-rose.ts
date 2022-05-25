import { ItemName } from "@/item-name";

export class Item {
  name: string;
  sellIn: number;
  quality: number;

  constructor(name, sellIn, quality) {
    this.name = name;
    this.sellIn = sellIn;
    this.quality = quality;
  }
}

export class GildedRose {
  items: Array<Item>;

  constructor(items = [] as Array<Item>) {
    this.items = items;
  }

  updateQuality() {
    this.items = this.items.map(item => {
      if (item.name != ItemName.Sulfuras) {
        item.sellIn = item.sellIn - 1;
      }

      if (item.name == ItemName.AgedBrie) {
        if (item.quality < 50) {
          item.quality = item.quality + 1
        }
        if(item.sellIn < 0) {
          if (item.quality < 50) {
            item.quality = item.quality + 1
          }
        }
      } else if ( item.name == ItemName.BackstagePasses ) {
        if (item.sellIn < 0) {
          item.quality = 0
        }
        else if (item.quality < 50) {
          item.quality = item.quality + 1
          if (item.name == ItemName.BackstagePasses) {
            if (item.sellIn < 11) {
              if (item.quality < 50) {
                item.quality = item.quality + 1
              }
            }
            if (item.sellIn < 6) {
              if (item.quality < 50) {
                item.quality = item.quality + 1
              }
            }
          }
        }
      } else {
        if (item.quality > 0) {
          if (item.name != ItemName.Sulfuras) {
            item.quality = item.quality - 1
          }
        }
        if(item.sellIn < 0) {
          if (item.quality > 0) {
            if (item.name != ItemName.Sulfuras) {
              item.quality = item.quality - 1
            }
          }
        }
      }
      return item
    })

    return this.items
  }
}
