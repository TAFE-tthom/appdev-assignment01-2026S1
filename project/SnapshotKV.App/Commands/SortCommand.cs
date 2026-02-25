namespace SnapshotKV.App;


public class SortCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{

        int key1 = int.Parse(args[0]);
        var result = switchboard.Sort(key1);
		
        Console.WriteLine(result);
		
	}
}
