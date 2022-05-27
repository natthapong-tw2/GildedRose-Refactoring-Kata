const {Shop, Item} = require("../src/gilded_rose");

describe("Gilded Rose", function() {
  it("should foo", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe("foo");
    expect(items[0].quality).toBe(0);
    expect(items[0].sellIn).toBe(-1);
  });

  it("when 'Aged Brie' and quality less than 50 and sellIn less than 6 should increase quality in 2", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(3);
  });

  it("when 'Aged Brie' and quality less than 50 and sellIn more than 6 should increase quality", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 7, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(2);
  });

  it("when 'Aged Brie' and quality is 50 and sellIn less than 6 should not increase quality", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 0, 50)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  });

  it("when not 'Aged Brie' should descreasee quality ", function() {
    const gildedRose = new Shop([new Item("Not Aged Brie", 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });

  it("when not 'Aged Brie' should descreasee quality ", function() {
    const gildedRose = new Shop([new Item("Not Aged Brie", 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });

  it("when 'Backstage passes to a TAFKAL80ETC concert' and quality less than 50", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 5)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });

  it("when not 'Backstage passes to a TAFKAL80ETC concert' should not descrease quality when 0", function() {
    const gildedRose = new Shop([new Item("Not Backstage passes to a TAFKAL80ETC concert", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });

  it("when 'Sulfuras, Hand of Ragnaros' should not descrease quality", function() {
    const gildedRose = new Shop([new Item("Sulfuras, Hand of Ragnaros", 0, 1)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(1);
  });
});
