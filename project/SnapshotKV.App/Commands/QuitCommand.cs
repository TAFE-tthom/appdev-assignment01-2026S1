namespace SnapshotKV.App;


public class QuitCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        Console.WriteLine("Bye");
		System.Environment.Exit(0);
	}
}
