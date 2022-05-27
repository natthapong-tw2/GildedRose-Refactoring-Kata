const { Shop, Item } = require("../src/gilded_rose");

describe("Gilded Rose", function() {
  it("should foo", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe("foo");
  });

  it('should not have negative quality', () => {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0]).toEqual({ name: "foo", sellIn: -1, quality: 0});
  })
});

describe("Aged brie", () => {
  it('should have one quality', () => {
    const ageBrie = new Shop([new Item("Aged Brie", 1, 0)]);
    const items = ageBrie.updateQuality();
    expect(items[0]).toEqual({ name: "Aged Brie", sellIn: 0, quality: 1});
  })

  it('should increase the quality twice if the sell date was already passed', () => {
    const ageBrie = new Shop([new Item("Aged Brie", 0, 0)]);
    const items = ageBrie.updateQuality();
    expect(items[0]).toEqual({ name: "Aged Brie", sellIn: -1, quality: 2});
  })

  it('should not increasing quality if its exceed than 50', () => {
    const gildedRose = new Shop([new Item("Aged Brie", 0, 50)]);
    const items = gildedRose.updateQuality();
    expect(items[0]).toEqual({ name: "Aged Brie", sellIn: -1, quality: 50});
  })
})

describe("Sulfuras, Hand of Ragnaros", () => {
  test.each( 
    [
      { name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 1},
      { name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 50},
      { name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 51},
  ])('should never be sold or decrease in quality', item => {
      const sulfuras = new Shop([item]);
      const items = sulfuras.updateQuality();
      expect(items[0]).toEqual({ name: "Sulfuras, Hand of Ragnaros", sellIn: item.sellIn, quality: item.quality});
  })
})

describe("Backstage passes to a TAFKAL80ETC concert", () => {
  it("should increase quality by three as the date has approaches 5 days or less", () => {
    const backstage = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 0)]);
    const items = backstage.updateQuality();
    expect(items[0]).toEqual({ name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 4, quality: 3});
  });

  test.each([
    { name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 8, quality: 4},
    { name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 6, quality: 8},
    { name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 10, quality: 0}
  ])('should increase quality by two as the date has approaches 10 days or less', item => {
      const backstage = new Shop([new Item(item.name, item.sellIn, item.quality)]);
      const items = backstage.updateQuality();
      expect(items[0]).toEqual({ name: item.name, sellIn: item.sellIn - 1, quality: item.quality + 2});
  })

  it("should have zero quality if the performance already end", () => {
    const backstage = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 5)]);
    const items = backstage.updateQuality();
    expect(items[0]).toEqual({ name: "Backstage passes to a TAFKAL80ETC concert", sellIn: -1, quality: 0});
  })
})