namespace SnapshotKV.App;


public class IntersectCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        int key1 = int.Parse(args[0]);
        int key2 = int.Parse(args[1]);
        var result = switchboard.Intersect(key1, key2);
		
        Console.WriteLine(result);
	}
}
