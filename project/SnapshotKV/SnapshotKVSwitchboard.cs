namespace SnapshotKV;

///<summary>
/// The switchboard is used by an input handler or another
/// view-like object to operate on.
///</summary>
public class SnapshotSwitchboard
{
	private SnapshotKVDB DB { get; set; }

	/// <summary>
	/// Constructor for SnapshotSwitchboard
	/// It will initialise the database and switchboard.
	/// Methods inside this class are able to over-write the database
	/// instance as part of implementing the logic.
	/// </summary>
	public SnapshotSwitchboard(){
		DB = new SnapshotKVDB();
	}


	///<summary>
	/// Lists all the keys that have data associated with them
	///</summary>
	public SnapshotQueryResult ListKeys()
	{

		return null;
	}

	///<summary>
	/// Retrieves an entry using a given key. This should return an array
	/// of integers if the key exists, otherwise, it should indicate that it was
	/// not successful
	///</summary>
	public SnapshotQueryResult GetEntry(int key)
	{
		return null;
	}

	///<summary>
	/// Sets an entry that correspond to a given key.
	/// If the key already exists, it will replace the data that corresponds
	/// with that key with the data inputted.
	///</summary>
	public SnapshotQueryResult SetEntry(int key, int[] data)
	{

		return null;
	}


	///<summary>
	/// Will remove a key and its data associated if it exists within the database
	/// If it does not, it will indicate failure within the result object
	///</summary>
	public SnapshotQueryResult RemoveEntry(int key)
	{

		return null;
	}

	///<summary>
	/// Given an array of data, it will add the data to the front of the existing
	/// entry set associated with the key.
	/// If the key does not exist, this will operate like `SetEntry`
	///</summary>
	public SnapshotQueryResult Push(int key, int[] data)
	{

		return null;
	}

	///<summary>
	/// Similar to `Push`, this operation will append the data to the end
	/// of the entry set associated with the key.
	/// If the key does not exist, this will operate like `SetEntry`
	///</summary>
	public SnapshotQueryResult Append(int key, int[] data)
	{

		return null;
	}

	// View operations below

	///<summary>
	/// A view will ignore elements that are not in the range of stateIndex-endIndex
	/// Given a key, only entries inclusive of startIndex to endIndex will be returned
	/// If the startIndex is > endIndex, this should result in a query failure
	///   As in, it should not return any data
	/// If the data associated with the key is not within range of startIndex
	/// to endindex - This is also considered a failure
	///</summary>
	public SnapshotQueryResult View(int key, int startIndex, int endIndex)
	{
		return null;
	}


	///<summary>
	/// A watcher is a view but it is persistent and can be referred to with
	/// its own indexes.
	/// MakeWatcher will create a `View` that can be accessed via index using
	/// `ViewWatcher`
	///</summary>
	public SnapshotQueryResult MakeWatcher(int key, int startIndex, int endIndex)
	{
		return null;
	}

	///<summary>
	/// Given a watcherKey that was created using `MakeWatcher`
	/// ViewWatcher will execute a `View` command with the recorded data
	///   it has from MakeWatcher
	///</summary>
	public SnapshotQueryResult ViewWatcher(int watcherKey)
	{
		return null;
	}

	/// Set operations below

	///<summary>
	/// Sorts the entries associated with the key
	/// If the key does not exist, a failure state should be indicated with
	/// the result object
	/// Otherwise, the entries should be sorted in ascending order
	///</summary>
	public SnapshotQueryResult Sort(int key)
	{
		return null;
	}


	///<summary>
	/// Sorts a segment of the entry set based on startIndex and endIndex
	/// If the key does not exist, a failure state should be indicated with
	/// the result object
	/// Otherwise, the entries within range should be sorted in ascending order
	///</summary>
	public SnapshotQueryResult PartialSort(int key, int startIndex, int endIndex)
	{
		return null;
	}


	///<summary>
	/// Computes a union between two entries, both key1 and key2 have to exist
	/// for this to be successful.
	///
	/// The result will be combination of both entry sets associated with key1
	/// key2, it should not contain duplicates and it should be sorted in ascending
	/// order.
	///</summary>
	public SnapshotQueryResult Union(int key1, int key2)
	{

		return null;
	}


	///<summary>
	/// Computes the intersection between two entry sets. Both key1 and key2 have
	/// to exist for this to be successful.
	///
	/// The result should be all elements that entries from both key1 and key2
	/// have in common.
	/// It should not contain duplicates and it should be sorted in asceding order
	///</summary>
	public SnapshotQueryResult Intersect(int key1, int key2)
	{

		return null;
	}


	/// Checkout/Commit/Load/Save operations below


	///<summary>
	/// Retrieves an object that has been committed while
	/// the application has been open
	///</summary>
	public SnapshotDBOpResult Commit()
	{
		
		return null;
	}


	///<summary>
	/// Retrieves an object that has been committed while
	/// the application has been open
	///</summary>
	public SnapshotDBOpResult Checkout(int id)
	{

		return null;
	}

	///<summary>
	/// Will load database object and replace the current database
	/// (any commits, keys+values and watchers will be dropped)
	/// if successfully loaded.
	/// If the file cannot be loaded, the current database state is preserved.
	///
	/// Database is in a CSV format
	///    Format: Key0,Value0,Value1,Value2,...
	///            Key1,Value0,Value1,Value2,...
	///</summary>
	public SnapshotDBOpResult Load(string path)
	{
		return null;
	}

	///<summary>
	/// Will save the current database to a file specified
	/// The data that will be saved is only the keys and values associated
	/// The save format is CSV (Comma-Separated Values)
	///    Format: Key0,Value0,Value1,Value2,...
	///            Key1,Value0,Value1,Value2,...
	///</summary>
	public SnapshotDBOpResult Save(string path)
	{
		return null;
	}


	/// Optional/Extension: Cartesian Product

	/// <summary>
	/// This is an optional query to implement. You are tasked with constructing
	/// a 
	/// </summary>
	public SnapshotProductResult CartesianProduct(int[] keys)
	{
		return new SnapshotProductResult();
	}


}
