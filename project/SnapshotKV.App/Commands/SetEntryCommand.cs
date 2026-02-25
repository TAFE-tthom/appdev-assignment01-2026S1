namespace SnapshotKV.App;


public class SetEntryCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{

        int key1 = int.Parse(args[0]);
        int[] values = new int[args.Length-1];
        for(int i = 0; i < values.Length; i++)
        {
            values[i] = int.Parse(args[i+1]);
        }
        
        var result = switchboard.SetEntry(key1, values);
		
        Console.WriteLine(result);
		
	}
}
