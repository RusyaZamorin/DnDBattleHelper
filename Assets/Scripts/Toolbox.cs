using System;
using System.Collections.Generic;
using Homebrew;
 
public class Toolbox : Singleton<Toolbox> 
{	
	private Dictionary<Type,object> _data = new Dictionary<Type, object>();

	public static void Add(object obj)
	{
		var add = obj;
		var manager = obj as ManagerBase;
		
		if (manager != null)
			add = Instantiate(manager);
		else return;
		
		Instance._data.Add(obj.GetType(), add);

		if (add is IAwake)
		{
			(add as IAwake).OnAwake();
		}	
	}
			
	public static T Get<T>()
	{
		object resolve;
		Instance._data.TryGetValue(typeof(T), out resolve);
		return (T) resolve;
	}

	public void ClearScene()
	{
		
	}



}
