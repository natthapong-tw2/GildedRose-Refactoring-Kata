const {Shop, Item} = require("../src/gilded_rose");

describe("Item", function() {
  it("should succefully create a new Item", function() {
    const item = new Item("foo", 0, 0);
    expect(item).toEqual({
      name: "foo",
      sellIn: 0,
      quality: 0,
    });
  });

  it("should succefully create an invalid Item if not all args are supplied", function() {
    const item = new Item(0, 0);
    expect(item).toEqual({
      name: 0,
      sellIn: 0,
      quality: undefined,
    });
  });
})

describe("Shop", function() {
  it("should succefully add an item to the store with name 'foo'", function() {
    const gildedRose = new Shop([new Item("foo", 0, 0)]);
    expect(gildedRose.items[0].name).toBe("foo");
  });

  // it("should succefully add an item to the store with name 'foo'", function() {
  //   const gildedRose = new Shop([new Item("foo", 0, 0)]);
  //   const items = gildedRose.updateQuality();
  //   expect(items[0].name).toBe("foo");
  // });
});
