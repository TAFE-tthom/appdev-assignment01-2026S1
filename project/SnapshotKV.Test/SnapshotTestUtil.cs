
namespace SnapshotKV.Test;

public class InternalSnapshotQueryBuilder {
    private string command = String.Empty;
    private int[] results = {};
    private int? recKey = -1;
    private bool success = false;

    public InternalSnapshotQueryBuilder SetCommand(string cmd)
    {
        this.command = cmd;
        return this;
    }

    public InternalSnapshotQueryBuilder SetResults(int[] results)
    {
        this.results = results;
        return this;
    }
    public InternalSnapshotQueryBuilder SetRecKey(int? recKey)
    {
        this.recKey = recKey;
        return this;
    }

    public InternalSnapshotQueryBuilder SetSuccess(bool success)
    {
        this.success = success;
        return this;
    }

    public InternalSnapshotQueryResult Build()
    {
        return new InternalSnapshotQueryResult(
            command, results, recKey, success
        );
    }
    
}


public class InternalSnapshotQueryResult : SnapshotQueryResult
{
    private string command;
    private int[] results;
    private int? recKey;
    private bool success;

    public InternalSnapshotQueryResult(string cmd,
        int[] results, int? recKey, bool success)
    {
        this.command = cmd;
        this.results = results;
        this.recKey = recKey;
        this.success = success;
        
    }

    public static InternalSnapshotQueryBuilder Make()
    {
        return new InternalSnapshotQueryBuilder();
    }

    public string Command() {
        return command;
    }


    public int[] Results()
    {
        return results;
    }

    public int? RecordedKey()
    {
        return recKey;
    }

    public bool Success()
    {
        return success;
    }


    public void Validate(SnapshotQueryResult other)
    {
        Assert.Equal(this.Command(), other.Command());
        Assert.Equal(this.Results(), other.Results());
        Assert.Equal(this.RecordedKey(), other.RecordedKey());
        Assert.Equal(this.Success(), other.Success());
    }
}

public class SnapshotTestScenarioOperation
{
    public Func<SnapshotQueryResult>? CurrentOperation = null;
    public InternalSnapshotQueryResult? Expected = null;
}

public class SnapshotTestScenarioBuilder
{
    SnapshotTestScenarioOperation currentOperation =
        new SnapshotTestScenarioOperation();

    List<SnapshotTestScenarioOperation> operations =
        new List<SnapshotTestScenarioOperation>();
    

    public SnapshotTestScenarioBuilder SetOperation(
        Func<SnapshotQueryResult> operation)
    {
        currentOperation.CurrentOperation = operation;
        return this;
    }

    public SnapshotTestScenarioBuilder SetExpected(
        InternalSnapshotQueryResult expected
    )
    {
        currentOperation.Expected = expected;
        return this;   
    }

    public SnapshotTestScenarioBuilder Next()
    {
        if(currentOperation.CurrentOperation != null &&
            currentOperation.Expected != null) {
            operations.Add(currentOperation);
        }
        else
        {
            throw new Exception("Unable to construct next stage for Scenario");
        }
        currentOperation = new SnapshotTestScenarioOperation();
        return this;
    }

    public Action Done()
    {
        List<SnapshotTestScenarioOperation> ops = this.operations;
        return () => {
            foreach(var op in ops)
            {
                var exp = op.Expected;
                var act = op.CurrentOperation;

                exp.Validate(act());
            }
        };
    }

    public void Run()
    {
        var testScenario = Done();
        testScenario();
    }

    public static SnapshotTestScenarioBuilder Make()
    {
        return new SnapshotTestScenarioBuilder();
    }
}

public class SnapshotTestUtil
{

    public static void ValidateResults(
        SnapshotQueryResult actual,
        InternalSnapshotQueryResult expected)
    {
        expected.Validate(actual);
    }

    public static Action MakeValidation(
        SnapshotQueryResult actual,
        InternalSnapshotQueryResult expected)
    {
        return () => ValidateResults(actual, expected);
    }

    public static SnapshotTestScenarioBuilder Start()
    {
        return SnapshotTestScenarioBuilder.Make();
    }

}
