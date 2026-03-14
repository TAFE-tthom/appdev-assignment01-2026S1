namespace SnapshotKV.Test;

using System.IO;

public class DatabaseOperationTests
{

	private void DeleteFileIfExists(string path) {
		try {
			File.Delete(path);
		}
		catch(Exception e)
		{
			// Ignore
		}
	}

    [Fact]
    public void Test_SaveLoad_1()
    {

        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

		int ID1 = 11;
		int ID2 = 22;
		int ID3 = 33;
		int[] Values1 = { 1, 2, 3 };
		int[] Values2 = { 4, 5, 6 };
		int[] Values3 = { 8, 9, 10 };
		string path = "./db1.csv";

		DeleteFileIfExists(path);
		
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID1,
					Values1
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values1)
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID2,
					Values2
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values2)
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID3,
					Values3
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values3)
                    .SetRecKey(ID3)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetDBOperation(
                () => switchBoard.Save(path))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Save")
					.IgnoreRecKey()
					.IgnoreResults()
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetDBOperation(
                () => switchBoard.Load(path))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Load")
					.IgnoreRecKey()
					.IgnoreResults()
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID1
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values1)
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID2
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values2)
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID3
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values3)
                    .SetRecKey(ID3)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();
    }
	
    [Fact]
    public void Test_SaveLoad_2()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();

		int ID1 = 11;
		int ID2 = 22;
		int ID3 = 33;
		int ID4 = 44;
		int[] Values1 = { 1, 2, 3 };
		int[] Values2 = { 4, 5, 6 };
		int[] Values3 = { 8, 9, 10 };
		int[] Values4 = { 11, 12, 13 };
		string path = "./db2.csv";
		
		DeleteFileIfExists(path);
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID1,
					Values1
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values1)
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID2,
					Values2
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values2)
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID3,
					Values3
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values3)
                    .SetRecKey(ID3)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID4,
					Values4
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values4)
                    .SetRecKey(ID4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetDBOperation(
                () => switchBoard.Save(path))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Save")
					.IgnoreRecKey()
					.IgnoreResults()
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetDBOperation(
                () => switchBoard.Load(path))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("Load")
					.IgnoreRecKey()
					.IgnoreResults()
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID1
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values1)
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID2
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values2)
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID3
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values3)
                    .SetRecKey(ID3)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID4
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values4)
                    .SetRecKey(ID4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .Run();

    }
	
    [Fact]
    public void Test_CommitCheckout_1()
    {
        SnapshotSwitchboard switchBoard = new SnapshotSwitchboard();
		int ID1 = 11;
		int ID2 = 22;
		int ID3 = 33;
		int ID4 = 44;
		int[] Values1 = { 1, 2, 3 };
		int[] Values2 = { 4, 5, 6 };
		int[] Values3 = { 8, 9, 10 };
		int[] Values4 = { 11, 12, 13 };
        SnapshotTestUtil
            .Start()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID1,
					Values1
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values1)
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID2,
					Values2
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values2)
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID3,
					Values3
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values3)
                    .SetRecKey(ID3)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetDBOperation(
                () => switchBoard.Commit())
            .SetExpected(
                InternalSnapshotQueryResult.MakeDB("Commit", true))
            .Next()
            .SetOperation(
                () => switchBoard.SetEntry(
					ID4,
					Values4
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("SetEntry")
                    .SetResults(Values4)
                    .SetRecKey(ID4)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetDBOperation(
                () => switchBoard.Checkout(1))
            .SetExpected(
                InternalSnapshotQueryResult.MakeDB("Checkout", true))
            .SetOperation(
                () => switchBoard.GetEntry(
					ID1
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values1)
                    .SetRecKey(ID1)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID2
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values2)
                    .SetRecKey(ID2)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID3
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
                    .SetResults(Values3)
                    .SetRecKey(ID3)
                    .SetSuccess(true)
                    .Build())
            .Next()
            .SetOperation(
                () => switchBoard.GetEntry(
					ID4
				))
            .SetExpected(
                InternalSnapshotQueryResult.Make()
                    .SetCommand("GetEntry")
					.IgnoreRecKey()
					.IgnoreResults()
                    .SetSuccess(false)
                    .Build())
			.Next()
			.Run();

    }
	
}
