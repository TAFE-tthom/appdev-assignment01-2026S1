namespace SnapshotKV.App;


public class SaveCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        string path = args[0];
        var result = switchboard.Save(path);
		
        Console.WriteLine(result);
	}
}
