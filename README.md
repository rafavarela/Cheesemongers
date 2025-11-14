# 🧀 **CheeseMongers Kata – Refactored Solution**

This project is a refactoring kata based on “Software Cheesemongers”, a fictional company that sells software to small dairy shops in Italy.

The legacy code responsible for updating cheese inventory had grown overly complex, making future changes risky and difficult. Your mission was:

* Add support for a new cheese (“Ricotta”)
* Improve code quality without changing existing behavior
* Preserve the original `Item` class
* Ensure all unit tests pass
* Introduce maintainability through design patterns

This repository contains the fully refactored solution.

---

## 🧀 **Problem Summary**

Each cheese item has:

* **ValidByDays** — days left before expiration
* **Quality** — current quality score (0–100)

The system updates all cheese items daily, following these rules:

### **Base Rules**
* Normal cheeses lose 1 quality per day.
* After expiration (**ValidByDays** < 0), normal cheeses lose $5\times$ faster (so $-5$ total: $-1$ early, $-4$ late).
* **Quality** never goes below 0.
* **Quality** never exceeds 100.

### **Special Items**

| Cheese Type | Behavior |
| :--- | :--- |
| **Parmigiano Regiano** | Quality increases as it ages. |
| **Caciocavallo Podolico** | Legendary cheese — never changes. |
| **Tasting with Chef Massimo** | Event item: <br> - +1 normally <br> - +3 when $\le$14 days <br> - +5 when $\le$7 days <br> - Drops to 0 after the event |
| **Ricotta (new!)** | Spoils very fast — quality degrades $3\times$ faster than normal. |

---

## 🧩 **Refactoring Goals**

* ✔ **Improve readability**
* ✔ **Remove deep nested conditionals**
* ✔ **Keep original behavior** (tests ensure that)
* ✔ **Add Ricotta support**
* ✔ **Apply SOLID principles**
* ✔ **Implement the Strategy Pattern**

This was accomplished by extracting each cheese’s behavior into its own strategy class, eliminating the need for giant if/else blocks.

---

## 🏗 **Architecture Overview**

### 1. **CheeseMongersItem (unchanged structure)**

The `Item` class still contains:

```csharp
public string Name { get; set; }
public int ValidByDays { get; set; }
public int Quality { get; set; }
```
### 2. **Strategy Pattern**

Each cheese delegates behavior to a strategy:

IUpdateStrategy
    ├── NormalCheeseStrategy
    ├── ParmigianoRegianoStrategy
    ├── CaciocavalloPodolicoStrategy
    ├── TastingWithMassimoStrategy
    └── RicottaStrategy          (new)


### 3. **Strategy Factory**

A simple factory selects the right strategy based on the item name:

StrategyFactory.GetStrategyFor(item.Name);

### 4. **Lazy Strategy Assignment**

To maintain backward compatibility with the original constructor,
UpdateItem() auto-assigns a strategy if missing:

Strategy ??= StrategyFactory.GetStrategyFor(Name);

🧪 Unit Tests

The entire legacy behavior is preserved thanks to a complete test suite built using xUnit, covering:

Normal cheese before/after expiration

Parmigiano quality growth

Event cheese acceleration and post-event drop

Caciocavallo legendary stability

Ricotta accelerated degradation

Quality boundaries (0–100)

ValidByDays decrements

Edge cases

These tests act as a safety net for refactoring and prove functional equivalence.

🧀 Ricotta Implementation

A new strategy was added:

Normal cheese: –1 per day

Ricotta: –3 per day

After expiration: extra deterioration (–4 more like normal items)

Ensuring rules remain consistent with the kata specification.

📂 Folder Structure
/CheeseMongers
    /Model
        CheeseMongersItem.cs
        IUpdateStrategy.cs
        StrategyFactory.cs
        NormalCheeseStrategy.cs
        ParmigianoRegianoStrategy.cs
        TastingWithMassimoStrategy.cs
        CaciocavalloPodolicoStrategy.cs
        RicottaStrategy.cs
    Program.cs

/Tests
    ProgramTests.cs

💡 Key Improvements
✔ Single Responsibility Principle

Each cheese type now encapsulates its own behavior.

✔ Open/Closed Principle

Add new cheeses by adding new strategies — no modification required elsewhere.

✔ Maintainability

The refactor transformed one large, untestable method into a clean, extendable architecture.

✔ Behavior preserved

All original tests pass. Ricotta tests validate the new feature.

🚀 Final Result

The CheeseMongers system is now:

Easier to understand

Easier to extend

Fully tested

Properly designed using Strategy Pattern
