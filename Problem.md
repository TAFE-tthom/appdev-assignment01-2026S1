
# SnapshotKV

Due Dates/Milestones:

* Milestone 1 Check-In: 11/03/2026
* Milestone 2 Check-In: 25/03/2026
* Expected Completion: 10/04/2026

You are tasked with writing a small database that will operate on numeric values. This database will need to implement a number of features which are standard with other small databases.

You have been given scaffold code that will be the following folders.

  * SnapshotKV - Class Library, you will need to implement functionality within this project itself.

  * SnapshotKV.Test - XUnit Tests, XUnit test cases are present to test your class library and ensure you have implemented the logic as per the documentation.

  * SnapshotKV.App - Console Application, you are free to use it and modify it. It is advised you override the `ToString` method on your `*Result` types to easily display messages.

## Restrictions

There are some restrictions to your implementation.

* You are not allowed to use any standard library collection types (such as List or Dictionary). You will need to utilise the array type within your database. As a hint, you are free to create arrays of types you have created yourself. Outside of `Sort`, it is indicated that you do not utilise any method that will trivialise components of the assessment. You may rebuild certain components if you feel that is worth your time.

* You will need to adhere to the API set out in the initial scaffold. You are free to create your own classes and methods that can be called by the scaffold code. However, changing the name, return type or parameters will prevent the test cases from working.

* You are not allowed to use `static` keyword without approval from the instructor Unless you are using `static` keyword for a `Load` method associated with reading/loading a database from file.

* You cannot add any more fields within the `SnapshotSwitchboard` class. Separate the data from the switchboard with your own type or via `SnapshotKVDB`.

* `SnapshotKVDB` must have a constructor with no parameters.

\newpage

## Background Information

While it may seem scary that you are implementing a database, it is not going to be much different from other tasks you have tackled (It sounds scarier than it looks).

The assessment will be testing your knowledge on:

* Conditions (if and else)
* Loops
* Arrays (specifically integer arrays)
* Classes (Week 3)
* Inheritance and Interfaces (Week 4)
* File/IO (Week 5)
* Testing (Week 5)

However, most of the work is loops and array manipulation.

## Operations to Implement

Below are a list of operations that you will build along with a small example of how it works. These operations have been broken up into following sets.

* Query Operations - Get, Set, Remove, View, MakeWatcher, ViewWatcher
* Set Operations - Sort, PartialSort, Union, Intersect
* Database Operations - Commit, Checkout, Load and, Save

**Important Note**, the operations, and information below is a form of **pseudo-code**. When referring to command, it is referring the method/operation that reflects that.

### Query Operations

* `ListKeys` - Lists all the keys within the database.
  If the database is empty, no keys will be returned
  If the database has one or more keys, the keys should be returned

Assuming keys: 1, 54 and 88 exist, the result return should be:
```
  Command = "ListKeys"
  Results = [1, 54, 88]
  Success = true
```


If no keys exist, it will return the following.

```
  Command = "ListKeys"
  Results = []
  Success = true
```

\vspace{1cm}

* `GetEntry` - Given a key as an argument, it should return the entries associated
  with that key.

Assuming keys 32 exists and has the following data associated [22, 89, 54, 10].
Using `GetEntry 32` should return a result that will be:

```
  Command = "GetEntry"
  Results = [22, 89, 54, 10]
  RecordedKey = 32
  Success = true
```

If the key does not exist, the result should be:

```
  Command = "GetEntry"
  Results = []
  RecordedKey = null
  Success = false
```

\vspace{1cm}

* `SetEntry` - Given a key and data, the data should be associated with the key given or a new key spot is added and the data is set to that key.

If key `45` did not exist yet, `SetEntry 45 [43, 99, 65, 11]` will result in:
  A new key entry (45 added)
  And if you were to call `GetEntry 45`, it will return `[43, 99, 65, 11]`

```
  Command = "SetEntry"
  Results = [43, 99, 65, 11]
  RecordedKey = 45
  Success = true
```

If the key `45` already existed and had the values `[22, 11, 33]` associated, those values will be dropped when `SetEntry 45 [43, 99, 65, 11]` is specified.

\vspace{1cm}

* `RemoveEntry` - Given a key, it will remove the entries and key from the list of keys.

