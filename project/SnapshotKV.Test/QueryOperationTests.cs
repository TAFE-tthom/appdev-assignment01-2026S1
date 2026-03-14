namespace SnapshotKV.Test;

public class QueryOperationsTest
{

    [Fact]
    public void Test_EmptyKeys_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil.ValidateResults(
            switchBoard.ListKeys(),
            InternalSnapshotQueryResult.Make()
                .SetCommand("ListKeys")
                .SetResults(new int[]{})
                .SetRecKey(null)
                .SetSuccess(true)
                .Build()
        );
    }

    [Fact]
    public void Test_SetEntry_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil.ValidateResults(
            switchBoard.SetEntry(
                1,
                new int[] {6, 5, 4}
            ),
            InternalSnapshotQueryResult.Make()
                .SetCommand("SetEntry")
                .SetRecKey(1)
                .SetResults(new int[]{6, 5, 4})
                .SetSuccess(true)
                .Build()
        );

        SnapshotTestUtil.ValidateResults(
            switchBoard.ListKeys(),
            InternalSnapshotQueryResult.Make()
                .SetCommand("ListKeys")
                .SetResults(new int[]{ 1 })
                .SetRecKey(null)
                .SetSuccess(true)
                .Build()
        );
    }

    [Fact]
    public void Test_SetEntrysWithGet_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil.ValidateResults(
            switchBoard.SetEntry(
                1,
                new int[] {6, 5, 4}
            ),
            InternalSnapshotQueryResult.Make()
                .SetCommand("SetEntry")
                .SetRecKey(1)
                .SetResults(new int[]{6, 5, 4})
                .SetSuccess(true)
                .Build()
        );

        SnapshotTestUtil.ValidateResults(
            switchBoard.ListKeys(),
            InternalSnapshotQueryResult.Make()
                .SetCommand("ListKeys")
                .SetResults(new int[]{ 1 })
                .SetRecKey(null)
                .SetSuccess(true)
                .Build()
        );
        SnapshotTestUtil.ValidateResults(
            switchBoard.GetEntry(1),
            InternalSnapshotQueryResult.Make()
                .SetCommand("GetEntry")
                .SetResults(new int[]{6, 5, 4})
                .SetRecKey(1)
                .SetSuccess(true)
                .Build()
        );
    }

    [Fact]
    public void Test_SetEntrysWithGet_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil.ValidateResults(
            switchBoard.SetEntry(
                1,
                new int[] {6, 5, 4}
            ),
            InternalSnapshotQueryResult.Make()
                .SetCommand("SetEntry")
                .SetRecKey(1)
                .SetResults(new int[]{6, 5, 4})
                .SetSuccess(true)
                .Build()
        );
        SnapshotTestUtil.ValidateResults(
            switchBoard.SetEntry(
                4,
                new int[] {87, 22, 55}
            ),
            InternalSnapshotQueryResult.Make()
                .SetCommand("SetEntry")
                .SetRecKey(4)
                .SetResults(new int[]{87, 22, 55})
                .SetSuccess(true)
                .Build()
        );


        SnapshotTestUtil.ValidateResults(
            switchBoard.ListKeys(),
            InternalSnapshotQueryResult.Make()
                .SetCommand("ListKeys")
                .SetResults(new int[]{ 1, 4 })
                .SetRecKey(null)
                .SetSuccess(true)
                .Build()
        );

        SnapshotTestUtil.ValidateResults(
            switchBoard.GetEntry(1),
            InternalSnapshotQueryResult.Make()
                .SetCommand("GetEntry")
                .SetResults(new int[]{6, 5, 4})
                .SetRecKey(1)
                .SetSuccess(true)
                .Build()
        );
    }


    [Fact]
    public void Test_SetEntrysWithGet_3()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(4,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(7,
                new int[] {9, 9}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 9, 9 })
                    .SetRecKey(7)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(4))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(7))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 9, 9 })
                    .SetRecKey(7)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }


    [Fact]
    public void Test_SetEntrysWithRemove_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(4,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(7,
                new int[] {9, 9}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 9, 9 })
                    .SetRecKey(7)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.RemoveEntry(4))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("RemoveEntry")
                    .SetResults(new int[]{ })
                    .SetRecKey(4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.RemoveEntry(7))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("RemoveEntry")
                    .SetResults(new int[]{ })
                    .SetRecKey(7)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_SetEntrysWithRemove_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(10,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.RemoveEntry(10))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("RemoveEntry")
                    .SetResults(new int[]{ })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    
    [Fact]
    public void Test_SetEntrysWithRemove_3()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(10,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(55,
                new int[]{88, 99, 11}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 88, 99, 11 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.RemoveEntry(10))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("RemoveEntry")
                    .SetResults(new int[]{ })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.RemoveEntry(55))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("RemoveEntry")
                    .SetResults(new int[]{ })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    
    [Fact]
    public void Test_SetEntryView_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(10,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(55,
                new int[]{88, 99, 11}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 88, 99, 11 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.View(10, 0, 1))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("View")
                    .SetResults(new int[]{ 6, 4 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }

    [Fact]
    public void Test_SetEntryView_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(10,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(55,
                new int[]{88, 99, 11, 90, 98, 102}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 88, 99, 11, 90, 98, 102 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.View(55, 2, 5))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("View")
                    .SetResults(new int[]{ 11, 90, 98, 102 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_Append_Get_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.Append(10,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Append")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.Append(10,
                new int[]{88, 99, 11, 90, 98, 102}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Append")
                    .SetResults(new int[]{ 6, 4, 7, 88, 99, 11, 90, 98, 102 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(10))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 6, 4, 7, 88, 99, 11, 90, 98, 102 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_Append_Get_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(10,
                new int[] {1, 2, 3}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 1, 2, 3 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.Append(10,
                new int[]{ 8, 9, 10 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Append")
                    .SetResults(new int[]{ 1, 2, 3, 8, 9, 10 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(10))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 1, 2, 3, 8, 9, 10 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_Push_Get_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.Push(10,
                new int[] {6, 4, 7}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Push")
                    .SetResults(new int[]{ 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.Push(10,
                new int[]{88, 99, 11, 90, 98, 102}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Push")
                    .SetResults(new int[]{ 88, 99, 11, 90, 98, 102, 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(10))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 88, 99, 11, 90, 98, 102, 6, 4, 7 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_Push_Get_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(10,
                new int[] {1, 2, 3}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 1, 2, 3 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.Push(10,
                new int[]{ 8, 9, 10 }))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Push")
                    .SetResults(new int[]{ 8, 9, 10, 1, 2, 3 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(10))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(new int[]{ 8, 9, 10, 1, 2, 3 })
                    .SetRecKey(10)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
    [Fact]
    public void Test_MakeWatcher_ViewWatcher_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(55,
                new int[]{88, 99, 11, 90, 98, 102}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 88, 99, 11, 90, 98, 102 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.MakeWatcher(55, 2, 5))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("MakeWatcher")
                    .IgnoreResults()
                    .IgnoreRecKey()
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.ViewWatcher(1))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("ViewWatcher")
                    .SetResults(new int[]{ 11, 90, 98, 102 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }

    [Fact]
    public void Test_MakeWatcher_ViewWatcher_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(55,
                new int[]{88, 99, 11, 90, 98, 102}))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(new int[]{ 88, 99, 11, 90, 98, 102 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.MakeWatcher(55, 1, 5))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("MakeWatcher")
                    .IgnoreResults()
                    .IgnoreRecKey()
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.ViewWatcher(1))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("ViewWatcher")
                    .SetResults(new int[]{ 99, 11, 90, 98, 102 })
                    .SetRecKey(55)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
}
