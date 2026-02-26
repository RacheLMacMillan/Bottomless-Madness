using System;

public class ReactiveProperty<T>
{
    private T _value;
    
    public event Action<T> OnChanged;
    
    public T Value 
    {
        get => _value;
        
        set
        {
            _value = value;
            OnChanged?.Invoke(_value);
        }
    }
}