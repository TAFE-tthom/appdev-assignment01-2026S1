namespace SnapshotKV;

///<summary>
/// SnapshotDBOpResult is used to represent the state of a Database operation
/// such as Commit, Checkout, Save and Load
///</summary>

public interface SnapshotDBOpResult
{

	///<summary>
	/// Used to represent the database intended to be checkedout
	/// loaded, committed or saved. If null, Success() should indicate
	/// false here
	///</summary>
	SnapshotKVDB? Database();

	///<summary>
	/// Outlines if the operation was successful or not
	///</summary>
	bool Success();
	
}
