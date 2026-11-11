namespace LAB;
public class Money
{
    private uint _rubles;
    private byte _kopeks;
    
    public uint Rubles
    {
        get { return _rubles; }
        set { _rubles = value; }
    }
    public byte Kopeks
    {
        get { return _kopeks; }
        set 
        { 
            _rubles += (uint)(value / 100);
            _kopeks = (byte)(value % 100); 
        }
    }
    public Money() 
    {
        _rubles = 0;
        _kopeks = 0;
    }
    public Money(uint rubles, byte kopeks)
    {
        _rubles = rubles + (uint)(kopeks / 100);
        _kopeks = (byte)(kopeks % 100);
    }
    private static Money FromTotalKopecks(long total)
    {
        if (total < 0)
        {
            throw new InvalidOperationException("Денежная сумма не может быть отрицательной.");
        }
        
        return new Money((uint)(total / 100), (byte)(total % 100));
    }
    public override string ToString()
    {
        return $"{_rubles} руб. {_kopeks:D2} коп."; 
    }
    public bool IsEqual(Money other)
    {
        if (other == null) return false;
        return this._rubles == other._rubles && this._kopeks == other._kopeks;
    }

    private long TotalKopecks()
    {
        return _rubles * 100L + _kopeks;
    }
    
    public static Money operator ++(Money m)
    {
        return FromTotalKopecks(m.TotalKopecks() + 1);
    }
    
    public static Money operator --(Money m)
    {
        return FromTotalKopecks(m.TotalKopecks() - 1);
    }
    
    public static implicit operator uint(Money m)
    {
        return m._rubles; 
    }

    public static explicit operator double(Money m)
    {
        return m._kopeks / 100.0;
    }
    
    public static Money operator -(Money m, int kopeksToSubtract)
    {
        return FromTotalKopecks(m.TotalKopecks() - kopeksToSubtract);
    }

    public static Money operator -(int kopeksToSubtract, Money m)
    {
        return FromTotalKopecks(m.TotalKopecks() - kopeksToSubtract);
    }
}
