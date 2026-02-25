namespace SnapshotKV.App;


public class LoadCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        string path = args[0];
        var result = switchboard.Load(path);
		
        Console.WriteLine(result);
	}
}
