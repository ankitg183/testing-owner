# Requirements: Product Group Counter

## Feature Summary

Given N products (labeled 1 to N) and M constraints (pairs of product IDs indicating they must ship together), compute the number of independent product groups formed by those constraints.

---

## Functional Requirements

### FR-1: Core Computation
- The feature shall accept an integer `N` and a list of constraint pairs `(a, b)`.
- It shall return the count of independent product groups formed by applying all constraints transitively.
- Example: N=5, constraints=[(1,2),(2,3),(4,5)] → 2 groups ({1,2,3} and {4,5}).

### FR-2: Transitivity
- Grouping is transitive. If (1,2) and (2,3) are constraints, products 1, 2, and 3 belong to the same group.

### FR-3: No Constraints (M = 0)
- If no constraints are provided, each product is its own group.
- Result shall equal N.

### FR-4: Zero Products (N = 0)
- If N = 0, the result shall be 0.

### FR-5: Invalid Product IDs
- If any constraint references a product ID outside the range [1, N], an `ArgumentException` shall be thrown.

### FR-6: Duplicate or Self-Referential Constraints
- Duplicate pairs (e.g., (1,2) appearing more than once) shall be silently ignored.
- Self-referential pairs (e.g., (1,1)) shall be silently ignored.

---

## Non-Functional Requirements

### NFR-1: Language
- Implementation shall be in **C#**.

### NFR-2: Deliverable Form
- The feature shall be delivered as a **class with a public method** (library style), not a console application.

### NFR-3: Scale
- N and M are small (< 1,000). No special large-scale optimizations required.

---

## Interface (Proposed Signature)

```csharp
public class ProductGroupCounter
{
    public int CountGroups(int n, IEnumerable<(int, int)> constraints);
}
```

---

## Acceptance Criteria

| # | Scenario | Input | Expected Output |
|---|----------|-------|-----------------|
| AC-1 | Basic grouping with transitivity | N=5, [(1,2),(2,3),(4,5)] | 2 |
| AC-2 | No constraints | N=5, [] | 5 |
| AC-3 | All products in one group | N=3, [(1,2),(2,3)] | 1 |
| AC-4 | Zero products | N=0, [] | 0 |
| AC-5 | Invalid ID in constraint | N=3, [(1,4)] | ArgumentException |
| AC-6 | Duplicate constraints | N=3, [(1,2),(1,2)] | 2 |
| AC-7 | Self-referential constraint | N=3, [(1,1)] | 3 |
