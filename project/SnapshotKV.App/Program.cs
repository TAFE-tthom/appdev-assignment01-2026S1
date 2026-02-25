namespace SnapshotKV.App;



public class SwitchboardOperator
{
    public SnapshotSwitchboard Switchboard { get; set; } = new SnapshotSwitchboard();
	private Dictionary<string, SwitchboardResponse> commandMap
        = new Dictionary<string, SwitchboardResponse>();
         

	public SwitchboardOperator RegisterCommand(string commandStr,
		SwitchboardResponse command)
	{
		commandMap.Add(commandStr, command);
		return this;
	}

	public SwitchboardResponse? GetCommand(string command)
	{
		SwitchboardResponse? cmd = null;
		commandMap.TryGetValue(command, out cmd);
		return cmd;
	}
}

class Program
{
    static void Main(string[] args)
    {

        SwitchboardOperator oper = new SwitchboardOperator()
            .RegisterCommand("ListKeys", new ListKeysCommand())
            .RegisterCommand("GetEntry", new GetEntryCommand())
            .RegisterCommand("SetEntry", new SetEntryCommand())
            .RegisterCommand("RemoveEntry", new RemoveEntryCommand())
            .RegisterCommand("Push", new PushCommand())
            .RegisterCommand("Append", new AppendCommand())
            .RegisterCommand("View", new ViewCommand())
            .RegisterCommand("MakeWatcher", new MakeWatcherCommand())
            .RegisterCommand("ViewWatcher", new ViewWatcherCommand())
            .RegisterCommand("Sort", new SortCommand())
            .RegisterCommand("PartialSort", new PartialSortCommand())
            .RegisterCommand("Union", new UnionCommand())
            .RegisterCommand("Intersect", new IntersectCommand())
            .RegisterCommand("Commit", new CommitCommand())
            .RegisterCommand("Checkout", new CheckoutCommand())
            .RegisterCommand("Load", new LoadCommand())
            .RegisterCommand("Save", new SaveCommand())
            .RegisterCommand("Quit", new QuitCommand());


		Console.Write("> ");
    	string? line = Console.ReadLine();
		while(line != null)
		{
			string[] spl = line.Split(" ");
			if(spl.Length >= 1)
			{
				string command = spl[0];
				string[] newArgs = spl.Skip(1).ToArray();
				SwitchboardResponse? response = oper.GetCommand(command);

				if(response != null)
				{
					response.ProcessCommand(oper.Switchboard, newArgs);
				}
				else
				{
					Console.WriteLine("No operation associated with command");
				}
			}
			Console.Write("> ");
	    	line = Console.ReadLine();
		}
    }
}
