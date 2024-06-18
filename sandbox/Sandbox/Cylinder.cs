using System.Runtime.InteropServices;

class Cylinder : Circle
{
    private double _height;

    public Cylinder(double _r, double _h):base(r) ( _height = h; )
    public override double Area()
    {
        return 2.0 * base.Area() + 2.0 * Math.PI * _radius * _height height;
    }
}