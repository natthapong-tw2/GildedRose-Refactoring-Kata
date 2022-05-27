class Item {
  constructor(name, sellIn, quality) {
    this.name = name;
    this.sellIn = sellIn;
    this.quality = quality;
  }
}

function updateDefaultItem({ sellIn, quality }) {
  let newQuality;

  if (sellIn > 0) {
    newQuality = quality - 1;
  } else {
    newQuality = quality - 2;
  }

  if (newQuality < 0) newQuality = 0;

  return { sellIn: sellIn - 1, quality: newQuality };
}

function updateAgedBrie({ sellIn, quality }) {
  let newQuality;

  if (sellIn > 0) {
    newQuality = quality + 1;
  } else {
    newQuality = quality + 2;
  }

  if (newQuality > 50) newQuality = 50;

  return { sellIn: sellIn - 1, quality: newQuality };
}

function updateBackstagePasses({ sellIn, quality }) {
  let newQuality;

  if (sellIn > 10) {
    newQuality = quality + 1;
  } else if (sellIn > 5) {
    newQuality = quality + 2;
  } else if (sellIn > 0) {
    newQuality = quality + 3;
  } else {
    newQuality = 0;
  }

  if (newQuality > 50) newQuality = 50;

  return { sellIn: sellIn - 1, quality: newQuality };
}

class Shop {
  constructor(items = []) {
    this.items = items;
  }
  updateQuality() {
    for (let i = 0; i < this.items.length; i++) {
      const currentItem = this.items[i];
      const { sellIn, quality } = currentItem;

      switch (currentItem.name) {
        case "Sulfuras, Hand of Ragnaros":
          break;

        case "Aged Brie":
          this.items[i] = {
            ...currentItem,
            ...updateAgedBrie({ sellIn, quality })
          };
          break;

        case "Backstage passes to a TAFKAL80ETC concert":
          this.items[i] = {
            ...currentItem,
            ...updateBackstagePasses({ sellIn, quality })
          };
          break;

        default:
          this.items[i] = {
            ...currentItem,
            ...updateDefaultItem({ sellIn, quality })
          };
          break;
      }
    }

    return this.items;
  }
}

module.exports = {
  Item,
  Shop
};
