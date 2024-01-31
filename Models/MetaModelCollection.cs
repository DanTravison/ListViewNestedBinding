using System.Collections;
using System.ComponentModel;

namespace ListViewNestedBinding.Models;

public sealed class MetaModelCollection : ObservableObject, IReadOnlyList<MetaModel>
{
    readonly List<MetaModel> _items;
    MetaModel _selectedItem;

    public MetaModelCollection(IEnumerable<MetaModel> models)
    {
        _items = new (models);
        _selectedItem = _items[0];
    }

    #region Properties

    public MetaModel SelectedItem
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value, ReferenceEqualityComparer.Instance, SelectedItemChangedEventArgs);
    }

    public MetaModel this[int index]
    {
        get => _items[index];
    }

    public int Count
    {
        get => _items.Count;
    }

    #endregion Properties

    #region IEnumerable

    public IEnumerator<MetaModel> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    #endregion IEnumerable

    #region Cached PropertyChangedEventArgs

    /// <summary>
    /// Provides <see cref="PropertyChangedEventArgs"/> passed to the <see cref="INotifyPropertyChanged.PropertyChanged"/> event 
    /// when <see cref="SelectedItem"/> changes.
    /// </summary>
    public static readonly PropertyChangedEventArgs SelectedItemChangedEventArgs = new(nameof(SelectedItem));

    #endregion Cached PropertyChangedEventArgs
}
