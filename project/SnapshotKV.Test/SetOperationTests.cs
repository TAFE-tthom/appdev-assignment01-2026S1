namespace SnapshotKV.Test;

public class SetOperationsTest
{
    [Fact]
    public void Test_Sort_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID = 70;
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID,
                new int[] {6, 4, 7, 10, 3, 1}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7, 10, 3, 1 })
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.Sort(ID))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("PartialSort")
					.IgnoreResults()
					.IgnoreRecKey()
                    .SetSuccess(true)
                    .Build())
			.Next()
			.Next()
            .SetOperation(() => switchBoard.GetEntry(ID))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 1, 3, 4, 6, 7, 10 })
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }

    [Fact]
    public void Test_Union_1_NoDup()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID1 = 10;
		int ID2 = 20;
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID1,
                new int[] {4, 7, 8 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 4, 7, 8})
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(ID2,
                new int[] {10, 11, 12 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 10, 11, 12 })
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.Union(ID1, ID2))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Union")
					.IgnoreRecKey()
					.SetResults(new int[]{4, 7, 8, 10, 11, 12})

                    .SetSuccess(true)
                    .Build())
			.Next()
            .Run();

    }
    [Fact]
    public void Test_Union_2_Dup()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID1 = 10;
		int ID2 = 20;
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID1,
                new int[] {4, 7, 8, 10, 11 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 4, 7, 8})
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(ID2,
                new int[] {10, 11, 12 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 10, 11, 12, 13 })
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.Union(ID1, ID2))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Union")
					.IgnoreRecKey()
					.SetResults(new int[]{4, 7, 8, 10, 11, 12, 13})

                    .SetSuccess(true)
                    .Build())
			.Next()
            .Run();

    }
    [Fact]
    public void Test_Intersection_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID1 = 10;
		int ID2 = 20;
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID1,
                new int[] {4, 7, 8, 10, 11 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 4, 7, 8})
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(ID2,
                new int[] {10, 11, 12 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 10, 11, 12, 13 })
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.Intersect(ID1, ID2))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Intersection")
					.IgnoreRecKey()
					.SetResults(new int[]{ 10, 11 })
                    .SetSuccess(true)
                    .Build())
			.Next()
            .Run();

    }
    [Fact]
    public void Test_Intersection_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID1 = 10;
		int ID2 = 20;
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID1,
                new int[] {4, 7, 8  }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 4, 7, 8})
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(ID2,
                new int[] {10, 11, 12 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 4, 7, 10, 11, 12, 13 })
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.Intersect(ID1, ID2))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Intersection")
					.IgnoreRecKey()
					.SetResults(new int[]{ 4, 7 })
                    .SetSuccess(true)
                    .Build())
			.Next()
            .Run();

    }
    [Fact]
    public void Test_Sort_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID = 89;
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID,
                new int[] {6, 4, 7, 10, 3, 1}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7, 10, 3, 1, -10, 90, 2, 99, 65 })
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.Sort(ID))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("PartialSort")
					.IgnoreResults()
					.IgnoreRecKey()
                    .SetSuccess(true)
                    .Build())
			.Next()
            .SetOperation(() => switchBoard.GetEntry(ID))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ -10, 1, 2, 3, 4, 6, 7, 10, 65, 90, 99 })
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_PartialSort_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID = 67;
		
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID,
                new int[] {6, 7, 10, 4, 65 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 7, 10, 4, 65 })
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.PartialSort(ID, 1, 3))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("PartialSort")
					.IgnoreResults()
					.IgnoreRecKey()
                    .SetSuccess(true)
                    .Build())
			.Next()
            .SetOperation(() => switchBoard.GetEntry(ID))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 6, 4, 7, 10, 65})
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }

	[Fact]
    public void Test_PartialSort_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID = 34;
		
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(ID,
                new int[] {6, 4, 7, 10, 3, 1, 77, 12, 28}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[] {6, 4, 7, 10, 3, 1, 77, 12, 28})
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
			.SetOperation(() => switchBoard.PartialSort(ID, 3, 7))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("PartialSort")
					.IgnoreResults()
					.IgnoreRecKey()
                    .SetSuccess(true)
                    .Build())
			.Next()
            .SetOperation(() => switchBoard.GetEntry(ID))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 6, 4, 7, 1, 3, 10, 12, 77, 28})
                    .SetRecKey(ID)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
}
