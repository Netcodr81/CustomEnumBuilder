# CustomEnumBuilder

## Getting Started
You can install the latest package via Nuget package manager just search for *CustomEnumBuilder*. You can also install via powershell using the following command.

```powershell
Install-Package CustomEnumBuilder -Version 1.2.0
```
Or via the donet CLI

```bash
dotnet add package CustomEnumBuilder --version 1.2.0
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
## CustomEnumBuilder.Extensions and CustomEnumBuilder.CoreExtensions
These packages allow you to create a select list from your CustomEnum types. Use the CustomEnumBuilder.Extension package for .NET Framework projects and the CustomEnumBuilder.CoreExtensions for .NET Core and greater projects

## Getting Started CustomEnumBuilder.Extensions
You can install the latest package via Nuget package manager just search for *CustomEnumBuilder.Extensions*. You can also install via powershell using the following command.

```powershell
Install-Package CustomEnumBuilder.Extensions -Version 1.0.0
```
Or via the donet CLI

```bash
dotnet add package CustomEnumBuilder.Extensions --version 1.0.0
```
  
## Getting Started CustomEnumBuilder.CoreExtensions
You can install the latest package via Nuget package manager just search for *CustomEnumBuilder.CoreExtensions*. You can also install via powershell using the following command.

```powershell
Install-Package CustomEnumBuilder.CoreExtensions -Version 1.0.0
```
Or via the donet CLI

```bash
dotnet add package CustomEnumBuilder.CoreExtensions --version 1.0.0
```
## Using the packages
The use is the same for both
1. Create your custom enum type (see CustomEnumBuilder above)

2. Use *SelectListBuilder.GenerateSelectList* to generate the select list

  ```csharp
  SelectList list = SelectListBuilder.GenerateSelectList(GenderEnum.GetAll<GenderEnum>());
  ```
