namespace SpaceBattle.Lib;


//я нашла этот алгоритм на реддите ахаха, не только мемы там смотрю
public class CollisionChecker : ICollisionChecker
{
     public bool HaveCollided(IMovingObject movingObject1, IMovingObject movingObject2)
    {
        var a = VectorToPoint(movingObject1.Position);
        var b = VectorToPoint(movingObject1.Position + movingObject1.Velocity);

        var c = VectorToPoint(movingObject2.Position);
        var d = VectorToPoint(movingObject2.Position + movingObject2.Velocity);

        return ProperIntersection(a, b, c, d);
    }

    private Point VectorToPoint(NVector v)
    {
        return new Point(v.coords[0], v.coords[1]);
    }

    private int Cross(Point a, Point b)
    {
        return a.X * b.Y - a.Y * b.X;
    }

    private int Orient(Point a, Point b, Point c)
    {
        return Cross(b - a, c - a);
    }

    private bool ProperIntersection(Point a, Point b, Point c, Point d)
    {
        int oa = Orient(c, d, a);
        int ob = Orient(c, d, b);
        int oc = Orient(a, b, c);
        int od = Orient(a, b, d);

        return oa * ob < 0 && oc * od < 0;
    }
}