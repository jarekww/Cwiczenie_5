using System;


interface IKawa
{
    string Opis();
    double Koszt();
}


class Kawa : IKawa
{
    public string Opis()
    {
        return "Kawa";
    }

    public double Koszt()
    {
        return 2.0;
    }
}

abstract class DekoratorKawy : IKawa
{
    protected IKawa _kawa;

    public DekoratorKawy(IKawa kawa)
    {
        _kawa = kawa;
    }

    public virtual string Opis()
    {
        return _kawa.Opis();
    }

    public virtual double Koszt()
    {
        return _kawa.Koszt();
    }
}


class Mleko : DekoratorKawy
{
    public Mleko(IKawa kawa) : base(kawa) { }

    public override string Opis()
    {
        return _kawa.Opis() + ", Mleko";
    }

    public override double Koszt()
    {
        return _kawa.Koszt() + 0.5;
    }
}


class Cukier : DekoratorKawy
{
    public Cukier(IKawa kawa) : base(kawa) { }

    public override string Opis()
    {
        return _kawa.Opis() + ", Cukier";
    }

    public override double Koszt()
    {
        return _kawa.Koszt() + 0.3;
    }
}


class Syrop : DekoratorKawy
{
    public Syrop(IKawa kawa) : base(kawa) { }

    public override string Opis()
    {
        return _kawa.Opis() + ", Syrop";
    }

    public override double Koszt()
    {
        return _kawa.Koszt() + 0.7;
    }
}


class Program
{
    static void Main(string[] args)
    {
      
        IKawa kawa = new Kawa();
        Console.WriteLine("Zamówienie: " + kawa.Opis() + ", Koszt: " + kawa.Koszt());

      
        kawa = new Mleko(kawa);
        Console.WriteLine("Zamówienie: " + kawa.Opis() + ", Koszt: " + kawa.Koszt());

     
        kawa = new Cukier(kawa);
        Console.WriteLine("Zamówienie: " + kawa.Opis() + ", Koszt: " + kawa.Koszt());

    
        kawa = new Syrop(kawa);
        Console.WriteLine("Zamówienie: " + kawa.Opis() + ", Koszt: " + kawa.Koszt());
    }
}
