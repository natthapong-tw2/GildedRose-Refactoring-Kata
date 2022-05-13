const { Shop, Item } = require("../src/gilded_rose");

const agedBrie = 'Aged Brie'
const backStage = 'Backstage passes to a TAFKAL80ETC concert'
const sulfuras = 'Sulfuras, Hand of Ragnaros'

describe("Gilded Rose", function () {
  describe('First if block', () => {
    it("should foo", function () {
      const gildedRose = new Shop([new Item("foo", 0, 0)]);
      const items = gildedRose.updateQuality();
      expect(items[0].name).toBe("foo");
    });
    it('should reduce the quality, when name is not equal to (Aged Brie) or (Backstage passes to a TAFKAL80ETC concert) or (Sulfuras, Hand of Ragnaros)', () => {
      const item = new Item("foo", 0, 1)
      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(0);
    })
    it('should not reduce the quality, when the name is sulfuras', ()=> {
      const item = new Item(sulfuras, 0, 1)
      
      const gildedRose = new Shop([item]);
      const items = gildedRose.updateQuality();
      expect(items[0].quality).toBe(1);
    })
  })
});
