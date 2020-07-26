# Lski.RandomString

Create a Random, not unique, string of characters.

## Usage

```cs
var random = new RandomString(25, "ABCabc");
var str = random.Generate(); // a 25 character string containing a random combination of 'A','B','C','a','b','c'
```

*__Avoid__ creating multiple random objects, instead create a single RandomString object and reuse it*

```cs
// incorrect
for(int = 0; i < 10; i++>) {
	var random = new RandomString(25, "ABCabc");
	var str = random.Generate();
	// do something with str
}

// correct
var random = new RandomString(25, "ABCabc");
for(int = 0; i < 10; i++>) {
	var str = random.Generate();
	// do something with str
}
```

### Characters

Instead of supplying a 'raw' string of characters that are used for selection, there is a `Characters` enum for convenience.

```cs
// Uppercase, lowercase, numbers and symbols
var random = new RandomString(Characters.All);

// Lowercase and numbers
var random = new RandomString(Characters.Lowercase | Characters.Numbers);

// Uppercase, lowercase, numbers and symbols, however excluding similar characters and symbols e.g. l and I
var random = new RandomString(Characters.All | Characters.ExcludeSimilar);
```

### Todo

Currently this package just use `System.Random` underneath, which is not good for cryptographic uses, such as passwords or salts. I will be adding a version that will provide that next.

## Build

Although in a solution each project can be built separately.

To build all the Navigate to solution `./src` and run:

```bash
dotnet build
```

## Publish

Navigate to solution `./src` and run:

```bash
PACKAGE_VERSION=""
NUGET_KEY=""

dotnet pack -c Release -o ../packages
dotnet nuget push -s https://api.nuget.org/v3/index.json "../packages/Lski.RandomString.$PACKAGE_VERSION.nupkg" -k "$NUGET_KEY"
```

_NB: Remember to add variables above._
