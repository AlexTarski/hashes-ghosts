using System;
using System.IO;
using System.Text;

namespace hashes;

public class GhostsTask : 
	IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
	IMagic
{
    private string type;
    private byte[] sourceBytes;
    private Cat cat;
    private Robot robot;
    private Document document;
    private Segment segment;
    private Vector vector;
    public void DoMagic()
	{
        switch (this.type)
        {
            case "Cat":
                
                cat.Rename($"{cat.Name}Oops");
                break;
            case "Rob":
                Robot.BatteryCapacity = 200;
                break;
            case "Seg":
                segment.End.Add(segment.Start);
                break;
            case "Vec":
                vector.Add(vector);
                break;
            case "Doc":
                sourceBytes[1] = 10;
                break;
            default: return;

        }
	}

    // Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
    // придется воспользоваться так называемой явной реализацией интерфейса.
    // Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
    // На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

    Document IFactory<Document>.Create()
    {
        if (document != null)
        {
            return document;
        }
        byte[] bytes = { 1, 2, 3 };
        sourceBytes = bytes;
        type = "Doc";
        return document = new Document("doc", Encoding.Default, sourceBytes);
    }

    Robot IFactory<Robot>.Create()
    {
        if(robot != null)
        {
            return robot;
        }
        type = "Rob";
        robot = new Robot("01", 100.0d);
        return robot;
    }

    Cat IFactory<Cat>.Create()
    {
        if(cat != null)
        {
            return cat;
        }
        type = "Cat";
        cat = new Cat("Kitty", "Hello", DateTime.Today);
        return cat;
    }

    Vector IFactory<Vector>.Create()
	{
        if(vector != null)
        { 
            return vector;
        }
        type = "Vec";
        vector = new Vector(1.0d, 3.0d);
        return vector;
	}

	Segment IFactory<Segment>.Create()
	{
        if (segment != null)
        {
            return segment;
        }
        type = "Seg";
        segment = new Segment(new Vector(1.0d, 1.0d), new Vector(5.0d, 5.0d));
        return segment;
	}
}