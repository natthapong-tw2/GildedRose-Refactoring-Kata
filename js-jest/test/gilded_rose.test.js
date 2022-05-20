const {Shop, Item} = require("../src/gilded_rose");

describe("Gilded Rose", function() {
  it("should foo", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe("foo");
  });
});

describe("Sulfuras never changes in quality", function() {
  it("Sulfuras quality should remain the same", function() {
    const gildedRose = new Shop([new Item("Sulfuras, Hand of Ragnaros", 0, 80)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(80);
  });
});

describe("Aged Brie increases in quality as sellIn decreases", function() {
  it("Aged Brie quality should +1, if quality < 50, sellIn > 0", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 1, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(11);
  })
  it("Aged Brie quality should +2, if quality < 50, sellIn <= 0", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 0, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(12);
  })
  it("Aged Brie quality should not increase beyond 50", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 0, 50)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })
})

describe("Backstage passes quality changes based on sellIn", function() {
  it("Backstage passes quality should +1, if quality < 50, sellIn >= 11", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 11, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(11);
  });
  it("Backstage passes quality should +2, if quality < 50, sellIn < 11", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 10, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(12);
  });
  it("Backstage passes quality should +3, if quality < 50, sellIn < 6", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(13);
  });
  it("Backstage passes quality should be 0, if quality <= 50, sellIn <= 0", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });
  it("Backstage passes quality should not increase beyond 50", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 50)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(50);
  })
});

describe("All other items quality changes based on sellIn", function() {
  it("All other items quality should -1, if quality <= 50, sellIn > 0", function() {
    const gildedRose = new Shop([new Item("foo", 1, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(9);
  });
  it("All other items quality should -2, if quality <= 50, sellIn <= 0", function() {
    const gildedRose = new Shop([new Item("foo", 0, 10)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(8);
  });
});

describe("Items quality is never negative", function() {
  it("Aged Brie quality is never negative", function() {
    const gildedRose = new Shop([new Item("Aged Brie", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(2);
  });
  it("Backstage passes quality is never negative", function() {
    const gildedRose = new Shop([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });
  it("All other items quality is never negative", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].quality).toBe(0);
  });
});

describe("Items sellIn gets updated", function() {
  describe("Sulfuras sellIn gets updated correctly", function() {
    it("Sulfuras sellIn does not get updated", function() {
      const gildedRose = new Shop([new Item("Sulfuras, Hand of Ragnaros", 10, 80)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(10);
    })
  })
  describe("Non-Sulfuras items sellIn should get updated by -1", function() {
    const cases = [["Aged Brie", 10, 10], ["Backstage passes to a TAFKAL80ETC concert", 10, 10], ["foo", 10, 10]];

    it.each(cases)("All non-Sulfuras items sellIn should -1", function(name, sellIn, quality) {
      const gildedRose = new Shop([new Item(name, sellIn, quality)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(9);
    })
  })
})


// filter by name, then quality, then sellIn

  // Sulfuras -> quality always 80, no need to update
  // Aged Brie -> if quality < 50, sellIn >= 0, quality +1
  //                               sellIn < 0, quality +2
  // Backstage passes -> if quality < 50, sellIn < 11, quality +2
  //                                      sellIn < 6, quality +3
  //                                      sellIn < 0 , quality = 0
  // All other items -> if quality > 0, quality -1
  //                                    sellIn < 0, quality -2
  // All items -> quality always >= 0
