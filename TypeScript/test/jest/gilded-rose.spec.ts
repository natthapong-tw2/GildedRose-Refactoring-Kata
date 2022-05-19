import { Item, GildedRose } from '@/gilded-rose';

describe('Gilded Rose', () => {
  test.each([
    {name: "foo", sellIn: 0, quality: 0},
  ])('.updateQuality($a, $b)', ({name, sellIn, quality}) => {
    const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe('foo');
  });
});

describe('Aged Brie', () => {
  test.each([
    {name: "Aged Brie", sellIn: 1, quality: 0},
    {name: "Aged Brie", sellIn: 2, quality: 0},
  ])('s the sell by date has not pass, quality increase only one', ({name, sellIn, quality}) => {
    const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
    const items = gildedRose.updateQuality();
    expect(items[0]).toEqual({
      name, sellIn: sellIn -1, quality: quality + 1
    });
  });

  test.each([
    {name: "Aged Brie", sellIn: 0, quality: 0},
    {name: "Aged Brie", sellIn: -1, quality: 0},
  ])('Once the sell by date has passed, quality increase twice as fast', ({name, sellIn, quality}) => {
    const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
    const items = gildedRose.updateQuality();
    expect(items[0]).toEqual({
      name, sellIn: sellIn -1, quality: quality + 2
    });
  });

  it('s quality should never exceed 50', () => {
    const gildedRose = new GildedRose([new Item('Aged Brie', 0, 49)]);

    const items = gildedRose.updateQuality();

    expect(items[0]).toEqual({
      name: 'Aged Brie',
      sellIn: -1,
      quality: 50
    });
  });
});

describe('Expirable products', () => {
  test.each([
    {name: "Honey lemon", sellIn: -2, quality: 3},
  ])('Once the sell by date has passed, Quality degrades twice as fast', ({name, sellIn, quality}) => {
    const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
    const items = gildedRose.updateQuality();
    expect(items[0]).toEqual({
      name, sellIn: -3, quality: 5
    });
  });
});

describe('Legendary item', () => {
  test.each([
    {name: "Sulfuras", sellIn: -1, quality: 0},
    {name: "Sulfuras", sellIn: 0, quality: 1},
    {name: "Sulfuras", sellIn: 1, quality: 50},
    {name: "Sulfuras", sellIn: 1, quality: 51},
    {name: "Sulfuras", sellIn: 2, quality: 80},
  ])('s the sell by date has not pass, quality increase only one', ({name, sellIn, quality}) => {
    const gildedRose = new GildedRose([new Item(name, sellIn, quality)]);
    const items = gildedRose.updateQuality();
    expect(items[0]).toEqual({
      name, sellIn: sellIn - 1, quality
    });
  });

  it('s quality should never exceed 50', () => {
    const gildedRose = new GildedRose([new Item('Aged Brie', 0, 49)]);

    const items = gildedRose.updateQuality();

    expect(items[0]).toEqual({
      name: 'Aged Brie',
      sellIn: -1,
      quality: 50
    });
  });
});


// Note:
// 1. change updateQuality name
// 2. filtering input error, like aged bries start with quality 50, 80
// 3. should we handle CASE sensitives
