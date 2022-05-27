class Item {
  constructor(name, sellIn, quality) {
    this.name = name;
    this.sellIn = sellIn;
    this.quality = quality;
  }
}

function updateAgedBrie(item) {
  if (item.sellIn > 0) {
    item.quality += 1;
  } else {
    item.quality += 2;
  }

  if (item.quality > 50) item.quality = 50;

  item.sellIn -= 1;

  return item;
}

function updateBackstagePasses(item) {
  if (item.sellIn > 10) {
    item.quality += 1;
  } else if (item.sellIn > 5) {
    item.quality += 2;
  } else if (item.sellIn > 0) {
    item.quality += 3;
  } else {
    item.quality = 0;
  }

  if (item.quality > 50) item.quality = 50;

  item.sellIn -= 1;

  return item;
}

class Shop {
  constructor(items = []) {
    this.items = items;
  }
  updateQuality() {
    for (let i = 0; i < this.items.length; i++) {
      const currentItem = this.items[i];
      if (currentItem.name === "Sulfuras, Hand of Ragnaros") return this.items;

      if (currentItem.name === "Aged Brie") {
        this.items[i] = updateAgedBrie({ ...currentItem });
        return this.items;
      }

      if (currentItem.name === "Backstage passes to a TAFKAL80ETC concert") {
        this.items[i] = updateBackstagePasses({ ...currentItem });
        return this.items;
      }

      // more than minimum quality
      if (currentItem.quality > 0) {
        // decrease quality
        currentItem.quality = currentItem.quality - 1;
      }

      currentItem.sellIn = currentItem.sellIn - 1;

      if (currentItem.sellIn < 0) {
        if (currentItem.quality > 0) {
          currentItem.quality = currentItem.quality - 1;
        }
      }
    }

    return this.items;
  }
}

module.exports = {
  Item,
  Shop
};
