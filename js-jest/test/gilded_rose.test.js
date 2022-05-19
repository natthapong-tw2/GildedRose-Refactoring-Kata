const { Shop, Item } = require("../src/gilded_rose");

describe("Item", function() {
  it("should create a new Item", function() {
    const item = new Item("foo", 0, 0);
    expect(item).toEqual({
      name: "foo",
      sellIn: 0,
      quality: 0
    });
  });

  it("should create an invalid Item if not all args are supplied", function() {
    const item = new Item(0, 0);
    expect(item).toEqual({
      name: 0,
      sellIn: 0,
      quality: undefined
    });
  });
});

describe("Shop", function() {
  describe("General", () => {
    it("should add an item to the store with name 'foo'", function() {
      const gildedRose = new Shop([new Item("foo", 0, 0)]);
      expect(gildedRose.items[0].name).toBe("foo");
    });
  });

  it("should not throw when run 'updateQuality' with one item in the store", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    expect(() => gildedRose.updateQuality()).not.toThrow();
  });

  describe("Regular Item", () => {
    it("'sellIn' and 'quality' should both decrease by 1 if 'sellIn' > 0 and 'quality' > 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 1)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(0);
    });

    it("'quality' should not decrease below 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(0);
    });

    it("'sellIn' should decrease below 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 0)]);
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(0);
    });

    it("'sellIn' should decrease below 0, but 'quality' should not decrease below 0", function() {
      const gildedRose = new Shop([new Item("foo", 1, 0)]);
      gildedRose.updateQuality();
      gildedRose.updateQuality();
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-2);
      expect(items[0].quality).toBe(0);
    });

    it("when 'sellIn', < 0 'quality' should decrease by 2 each day", function() {
      const gildedRose = new Shop([new Item("foo", 0, 10)]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(8);
    });
  });

});
