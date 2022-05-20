const {Shop, Item} = require("../src/gilded_rose");

describe("Gilded Rose", function() {
  it("should foo", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe("foo");
  });
});

describe("Aged brie", () => {
  it('should have one quality', () => {
    const ageBrie = new Shop([new Item("Aged Brie", 1, 0)]);
    const items = ageBrie.updateQuality();
    expect(items[0]).toEqual({ name: "Aged Brie", sellIn: 0, quality: 1});
  })

  it('should increase quality to two if sell date is passed', () => {
    const ageBrie = new Shop([new Item("Aged Brie", 0, 0)]);
    const items = ageBrie.updateQuality();
    expect(items[0]).toEqual({ name: "Aged Brie", sellIn: -1, quality: 2});
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
  it("should increase quality as the date has approaches", () => {
    const backstage = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 1, 0)]);
    const items = backstage.updateQuality();
    expect(items[0]).toEqual({ name: "Backstage passes to a TAFKAL80ETC concert", sellIn: 0, quality: 3});
  })
})