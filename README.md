# CustomEnumBuilder

## Getting Started
You can install the latest package via Nuget package manager just search for *CustomEnumBuilder*. You can also install via powershell using the following command.

```powershell
Install-Package CustomEnumBuilder -Version 1.0.0
```
Or via the donet CLI

```bash
dotnet add package CustomEnumBuilder --version 1.0.0
```

## Using the package

1. Create a class that inherits from the Enumeration<T> class 

```csharp
  public class Gender : Enumeration<string>
  {
     public Gender(string value, string displayName):base(value, displayName){}
  }
```
2. Add your custom enum types

```csharp
public class Gender : Enumeration<string>{
     public Gender(string value, string displayName):base(value, displayName){}

      public static Gender Male = new Gender("M", "Male");
      public static Gender Female = new Gender("F", "Female");
      public static Gender Unknown = new Gender("U", "Unknown");
}
```
How to use the custom enumeration
 ```csharp
  if(Gender.Male == "M"){ 
     return "the value of Gender.Male is M" 
    }
  ```
You can use the enumeration classes to compare values based on other types instead of just integers
```csharp
public class LicenseType : Enumeration<int>
{
        public LicenseType(int value, string displayName) : base(value, displayName) {   }
       
        public static LicenseType Drivers = new LicenseType(1,"Drivers Or State IDs");
        public static LicenseType Professional = new LicenseType(2,"Professional");        
 }
}
```
## Upcoming
An extension package is upcoming. Right now the extension package will include a helper to create a select list for ASP.NET MVC and ASP.NET Core MVC application from your custom enum type. More information will be added when the Nuget packages are released. If you want to try them out now you can clone this repository and look at the CustomEnumBuilderCoreExtensions (for .NET and .NET Core) and CustomEnumBuilderExtensions (for .NET Framework)
