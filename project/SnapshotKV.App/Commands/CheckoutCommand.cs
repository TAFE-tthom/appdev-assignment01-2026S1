namespace SnapshotKV.App;


public class CheckoutCommand : SwitchboardResponse
{
	
    public void ProcessCommand(SnapshotSwitchboard switchboard, string[] args)
	{
        string arg1 = args[0];
        int toIndex = int.Parse(arg1);

        switchboard.Checkout(toIndex);
		
	}
}
