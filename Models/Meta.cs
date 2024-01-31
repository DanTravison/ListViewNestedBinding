using System.ComponentModel;

namespace ListViewNestedBinding.Models;

/// <summary>
/// Defines the meta data for a maze.
/// </summary>
public sealed class Meta : ObservableObject
{
    #region Fields

    /// <summary>
    /// Defines the default <see cref="Theme"/>.
    /// </summary>
    public static readonly string DefaultTheme = "None";

    /// <summary>
    /// Defines the copyright string for use with maze images.
    /// </summary>
    public const string DefaultCopyright = @"Copyright (c) 2023 All rights reserved.";

    /// <summary>
    /// Defines the author for use with maze images.
    /// </summary>
    public const string DefaultAuthor = @"CodeCadence";

    string _title;
    string _theme = DefaultTheme;
    string _description;
    string _copyright = DefaultCopyright;
    string _author = DefaultAuthor;

    #endregion Fields

    public Meta()
        : base()
    {
    }

    #region Properties

    /// <summary>
    /// Gets or sets the title for the maze.
    /// </summary>
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value, TitleChangedEventArgs);
    }

    /// <summary>
    /// Gets or sets the description of the maze.
    /// </summary>
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value, DescriptionChangedEventArgs);
    }

    /// <summary>
    /// Gets or sets the theme for the maze.
    /// </summary>
    public string Theme
    {
        get => _theme;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                value = DefaultTheme;
            }
            SetProperty(ref _theme, value, ThemeChangedEventArgs);
        }
    }

    /// <summary>
    /// Gets or sets the copyright of the maze.
    /// </summary>
    public string Copyright
    {
        get => _copyright;
        set => SetProperty(ref _copyright, value, CopyrightChangedEventArgs);
    }

    /// <summary>
    /// Gets or sets the author of the maze.
    /// </summary>
    public string Author
    {
        get => _author;
        set => SetProperty(ref _author, value, AuthorChangedEventArgs);
    }

    #endregion Properties

    #region Cached PropertyChangedEventArgs

    /// <summary>
    /// Provides <see cref="PropertyChangedEventArgs"/> passed to the <see cref="INotifyPropertyChanged.PropertyChanged"/> event 
    /// when <see cref="Title"/> changes.
    /// </summary>
    public static readonly PropertyChangedEventArgs TitleChangedEventArgs = new(nameof(Title));

    /// <summary>
    /// Provides <see cref="PropertyChangedEventArgs"/> passed to the <see cref="INotifyPropertyChanged.PropertyChanged"/> event 
    /// when <see cref="Theme"/> changes.
    /// </summary>
    public static readonly PropertyChangedEventArgs ThemeChangedEventArgs = new(nameof(Theme));

    /// <summary>
    /// Provides <see cref="PropertyChangedEventArgs"/> passed to the <see cref="INotifyPropertyChanged.PropertyChanged"/> event 
    /// when <see cref="Description"/> changes.
    /// </summary>
    public static readonly PropertyChangedEventArgs DescriptionChangedEventArgs = new(nameof(Description));

    /// <summary>
    /// Provides <see cref="PropertyChangedEventArgs"/> passed to the <see cref="INotifyPropertyChanged.PropertyChanged"/> event 
    /// when <see cref="Copyright"/> changes.
    /// </summary>
    public static readonly PropertyChangedEventArgs CopyrightChangedEventArgs = new(nameof(Copyright));

    /// <summary>
    /// Provides <see cref="PropertyChangedEventArgs"/> passed to the <see cref="INotifyPropertyChanged.PropertyChanged"/> event 
    /// when <see cref="Author"/> changes.
    /// </summary>
    public static readonly PropertyChangedEventArgs AuthorChangedEventArgs = new(nameof(Author));

    #endregion Cached PropertyChangedEventArgs
}