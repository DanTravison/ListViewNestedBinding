using System.ComponentModel;

namespace ListViewNestedBinding.Models;

/// <summary>
/// Provides an abstract base class for classes supporting INotifyPropertyChanged
/// </summary>
public abstract class ObservableObject : INotifyPropertyChanged
{
    #region Fields

    readonly WeakEventManager _propertyChanged = new();
    bool _hasChanges;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Initializes a new instance of this class.
    /// </summary>
    protected ObservableObject()
    {
    }

    #endregion Constructors

    public bool HasChanges
    {
        get => _hasChanges;
        set => SetProperty(ref _hasChanges, value, HasChangesChangedEventArgs);
    }

    #region INotifyPropertyChanged

    /// <summary>
    /// Occurs when a property changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
        add
        {
            _propertyChanged.AddEventHandler(value);
        }
        remove
        {
            _propertyChanged.RemoveEventHandler(value);
        }
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event with a cached <see cref="PropertyChangedEventArgs"/>.
    /// </summary>
    /// <param name="e">The <see cref="PropertyChangedEventArgs"/> for the event.</param>
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);
        _propertyChanged.HandleEvent(this, e, nameof(PropertyChanged));
    }

    #endregion INotifyPropertyChanged

    #region SetProperty

    /// <summary>
    /// Provides a <see cref="INotifyPropertyChanged"/> event with a cached <see cref="PropertyChangedEventArgs"/>.
    /// </summary>
    /// <typeparam name="T">The type of the property that changed.</typeparam>
    /// <param name="field">The field storing the property's value.</param>
    /// <param name="newValue">The property's value after the change occurred.</param>
    /// <param name="e">The <see cref="PropertyChangedEventArgs"/> identifying the event.</param>
    /// <returns>true if the property was set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is a null reference.</exception>
    protected bool SetProperty<T>(ref T field, T newValue, PropertyChangedEventArgs e)
    {
        return SetProperty(ref field, newValue, null, e);
    }

    /// <summary>
    /// Provides a <see cref="INotifyPropertyChanged"/> event with a cached <see cref="PropertyChangedEventArgs"/>.
    /// </summary>
    /// <typeparam name="T">The type of the property that changed.</typeparam>
    /// <param name="field">The field storing the property's value.</param>
    /// <param name="newValue">The property's value after the change occurred.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> instance to use to compare the input values.</param>
    /// <param name="e">The <see cref="PropertyChangedEventArgs"/> identifying the event.</param>
    /// <returns>true if the property was set; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is a null reference.</exception>
    protected bool SetProperty<T>(ref T field, T newValue, IEqualityComparer<T> comparer, PropertyChangedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e, nameof(e));

        if (!AreEqual<T>(field, newValue, comparer))
        {
            field = newValue;
            OnPropertyChanged(e);
            if (!object.ReferenceEquals(e, HasChangesChangedEventArgs))
            {
                HasChanges = true;
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Compares two values for equality.
    /// </summary>
    /// <typeparam name="T">The type of value to compare.</typeparam>
    /// <param name="left">The source value.</param>
    /// <param name="right">The new value.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use to compare the values.</param>
    /// <returns>true if the values are equal; otherwise, false.</returns>
    public static bool AreEqual<T>(T left, T right, IEqualityComparer<T> comparer)
    {
        bool areEqual = false;
        if (comparer != null)
        {
            areEqual = comparer.Equals(left, right);
        }
        else if (left != null)
        {
            if (left is IEquatable<T> equate)
            {
                areEqual = equate.Equals(right);
            }
            else
            {
                areEqual = left.Equals(right);
            }
        }
        else if (right == null)
        {
            areEqual = true;
        }

        return areEqual;
    }




    #endregion SetProperty

    static readonly PropertyChangedEventArgs HasChangesChangedEventArgs = new(nameof(HasChanges));
}
