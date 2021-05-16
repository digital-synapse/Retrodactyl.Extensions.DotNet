# Retrodactyl.Extensions.DotNet

A fast chess engine for .net core!

##### Get the Nuget Package: 

[![NuGet version (Retrodactyl.Extensions.DotNet)](https://img.shields.io/nuget/v/Retrodactyl.Extensions.DotNet)](https://www.nuget.org/packages/Retrodactyl.Extensions.DotNet/)


## Quick Start

Quickly shuffle IEnumerables
```
var items = new[] {"K♥","Q♦","J♣","A♠"};

foreach(var item in items.Shuffle()){
  Console.Log(item);
}
```

A very fast fixed size generic stack with infinite virtual depth
```
var history = new HistoryStack<int>(3);

history.Push(1);
history.Push(2);
history.Push(3);
history.Push(4);
history.Push(5);
history.Push(6);

Console.WriteLine( history.Pop() ); // 6
Console.WriteLine( history.Pop() ); // 5
Console.WriteLine( history.Pop() ); // 4
Console.WriteLine( history.Pop() ); // 0 (default(T))
Console.WriteLine( history.Pop() ); // 0 (default(T))
Console.WriteLine( history.Pop() ); // 0 (default(T))
``` 

A very fast fixed size List<T> like collection
```
var items = new FastList<int>(3);
Console.WriteLine(items.Count);   // 0
items.Add(1);
items.Add(2);
items.Add(3);
Console.WriteLine(items.Count);   // 3

// Enumerate collection
foreach (var item in items.GetEnumerable()){
  Console.WriteLine(item);
}
```