namespace SnapshotKV.App;


public interface SwitchboardResponse
{
    public void ProcessCommand(SnapshotSwitchboard switchboard,
		string[] args);
}



