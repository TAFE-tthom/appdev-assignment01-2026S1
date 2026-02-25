namespace SnapshotKV;


///<summary>
/// QueryResult is used to represent a result retrieved
/// from the database.
/// This result would usually be from a ListKeys, GetEntry, RemoveEntry, SetEntry,
/// View, MakeWatcher, Watcher, Push and Append operations.
/// It also includes set operations such as Sort, Unique, Intersect, Union
///</summary>
public interface SnapshotQueryResult
{
	///<summary>
	/// Records the command the user has activated
	/// This should reflect the exact spelling of the Method name within
	/// SnapshotSwitchboard
	///</summary>
	string Command();

	///<summary>
	/// The result of the operation that was performed.
	/// If it was a `GetEntry`, it will retrun an array of integers
	/// that correspond with that key
	///</summary>
	int[] Results();

	///<summary>
	/// If the operation was `GetEntry`, `SetEntry` or `RemoveEntry`
	/// the key should be recorded and retrievable;
	///</summary>
	int? RecordedKey();

	///<summary>
	/// Show if the operation was a success or not
	///</summary>
	bool Success();
}



/// <summary>
/// Optional/Extension component
/// Result type for CartesianProduct
/// Constructor can be modified/added
/// </summary>
public class SnapshotProductResult
{
	public int[][] Results()
	{
		return new int[][] {new int[]{}};
	}

	public bool Success()
	{
		return false;
	}}
