import { Item, GildedRose } from '@/gilded-rose';

enum ItemName {
  AgedBrie = 'Aged Brie',
  Sulfuras = 'Sulfuras, Hand of Ragnaros',
  BackstagePasses = 'Backstage passes to a TAFKAL80ETC concert',
}

describe('Gilded Rose', () => {


  describe("Other item", () => {
    it("should reduce quality by 2 when quality more than 0 and sell in less than 0", () => {
      const gildedRose = new GildedRose([new Item("foo", -1, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(48);
    })

    it("should reduce sell in by 1", () => {
      const gildedRose = new GildedRose([new Item("foo", 10, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(9);
    })

    it("should reduce quality by one", () => {
      const gildedRose = new GildedRose([new Item('foo', 0, 1)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    })

    it("should not reduce quality when item is not Aged Brie, and Backstage Passes, and Sulfuras but quality already 0", () => {
      const gildedRose = new GildedRose([new Item('foo', 0, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    })
  })

  describe("Sulfuras", () => {
    it("should not reduce quality when sell in less than 0", () => {
      const gildedRose = new GildedRose([new Item(ItemName.Sulfuras, -1, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should not reduce quality when quality more than 0", () => {
      const gildedRose = new GildedRose([new Item(ItemName.Sulfuras, 0, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    })
  })

  describe("Backstage Passes", () => {
    it("should reduce quality to 0 when sell in < 0", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, -1, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    })

    it("should reduce sell in by 1", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(9);
    })

    it("should not increase quality when quality = 50 whatever sell in", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should increase quality by 1 when quality = 49, and sellIn < 6", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 5, 47)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should increase quality by 1 when quality = 49, and sellIn < 11 and greater than 6", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 49)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should increase quality by 2 when and quality < 48, and sellIn < 11 and greater than 6", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 48)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should increase quality by 1 when and quality < 49, and sellIn < 11 and greather than 6", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 49)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should increase quality by 3 when and quality <= 47, and sellIn < 6", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 5, 47)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should reduce quality to 0 when item quality < 50 and sell in is 0", () => {
      const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 0, 1)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    })
  })

  describe("Aged Brie", () => {
    it("should increase quality by 1 when item quality 49 and sell in is 0", () => {
      const gildedRose = new GildedRose([new Item(ItemName.AgedBrie, 0, 49)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    })

    it("should reduce sell in by 1", () => {
      const gildedRose = new GildedRose([new Item(ItemName.AgedBrie, 10, 50)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(9);
    })

    it("should increase quality by 2 when item quality < 50 and sell in is 0", () => {
      const gildedRose = new GildedRose([new Item(ItemName.AgedBrie, 0, 1)]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(3);
    })
  })
});