If key `87` existed within the database, the values associated with it will be drop, along with the key itself.

  * Calling `ListKeys` will produce an array that would not include `87` in it
  * Calling `GetEntry 87` will produce an unsuccessful result.

If key `87` did not exist within the database, this will be marked as an unsuccessful query.


\vspace{1cm}

* `Push` - Given a key and data associated, it will add the entries given to the front of the entry.

Let's assume key `54` existed and had the entry `[22, 44, 12]`, if a `Push 54 [88, 77, 66]` was conducted, it will be changed the entry set to produce:

```
  Results = [88, 77, 66, 22, 44, 12]
  Command = "Push"
  RecordedKey = 54
  Success = true
```

If the key does not exist, it will operation like `SetEntry`.

\vspace{1cm}

* `Append` - Given a key and data associated, it will add the entries given to the end of the entry.

Lets assume key `54` existed and had the entry `[22, 44, 12]`, if a `Append 54 [88, 77, 66]` was conducted, it will be changed the entry set to produce:

```
  Results = [22, 44, 12, 88, 77, 66]
  Command = "Apend"
  RecordedKey = 54
  Success = true
```

If the key does not exist, it will operation like `SetEntry`.


\vspace{1cm}

* `View` - Given a key and a range to view. Given a particular range, it will output the range for that view only.

If the command was called like so `View 22 2 4` and we assume key `22` is associated with the entry `[44, 55, 66, 77, 88, 99]`. The result will be:

```
  Command = View
  Results = [66, 77, 88]
  RecordedKey = 22
  Success = true
```

Assuming the same entry but we were to call `View 22 5 10`, this will be out of range, as we cannot access beyond the array boundaries. Similarly we cannot have a negative value nor can the `endIndex` be greater than the `startIndex`.

\vspace{1cm}
\newpage

* `MakeWatcher` - Persistent version of `View`, will create an object that can access via an index.

If the command was called like so `MakeWatcher 22 2 5` and we assume `22` has the entry `[44, 55, 66, 77, 88, 99]`. It will construct an index that correspond with its position in a `Watcher` collection.

\vspace{1cm}

* `ViewWatcher` - It will construct a view using the recorded values from `MakeWatcher`.

Assuming `MakeWatcher 22 2 5` and returns `3` was called and `22` is associated with `[44, 55, 66, 77, 88, 99]`. Calling `ViewWatcher 3` will enact `View 22 2 5` and return the result.

```
  Command = ViewWatcher
  Results = [66, 77, 88, 99]
  RecordedKey = 22
  Success = true
```

**Note**: After a watcher is made, it is possible that the key is deleted and that the watcher should return an error a `ViewWatcher` call is made.

### Set Operations

\vspace{1cm}

* `Sort` - This operation will sort the values of an entry.

Let's assume the key `22` exists and has the entry `[65, 22, 99, 11]`. Using `Sort` on `22` will change the entry to show `[11, 22, 65, 99]`.

If the key does not exist, it is considered a failed operation.


\vspace{1cm}

* `PartialSort` - Given a range, it will sort a segment of the entry.


Let's assume the key `22` exists and has the entry `[65, 22, 99, 11]`. Using `PartialSort 22 1 3` will change the entry to show `[65, 11, 22, 99]`. It will have ignored the first index.

If the key does not exist, it is considered a failed operation.


\vspace{1cm}
\newpage

* `Union` - Given two keys and their entries, it will create a result which is the combination (excluding duplicates).

Let's assume the key `10` and `20` exist.

If `10` has the entry `[45, 33, 89]`
and if `20` has the entry `[33, 61, 5]`

The union between `10` and `20` will be `[5, 33, 45, 61, 89]`. Only 1 count of `33` is permitted, not multiple.

\vspace{1cm}

* `Intersect` - Given two keys and their entries, it will create a result which is the overlapping values.

Let's assume the key `10` and `20` exist.

If `10` has the entry `[45, 33, 89, 21, 5]`
and if `20` has the entry `[33, 61, 5]`

The intersection between `10` and `20` will be `[5, 33]`. We will only include one value from a set and not multiple.

\newpage

### Database Operations

\vspace{1cm}

* `Commit` - Given a database state, it will save the state into memory for it be usable at a later point in time.

Let's assume we have a database with the following state.

Keys = `[1, 4, 7, 10]`

