namespace SnapshotKV.App;


public class RemoveEntryCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{

        int key1 = int.Parse(args[0]);
        var result = switchboard.RemoveEntry(key1);
		
        Console.WriteLine(result);
		
	}
}
