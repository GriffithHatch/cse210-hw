using System.Dynamic;

class Fraction{
    private int top;
    private int bottom;

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int somenumber){
        top = somenumber;
        bottom = 1;
    }

    public Fraction(int sometop, int somebottom){
        top = sometop;
        bottom = somebottom;
    }

    public string FractionString(){
        return $"{top}/{bottom}";
    }

    public double Fractiondecimal(){
        return (double)top/(double)bottom; // Why does that work? just putting (double) top or bottom, that does not make sense to me but I guess.
    }

}