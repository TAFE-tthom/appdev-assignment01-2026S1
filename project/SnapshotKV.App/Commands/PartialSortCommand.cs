namespace SnapshotKV.App;


public class PartialSortCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{

		
        int key1 = int.Parse(args[0]);
        int indx1 = int.Parse(args[1]);
        int indx2 = int.Parse(args[2]);
        var result = switchboard.PartialSort(key1, indx1, indx2);
		
        Console.WriteLine(result);
	}
}
