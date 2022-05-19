const { Shop, Item } = require("../src/gilded_rose");

const agedBrie = "Aged Brie";
const backStage = "Backstage passes to a TAFKAL80ETC concert";
const sulfuras = "Sulfuras, Hand of Ragnaros";

describe("Gilded Rose", function () {
  describe("First if block", () => {
    it("should foo", function () {
      const gildedRose = new Shop([new Item("foo", 0, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].name).toBe("foo");
    });
    it("should reduce the quality, when name is not equal to (Aged Brie) or (Backstage passes to a TAFKAL80ETC concert) or (Sulfuras, Hand of Ragnaros)", () => {
      const item = new Item("foo", 0, 1);
      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    });
    it("should not reduce the quality, when the name is sulfuras", () => {
      const item = new Item(sulfuras, 0, 1);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(1);
    });
  });
  describe("Name not equal sulfuras", () => {
    it("should reduce sellIn by one and reduce quality by two, when sellIn less than one", () => {
      const item = new Item("bar", 0, 49);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(47);
    });
    it("should reduce sellIn by one and reduce quality by one, when sellIn more than one", () => {
      const item = new Item("bar", 1, 49);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(0);
      expect(items[0].quality).toBe(48);
    });
  });
  describe("Name equal sulfuras", () => {
    it("quality and sellIn should not change", () => {
      const item = new Item(sulfuras, -1, 49);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-1);
      expect(items[0].quality).toBe(49);
    });
  });
  describe("Name equal backStage", () => {
    it("quality should increase one, when sellIn more than 11 and quality less than 50", () => {
      const item = new Item(backStage, 12, 48);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(49);
    });
    it("quality should increase one, when sellIn less than 11 and quality eqaul 49", () => {
      const item = new Item(backStage, 10, 49);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    });
    it("quality should increase two, when sellIn less than 11 and quality less than 50 after increase by one", () => {
      const item = new Item(backStage, 10, 48);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    });
    it("quality should increase three, when sellIn less than 6 and quality less than 50 after increase by two", () => {
      const item = new Item(backStage, 5, 47);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    });
    it("quality should increase two, when sellIn less than 6 and quality equal 50 after increase by two", () => {
      const item = new Item(backStage, 5, 48);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(50);
    });
    it("quality should equal zero, when sellIn less than 0", () => {
      const item = new Item(backStage, -1, 48);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    });
    it("quality should equal zero, when sellIn equal 0", () => {
      const item = new Item(backStage, 0, 50);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    });
  });
  describe("Name equal agedBrie", () => {
    it("quality should increase by two, when quality equal 49 and sellIn less than 0", () => {
      const item = new Item(agedBrie, -1, 49);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-2);
      expect(items[0].quality).toBe(50);
    });
    it("quality should increase by two, when quality less than 50 and sellIn less than 0", () => {
      const item = new Item(agedBrie, -1, 5);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-2);
      expect(items[0].quality).toBe(7);
    });
    it("quality should increase by two, when quality greater than 50 and sellIn less than 0", () => {
      const item = new Item(agedBrie, -1, 50);

      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].sellIn).toBe(-2);
      expect(items[0].quality).toBe(50);
    });
  });
});
