import { Item, GildedRose } from '@/gilded-rose';

describe('Gilded Rose', () => {

  describe('Name is "foo"', () => {

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
      expect(gildedRose.items[0].sellIn).toBe(-1);
    });

    it('should reduce both quantity and sellIn by 1 when quality is more than 50 and sellin is more than 0"', () => {
      const gildedRose = new GildedRose([new Item('foo', 2, 51)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(50);
      expect(gildedRose.items[0].sellIn).toBe(1);
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

    it('should increase quantity by 1 and reduce sellIn by 1 when quality is less than 50 and sellin is more than 11"', () => {
      const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 12, 5)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(6);
      expect(gildedRose.items[0].sellIn).toBe(11);
    });

    it('should increase quantity by 2 and reduce sellIn by 1 when quality is less than 50 and sellin is more than 6 and less than 11"', () => {
      const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 8, 5)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(7);
      expect(gildedRose.items[0].sellIn).toBe(7);
    });
  });

  describe('Name is "Sulfuras, Hand of Ragnaros"', () => {

    it('should not update anything when quality is less than 50 and sellin is more than 0', () => {
      const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', 2, 1)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(1);
      expect(gildedRose.items[0].sellIn).toBe(2);
    });

    it('should not update anything when quality is less than 50 and sellin is less than 0', () => {
      const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', -1, 1)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(1);
      expect(gildedRose.items[0].sellIn).toBe(-1);
    });

    it('should not update anything when quality is more than 50 and sellin is more than 0', () => {
      const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', 2, 51)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(51);
      expect(gildedRose.items[0].sellIn).toBe(2);
    });

    it('should not update anything when quality is more than 50 and sellin is less than 0', () => {
      const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', -1, 51)]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items[0].quality).toBe(51);
      expect(gildedRose.items[0].sellIn).toBe(-1);
    });

  });

  describe('Empty Item', () => {
    it('should not do anything', () => {
      const gildedRose = new GildedRose([]);
      const items = gildedRose.updateQuality();
      expect(gildedRose.items).toHaveLength(0);
    });
  });
});
