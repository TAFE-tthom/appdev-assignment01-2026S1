namespace SnapshotKV.App;


public class ViewWatcherCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{

        int key1 = int.Parse(args[0]);
        var result = switchboard.ViewWatcher(key1);
		
        Console.WriteLine(result);
	}
}
