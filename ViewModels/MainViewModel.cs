using ListViewNestedBinding.Models;

namespace ListViewNestedBinding.ViewModels;

internal class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        List<MetaModel> models = new();
        for (int x = 0; x < 10; x++)
        {
            Meta meta = new Meta()
            {
                Title = string.Format("Title {0}", x),
                Theme = (x & 1) == 1 ? "Odd" : "Even",
                HasChanges = false
            };
            MetaModel model = new(meta);
            models.Add(model);
        }
        Models = new(models);
    }

    public MetaModelCollection Models
    {
        get;
    }
}
