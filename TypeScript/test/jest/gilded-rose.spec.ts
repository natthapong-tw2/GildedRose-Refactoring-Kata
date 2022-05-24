import { Item, GildedRose } from '@/gilded-rose';

describe('Gilded Rose', () => {

  describe('Name are not "Aged Brie" and "Backstage passes to a TAFKAL80ETC concert"', () => {

    it('should foo', () => {
      const gildedRose = new GildedRose([new Item('foo', 0, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].name).toBe('foo');
    });

    it('should reduce quantity when the quality greater than zero and the name is not "Sulfuras, Hand of Ragnaros"', () => {
      const gildedRose = new GildedRose([new Item('foo', 0, 1)]);
      const items = gildedRose.updateQuality();
      expect(items[0].name).toBe('foo');
      expect(gildedRose.items[0].quality).toBe(0);
    });

    it('should keep the same quantity when the quality less or equal to zero', () => {
      let gildedRose = new GildedRose([new Item('foo', 0, -5)]);
      let items = gildedRose.updateQuality();
      expect(items[0].name).toBe('foo');
      expect(gildedRose.items[0].quality).toBe(-5);

      gildedRose = new GildedRose([new Item('foo', 0, 0)]);
      items = gildedRose.updateQuality();
      expect(items[0].name).toBe('foo');
      expect(gildedRose.items[0].quality).toBe(0);
    });
    
  });

  describe('Name is "Aged Brie"', () => {

    it('should increase quantity by 1 when sellIn is 2', () => {
      const gildedRose = new GildedRose([new Item('Aged Brie', 2, 1)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(2);
    });

    it('should increase quantity by 2 when sellIn is 0', () => {
      const gildedRose = new GildedRose([new Item('Aged Brie', 0, 1)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(3);
      expect(gildedRose.items[0].sellIn).toBe(-1);
    });

  });

  describe('Name is "Backstage passes to a TAFKAL80ETC concert"', () => {

    it('should increase quantity by 3 when sellIn is 2', () => {
      const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 2, 1)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(4);
      expect(gildedRose.items[0].sellIn).toBe(1);
    });

    it('should clear quantity 5 when sellIn is 0', () => {
      const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 0, 1)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(0);
      expect(gildedRose.items[0].sellIn).toBe(-1);
    });
  });
});
