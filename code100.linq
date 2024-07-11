<Query Kind="Program">
  <Namespace>System.Text.Json</Namespace>
</Query>

void Main()
{
	var puzzle = LoadJson();

	var one = new { x = 145, width = 20, y = 75, height = 150 };
	var itemsInOne = puzzle.coords.Where(c => isInsideRect(145, 75, 20, 150, c[0], c[1]));

	var itemsInZero1 = puzzle.coords.Where(c => isInsideCircle(280, 150, 75, c[0], c[1]) && !isInsideCircle(280, 150, 50, c[0], c[1]));
	var itemsInZero2 = puzzle.coords.Where(c => isInsideCircle(510, 150, 75, c[0], c[1]) && !isInsideCircle(510, 150, 50, c[0], c[1]));

	(itemsInOne.Count() + itemsInZero1.Count() + itemsInZero2.Count()).Dump();

	itemsInOne.Dump();
	itemsInZero1.Dump();
	itemsInZero2.Dump();
	

}
static bool isInsideRect(int topX, int topY, int width, int height, int x, int y)
{
	if (x >= topX && y >= topY && x <= (topX + width) && y <= (topY + height))
	return true;
	else return false;
}
static bool isInsideCircle(int circle_x, int circle_y, int radius, int x, int y)
{
	// Compare radius of circle with
	// distance of its center from
	// given point
	if ((x - circle_x) * (x - circle_x) +
		(y - circle_y) * (y - circle_y) <= radius * radius)
		return true;
	else
		return false;
}

public Puzzle LoadJson()
{
	Puzzle items;
	using (StreamReader r = new StreamReader(@"c:\projects\code100\coordinatesystem.json"))
	{
		string json = r.ReadToEnd();
		items = JsonSerializer.Deserialize<Puzzle>(json);
	}

	return items;
}

public class Puzzle
{
	public int width { get; set; }
	public int height { get; set;}

	public List<int[]> coords { get; set;}
}
