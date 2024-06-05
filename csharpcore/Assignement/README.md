# Experiment how the tests can impact the refactoring

### Goal
Try to refactor all updaters into one in both projects:
### How
Apply Visitor pattern to use polymorphism
> Definition : https://refactoring.guru/design-patterns/visitor
	
### Example
```
public class QualityUpdater
{
	public void UpdateQuality(AgedBrie item) {
		...
	}

	public void UpdateQuality(Sulfuras item) {
		... 
	}

	public void UpdateQuality(BackstagePasses item) {
		...
	}

	public void UpdateQuality(StandardItem item) {
		...
	}
}

public class AgedBrie : Item {
	...
	public void process(QualityUpdater qualityUpdater) {
		qualityUpdate.UpdateQuality(this);
	}
	...
}
```