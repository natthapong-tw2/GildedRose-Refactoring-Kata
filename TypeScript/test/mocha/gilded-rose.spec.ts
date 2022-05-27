import {expect} from 'chai';
import {Item, GildedRose} from '@/gilded-rose';

describe('GildeRose', () => {
  describe('Expirable products', () => {
    const testData = [{name: "Honey lemon", sellIn: -2, quality: 3}];

    testData.forEach(({name, sellIn, quality}) => {
      it(`Once the sell by date has passed, Quality degrades twice as fast for name: ${name}, Selling: ${sellIn}, Quality: ${quality}`, () => {
        const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);

        const items = gildedRose.updateQuality();

        expect(items[0]).to.deep.equal({
          name, sellIn: -3, quality: 1
        });
      })
    })
  });

  describe('Aged Brie', () => {
    let testData = [
      {name: "Aged Brie", sellIn: 1, quality: 0},
      {name: "Aged Brie", sellIn: 2, quality: 0},
    ]
    testData.forEach(({name, sellIn, quality}) => {
      it(`the sell by date has not pass, quality increase only one for name: ${name}, Selling: ${sellIn}, Quality: ${quality}`, () => {
        const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
        const items = gildedRose.updateQuality();
        expect(items[0]).to.deep.equal({
          name, sellIn: sellIn - 1, quality: quality + 1
        });
      })
    })

    testData = [
      {name: "Aged Brie", sellIn: 0, quality: 0},
      {name: "Aged Brie", sellIn: -1, quality: 0},
    ]
    testData.forEach(({name, sellIn, quality}) => {
      it(`Once the sell by date has passed, quality increase twice as fast for name: ${name}, Selling: ${sellIn}, Quality: ${quality}`, () => {
        const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
        const items = gildedRose.updateQuality();
        expect(items[0]).to.deep.equal({
          name, sellIn: sellIn - 1, quality: quality + 2
        });
      })
    })

    it('quality should never exceed 50', () => {
      const gildedRose = new GildedRose([new Item('Aged Brie', 0, 49)]);

      const items = gildedRose.updateQuality();

      expect(items[0]).to.deep.equal({
        name: 'Aged Brie',
        sellIn: -1,
        quality: 50
      });
    });
  });


  describe('Legendary item', () => {
    let testData = [
      {name: "Sulfuras, Hand of Ragnaros", sellIn: -1, quality: 0},
      {name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 1},
      {name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 50},
      {name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 51},
      {name: "Sulfuras, Hand of Ragnaros", sellIn: 2, quality: 80},
    ]
    testData.forEach(({name, sellIn, quality}) => {
      it(`the sell by date has not pass, quality increase only one for for name: ${name}, Selling: ${sellIn}, Quality: ${quality}`, () => {
        const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);

        const items = gildedRose.updateQuality();

        expect(items[0]).to.deep.equal({
          name, sellIn, quality
        });
      })
    })

    it('quality should never exceed 50', () => {
      const gildedRose = new GildedRose([new Item('Aged Brie', 0, 49)]);

      const items = gildedRose.updateQuality();

      expect(items[0]).to.deep.equal({
        name: 'Aged Brie',
        sellIn: -1,
        quality: 50
      });
    });
  });

  describe('Backstage passes', () => {
    let testData = [
      {name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality: 0, expectedQuality: 2},
      {name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 5, quality: 0, expectedQuality: 3},
      {name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 3, quality: 0, expectedQuality: 3},
      {name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality: 0, expectedQuality: 0},
      {name: "Backstage passes to a TAFKAL80ETC concert", sellIn: -2, quality: 0, expectedQuality: 0},
    ]
    testData.forEach(({name, sellIn, quality, expectedQuality}) => {
      it(`Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less for name: ${name}, Selling: ${sellIn}, Quality: ${quality}`, () => {
        const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);

        const items = gildedRose.updateQuality();

        expect(items[0]).to.deep.equal({
          name, sellIn: sellIn - 1, quality: expectedQuality
        });
      })
    })

    it('quality should never exceed 50', () => {
      const gildedRose = new GildedRose([new Item('Aged Brie', 0, 49)]);

      const items = gildedRose.updateQuality();

      expect(items[0]).to.deep.equal({
        name: 'Aged Brie',
        sellIn: -1,
        quality: 50
      });
    });
  });
});
