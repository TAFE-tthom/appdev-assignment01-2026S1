namespace SnapshotKV.App;


public class CommitCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        switchboard.Commit();

		
	}
}
