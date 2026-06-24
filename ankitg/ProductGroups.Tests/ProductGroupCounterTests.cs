using ProductGroups;

namespace ProductGroups.Tests;

public class ProductGroupCounterTests
{
    private readonly ProductGroupCounter _sut = new();

    // TC-01: FR-1, FR-2, AC-1 — Basic grouping with transitivity
    [Fact]
    public void CountGroups_BasicTransitivity_ReturnsCorrectGroupCount()
    {
        var result = _sut.CountGroups(5, [(1, 2), (2, 3), (4, 5)]);
        Assert.Equal(2, result);
    }

    // TC-02: FR-3, AC-2 — No constraints, each product is its own group
    [Fact]
    public void CountGroups_NoConstraints_ReturnsN()
    {
        var result = _sut.CountGroups(5, []);
        Assert.Equal(5, result);
    }

    // TC-03: FR-1, FR-2, AC-3 — All products merge into one group
    [Fact]
    public void CountGroups_AllMerged_ReturnsOne()
    {
        var result = _sut.CountGroups(3, [(1, 2), (2, 3)]);
        Assert.Equal(1, result);
    }

    // TC-04: FR-4, AC-4 — Zero products
    [Fact]
    public void CountGroups_ZeroProducts_ReturnsZero()
    {
        var result = _sut.CountGroups(0, []);
        Assert.Equal(0, result);
    }

    // TC-05: FR-5, AC-5 — ID above N throws ArgumentException
    [Fact]
    public void CountGroups_IdAboveN_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _sut.CountGroups(3, [(1, 4)]));
    }

    // TC-06: FR-5 — ID = 0 throws ArgumentException
    [Fact]
    public void CountGroups_IdZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _sut.CountGroups(3, [(0, 1)]));
    }

    // TC-07: FR-5 — Negative ID throws ArgumentException
    [Fact]
    public void CountGroups_NegativeId_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _sut.CountGroups(3, [(-1, 2)]));
    }

    // TC-08: FR-6, AC-6 — Duplicate constraints silently ignored
    [Fact]
    public void CountGroups_DuplicateConstraints_IgnoresDuplicates()
    {
        var result = _sut.CountGroups(3, [(1, 2), (1, 2)]);
        Assert.Equal(2, result);
    }

    // TC-09: FR-6, AC-7 — Self-referential constraint silently ignored
    [Fact]
    public void CountGroups_SelfReferentialConstraint_Ignored()
    {
        var result = _sut.CountGroups(3, [(1, 1)]);
        Assert.Equal(3, result);
    }

    // TC-10: FR-3 — Single product, no constraints
    [Fact]
    public void CountGroups_SingleProduct_ReturnsOne()
    {
        var result = _sut.CountGroups(1, []);
        Assert.Equal(1, result);
    }

    // TC-11: FR-4, FR-6 — Single product with self-ref constraint
    [Fact]
    public void CountGroups_SingleProductSelfRef_ReturnsOne()
    {
        var result = _sut.CountGroups(1, [(1, 1)]);
        Assert.Equal(1, result);
    }

    // TC-12: FR-1, FR-2 — Long chain, all in one group
    [Fact]
    public void CountGroups_LongChain_ReturnsOne()
    {
        var result = _sut.CountGroups(4, [(1, 2), (2, 3), (3, 4)]);
        Assert.Equal(1, result);
    }

    // TC-13: FR-1 — Two disjoint pairs
    [Fact]
    public void CountGroups_TwoDisjointPairs_ReturnsTwo()
    {
        var result = _sut.CountGroups(4, [(1, 2), (3, 4)]);
        Assert.Equal(2, result);
    }

    // TC-14: FR-1, FR-3 — One constraint, one isolated product
    [Fact]
    public void CountGroups_OneConstraintOneIsolated_ReturnsThree()
    {
        var result = _sut.CountGroups(4, [(1, 2)]);
        Assert.Equal(3, result);
    }
}
