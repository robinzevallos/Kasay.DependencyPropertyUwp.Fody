[![NuGet Status](http://img.shields.io/nuget/v/Kasay.DependencyPropertyUwp.Fody.svg?style=flat&max-age=86400)](https://www.nuget.org/packages/Kasay.DependencyPropertyUwp.Fody/)

![Icon](https://raw.githubusercontent.com/robinzevallos/robinzevallos.github.io/master/kasay_icon.png)
      
Implement automatically [`DependencyPropety`](https://docs.microsoft.com/en-us/windows/uwp/xaml-platform/dependency-properties-overview) in UWP.

## Usage

See also [Fody usage](https://github.com/Fody/Fody#usage).

### NuGet installation

Install the [Kasay.DependencyPropertyUwp.Fody NuGet package](https://www.nuget.org/packages/Kasay.DependencyPropertyUwp.Fody/):

```powershell
PM> Install-Package Kasay.DependencyPropertyUwp.Fody -Version 1.0.0	
```
### Add to FodyWeavers.xml
** it's generated automatically after build.

Add `<Kasay.DependencyPropertyUwp/>` to [FodyWeavers.xml](https://github.com/Fody/Fody#add-fodyweaversxml)

```xml
<?xml version="1.0" encoding="utf-8"?>
<Weavers xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FodyWeavers.xsd">
  <Kasay.DependencyPropertyUwp />
</Weavers>
```

## Overview

Before code:

```csharp
public class DemoControl : UserControl
{
  [Bind] public String SomeName { get; set; }

  [Bind] public Int32 SomeNumber { get; set; }

  [Bind] public Boolean SomeCondition { get; set; }
}
```

What gets compiled:

```csharp
public class DemoControl : UserControl
{
  public static readonly DependencyProperty SomeNameProperty =
     DependencyProperty.Register(
       "SomeName", 
       typeof(String), 
       typeof(DemoControl),
        null);

  public String SomeName
  {
      get => (String)GetValue(SomeNameProperty);
      set => SetValue(SomeNameProperty, value);
  }

  public static readonly DependencyProperty SomeNumberProperty =
    DependencyProperty.Register(
      "SomeNumber", 
      typeof(Int32), 
      typeof(DemoControl), 
      null);

  public Int32 SomeNumber
  {
      get => (Int32)GetValue(SomeNumberProperty);
      set => SetValue(SomeNumberProperty, value);
  }

  public static readonly DependencyProperty SomeConditionProperty =
    DependencyProperty.Register(
      "SomeCondition", 
      typeof(Boolean), 
      typeof(DemoControl), 
      null);

  public Boolean SomeCondition
  {
      get => (Boolean)GetValue(SomeConditionProperty);
      set => SetValue(SomeConditionProperty, value);
  }

  public SomeControl()
  {
      ((FrameworkElement)Content).DataContext = this;
  }
}
```
As Observed DependencyProperty declarations in UWP are redundant and repetitive, but adding the attibute Bind to each property leaves the code clean.

### [Sample](https://github.com/robinzevallos/Sample.DependencyProperty.UWP)
