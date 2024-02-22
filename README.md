# Status

Confirmed The [nested binding](https://www.syncfusion.com/forums/186474/dynamically-updating-groupdescriptor-propertyname)
issue is fixed with Syncfusion.Maui.ListView 24.2.7

# Dynamically updating GroupDescriptor PropertyName

This project reproduces the issue where the GroupDescriptor PropertyName is not updated 
when using a nested binding expression.

The sample simulates a list/details where the list displays
a collection of MetaModel, and the details edits the properties
of the selected MetaModel. 

## Classes
* MainPage.xaml - defines the samples Main view which is a list/details view.
* PropertiesView.xaml - defines the details view for editing a meta object.
* MetaModelCollection - A collection of MetaModel objects.
* ThemeComparer - a custom IComparer for sorting Groups.
* Meta: A class containing meta information for an item. In the production app, Meta contains the information serialized for each item. 
* MetaModel: An encapsulation of a Meta object. In the production app, MetaModel also contains additional properties and methods, such as Save/Load/Reset. 
 
For the repro, MetaModel defines a 'relay' property Theme which relays changes and property changes to the underlying Meta.Theme property. This illustrates
how binding to a nested Meta property causes the issue versus binding to a MetaModel property does not.

## List display of MetaModel objects
SfListView.ItemSource is bound to the MetaModelCollection with
grouping on "Meta.Theme" and group sorting using ThemeComparer.

By default, grouping is defined as follows:
```
<data:GroupDescriptor PropertyName="Meta.Theme">
```

## Details view for editing MetaModel properties
The details view is bound to the selected MetaModel object in the list and displays
a Label and Entry control for each property on Meta: Author, Title, and Theme. These are declared
as nested bindings (e.g., Meta.Author, Meta.Title, and Meta.Theme).

Additionally a Label and Entry control is provided for the Theme relay property on MetaModel.

## Reproducing the issue
1. Run the app	.
2. Select a MetaModel in the list.
3. Change either Theme property in the details view to a new value, such as 'Test'
4. Observe both Theme properties in the details view are updated.
5. Observe the group is not added to the SfListView.

If the PropertyName in MainPage.xaml is updated to use the relay property instead of the nested Meta.Theme property, the group is added to the SfListView:
```
<data:GroupDescriptor PropertyName="Theme">
```