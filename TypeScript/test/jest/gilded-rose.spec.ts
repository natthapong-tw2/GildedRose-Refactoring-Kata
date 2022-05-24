import { Item, GildedRose } from '@/gilded-rose';

enum ItemName {
  AgedBrie = 'Aged Brie',
  Sulfuras = 'Sulfuras, Hand of Ragnaros',
  BackstagePasses = 'Backstage passes to a TAFKAL80ETC concert',
}

describe('Gilded Rose', () => {
  it('should foo', () => {
    const gildedRose = new GildedRose([new Item('foo', 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe('foo');
  });

  it("should reduce quality by one when item is not Aged Brie, and Backstage Passes, and Sulfuras", () => {
    const gildedRose = new GildedRose([new Item('foo', 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  })

  it("should not reduce quality when item is not Aged Brie, and Backstage Passes, and Sulfuras but quality already 0", () => {
    const gildedRose = new GildedRose([new Item('foo', 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  })

  it("should not reduce quality when item is Sulfuras and quality more than 0", () => {
    const gildedRose = new GildedRose([new Item(ItemName.Sulfuras, 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  })

  it("should increase quality by 2 when item quality < 50 and Aged Brie and sell in is 0", () => {
    const gildedRose = new GildedRose([new Item(ItemName.AgedBrie, 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(3);
  })

  it("should reduce quality to 0 when item quality < 50 and Backstage Passes and sell in is 0", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  })

  it("should increase quality by 2 when item is Backstage pass, and quality < 48, and sellIn < 11 and greather than 6", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 48)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })

  it("should increase quality by 1 when item is Backstage pass, and quality < 49, and sellIn < 11 and greather than 6", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 49)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })

  it("should increase quality by 3 when item is Backstage pass, and quality <= 47, and sellIn < 6", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 5, 47)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })

  it("should increase quality by 1 when item is Backstage pass, and quality = 49, and sellIn < 6", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 5, 47)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })

  it("should increase quality by 1 when item is Backstage pass, and quality = 49, and sellIn < 11 and greather than 6", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 49)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })

  it("should not increase quality when item is Backstage pass, and quality = 50 whatever sell in", () => {
    const gildedRose = new GildedRose([new Item(ItemName.BackstagePasses, 10, 50)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })
});
