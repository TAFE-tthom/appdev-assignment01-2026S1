namespace SnapshotKV.App;


public class ListKeysCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        var result = switchboard.ListKeys();
		
	}
}
