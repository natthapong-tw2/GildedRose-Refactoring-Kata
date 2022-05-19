import { Item, GildedRose } from '@/gilded-rose';

describe('Gilded Rose', () => {
  it('should foo', () => {
    const gildedRose = new GildedRose([new Item('foo', 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe('foo');
  });

  it('quality should be minus 1 when name is not "Aged Brie" or "Backstage passes to a TAFKAL80ETC concert" or "Sulfuras, Hand of Ragnaros"', () => {
    const gildedRose = new GildedRose([new Item('foo', 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });

  it('quality should be add 2 when name is "Backstage passes to a TAFKAL80ETC concert and sellIn less than 11, greater than 6 and quality less than 50"', () => {
    const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 7, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(3);
  });

  it('quality should be add 3 when name is "Backstage passes to a TAFKAL80ETC concert and sellIn less than 6 and quality less than 50"', () => {
    const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 5, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(4);
  });
});
