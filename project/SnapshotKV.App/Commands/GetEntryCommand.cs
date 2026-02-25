namespace SnapshotKV.App;


public class GetEntryCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{

        int key1 = int.Parse(args[0]);
        var result = switchboard.GetEntry(key1);
		
        Console.WriteLine(result);
		
	}
}
