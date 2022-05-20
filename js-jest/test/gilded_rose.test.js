const {Shop, Item} = require("../src/gilded_rose");

describe("Gilded Rose", function() {
  it("should foo", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    const items = gildedRose.updateQuality();
    expect(items[0].name).toBe("foo");
  });
});

describe("Aged brie", () => {
  it('it should have one quality', () => {
    const ageBrie = new Shop([new Item("Aged Brie", 1, 0)]);
    const items = ageBrie.updateQuality();
    expect(items[0]).toEqual({ name: "Aged Brie", sellIn: 0, quality: 1});
  })
})
