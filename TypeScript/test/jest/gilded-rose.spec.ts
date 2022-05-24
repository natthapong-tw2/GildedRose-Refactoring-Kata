import { Item, GildedRose } from '@/gilded-rose';

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
    const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  })

  it("should increase quality by 2 when item quality < 50 and Aged Brie and sell in is 0", () => {
    const gildedRose = new GildedRose([new Item('Aged Brie', 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(3);
  })

  it("should reduce quality to 0 when item quality < 50 and Backstage Passes and sell in is 0", () => {
    const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  })
});
