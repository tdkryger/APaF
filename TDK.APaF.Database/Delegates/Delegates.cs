
using TDK.APaF.Database.Delegates;

/// <summary>
/// Delegate for database error events
/// </summary>
/// <param name="sender">the object having the event</param>
/// <param name="e">arguments for the event</param>
public delegate void DatabaseErrorEvent(object sender, DatabaseArgs e);