Entries =     (respective keys)
```
[
  [1, 2, 3],
  [5, 4, 3],
  [2, 1],
  [8]
]
```

Commits = `[]`


Creating a commit will create a copy of the database at that given point in time and the `Commits` entries will change to now have `0` there. If commit is triggered again the commit index will be incremented to `1`.

\vspace{1cm}

* `Checkout` - Given an index value, it will load the database state associated with that commit.

Let's assume the last database commit which is index 3 had the following state.

Keys = `[1, 4, 7, 10]`

Entries =     (respective keys)
```
[
  [1, 2, 3],
  [5, 4, 3],
  [2, 1],
  [8]
]
```
Commits = `[0, 1, 2]`


Calling `Checkout 3` will return the state above.


\vspace{1cm}

* `Load` - Will load database object and replace the current database (any commits, keys+values and watchers will be dropped) if successfully loaded. The `Load` command will be given a `path` which is a string that refers to the filesystem.

If the file cannot be loaded, the current database state is preserved.

Loading and saving the database will be a matter of interpreting a CSV file.

As a hint, use `Split` to separate the `,` and read on a line-by-line basis.

Database is in a CSV format
Format: Key0,Value0,Value1,Value2,...
            Key1,Value0,Value1,Value2,...


Using an example file.

```
1, 1, 2, 3
4, 5, 4, 3
7, 2, 1
10, 8
```

It should construct a database with the following state.

Keys = `[1, 4, 7, 10]`

Entries =     (respective keys)
```
[
  [1, 2, 3],
  [5, 4, 3],
  [2, 1],
  [8]
]
```

\vspace{1cm}

* `Save` - Will save the current database state to a CSV file.

You will need to perform some amount of string concatenation to ensure the values are recorded correctly.

Given the database state:


Keys = `[1, 4, 7, 10]`

Entries =     (respective keys)
```
[
  [1, 2, 3],
  [5, 4, 3],
  [2, 1],
  [8]
]
```

The file that should be outputted should resemble the following.

```
1, 1, 2, 3
4, 5, 4, 3
7, 2, 1
10, 8
```

`Save` accepts a pathname which will also include the name of the file. As an example
`Save MySampleDatabase.csv`.

\vspace{1cm}

## Submission, Milestones, Testing, and Instructor Test Cases

Instructor test cases will be progressively released between from the beginning of the assessment to three days before Milestone 2 due date.

You are encouraged to write your own test-cases and attempt to cover branches and cases not covered by the instructor's test cases.

As a hint, the instructor test cases are likely to provide typical-scenarios/happy scenarios and not cases where bad-input is at play. Consider results which may not be well specified or may require you make assumptions. You can discuss your assumptions with the instructor to check for their validity.

### Checklist

Use this as a checklist to ensure you have completed the assessment.

* Constructed a `SnapshotKVDB` class with the necessary fields
* Implement all **Query Operations**
* Implement all **Set Operations**
* Implement all **Database Operations**
* Construct test cases for some **Query Operations**
* Construct test cases for some **Set Operations**
* Construct test cases for some **Database Operations**
* Implementation passes the last release of the Instructor Test Cases


\newpage

## Instructor Comments and Potential "Gotchas"

Given how many have gone with Code 1 and Code 2, I am confident that everyone will be able to complete this assessment by Milestone 2 or by the final due date.

The assessment is mostly to look intimidating but once you identify what the purpose of the methods you need to implement it should **click** into place.

If you are doubting your abilities, there is no harm in asking questions about the assessment or discuss where you are currently at.

The best way to improve is to recognise what the barrier is/what it could be, consult resources, documentation, and instructors to help further your understanding and abilities.

### Potential Gotchas

The assignment has a few things that may appear odd and you may get tripped up on. I will provide some hints on things to consider going forward.

* Interface return types - `SnapshotQueryResult` being returned from most methods which can seem odd/unusual. The rationale here is that it is leaving it up to you to create a class that implements this interface, same with `SnapshotDBOpResult`.

* Be mindful of stateful objects and reference types. Take note what operation may make an object which lifetime is longer than expected. To note, `Commit` and `MakeWatcher` have operations where the objects lifetime may exist beyond the lifetime of the method call.


Good Luck and Happy Coding! -


\vspace{1cm}

Version: 2026-02-26,Release-1
