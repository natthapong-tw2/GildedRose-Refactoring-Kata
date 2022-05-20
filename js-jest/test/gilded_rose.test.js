const {Shop, Item} = require("../src/gilded_rose");

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
  [
    { name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 1},
    { name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 50},
    { name: "Sulfuras, Hand of Ragnaros", sellIn: 1, quality: 51},
  ].forEach(item => {
    it('should never be sold or decrease in quality', () => {
      const sulfuras = new Shop([item]);
      const items = sulfuras.updateQuality();
      expect(items[0]).toEqual({ name: "Sulfuras, Hand of Ragnaros", sellIn: item.sellIn, quality: item.quality});
    })
  })
})

describe("Backstage passes to a TAFKAL80ETC concert", () => {
  it("should increase quality by three as the date has approaches 5 days or less", () => {
    const backstage = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 0)]);
    const items = backstage.updateQuality();
    expect(items[0]).toEqual({ name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 4, quality: 3});
  })

  it("should increase quality by two as the date has approaches 10 days or less", () => {
    const backstage = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 10, 0)]);
    const items = backstage.updateQuality();
    expect(items[0]).toEqual({ name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 9, quality: 2});
  })

  it("should have zero quality if the performance already end", () => {
    const backstage = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 5)]);
    const items = backstage.updateQuality();
    expect(items[0]).toEqual({ name: "Backstage passes to a TAFKAL80ETC concert", sellIn: -1, quality: 0});
  })
})