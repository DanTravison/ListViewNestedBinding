namespace ListViewNestedBinding.Models;

public sealed class MetaModel : ObservableObject
{
    public MetaModel(Meta meta)
    {
        Meta = meta;
        meta.PropertyChanged += OnMetaPropertyChange;
    }

    private void OnMetaPropertyChange(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (object.ReferenceEquals(e, Meta.ThemeChangedEventArgs))
        {
            // Relay ThemeChangedEventArgs from Meta
            OnPropertyChanged(e);
        }
    }

    public Meta Meta
    {
        get;
    }

    public string Theme
    {
        get => Meta.Theme;
        set => Meta.Theme = value;
    }
}
